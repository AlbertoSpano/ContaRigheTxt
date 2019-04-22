Imports System.ComponentModel
Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Imports OfficeOpenXml

Public Class FileTxt

    Public Class Riga
        Public Property Cartella As String
        Public Property NomeFile As String
        Public Property Righe As Integer
    End Class

    Public Class Arg
        Public Property PercorsoIniziale As String
        Public Property Dalle As Object
        Public Property Alle As Object
    End Class

    Private pattern As String

    Private Sub btnScegli_Click(sender As Object, e As EventArgs) Handles btnScegli.Click

        pattern = txtFiltro.Text

        My.Settings.Filtro = Me.txtFiltro.Text
        My.Settings.Dalle = If(Me.chkDalle.Checked, Me.txtDalle.Text, Nothing)
        My.Settings.Alle = If(Me.chkAlle.Checked, Me.txtAlle.Text, Nothing)
        My.Settings.Save()

        Me.fbd.ShowNewFolderButton = False

        If Me.fbd.ShowDialog = DialogResult.OK Then

            ' ... memorizza la cartella radice selezionata e prefisso
            My.Settings.RootFolder = Me.fbd.SelectedPath
            My.Settings.Prefisso = Me.txtPrefisso.Text
            My.Settings.Save()

            ' ...
            Me.txtFolder.Text = My.Settings.RootFolder

            ' ...
            Me.Enabled = False

            ' ... elimina righe precedente selezione
            Me.grdFiles.Rows.Clear()

            ' ... argomento per backgroundworker
            Dim argument As New Arg
            argument.PercorsoIniziale = Me.txtFolder.Text
            If chkDalle.Checked Then argument.Dalle = txtDalle.Value
            If chkAlle.Checked Then argument.Alle = txtAlle.Value

            ' ...
            bw.RunWorkerAsync(argument)

        End If

    End Sub

    Private Sub ContaRighe(folder As String, elenco As List(Of String))

        For Each f As String In IO.Directory.EnumerateFiles(folder, pattern)
            elenco.Add(f)
        Next

        For Each d As String In IO.Directory.EnumerateDirectories(folder)
            ContaRighe(d, elenco)
        Next

    End Sub

    Private Sub btnEsporta_Click(sender As Object, e As EventArgs) Handles btnEsporta.Click

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim tempFolder As String = System.IO.Path.GetTempPath()
            Dim folderExport As String = System.IO.Path.GetTempPath()

            My.Settings.ExportFolder = cboCartellaExport.SelectedItem.ToString
            My.Settings.Save()


            ' ... cartella destinazione
            Select Case cboCartellaExport.SelectedItem.ToString

                Case "... chiedi"
                    If fbd.ShowDialog = DialogResult.OK Then
                        folderExport = fbd.SelectedPath
                    Else
                        Return
                    End If
                Case "Desktop"
                    folderExport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Case "Documenti"
                    folderExport = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                Case "Temp"
                    folderExport = System.IO.Path.GetTempPath()
                Case "Download"
                    folderExport = GetDownloadFolderPath()
                Case Else
                    ' continua: usa la temp
            End Select

            ' ... nome file temporaneo export
            Dim csv As String = IO.Path.Combine(tempFolder, IO.Path.GetRandomFileName) + ".csv"
            Dim xls As String = IO.Path.Combine(folderExport, IO.Path.GetRandomFileName) + ".xlsx"

            Dim result As New List(Of String)

            ' ... intestazioni colonne
            result.Add(String.Format("{0}{1}{2}", "Cartella", vbTab, "Righe"))

            For Each d As DataGridViewRow In grdFiles.Rows
                ' ... cartella
                Dim c As String = d.Cells(0).Value.ToString
                ' ... se il nome cartella è un numero antepone un apice
                If IsNumeric(c) Then c = My.Settings.Prefisso + c
                ' ... riga excel
                result.Add(String.Format("{0}{1}{2}", c, vbTab, d.Cells(2).Value))
            Next

            ' ... scrive nel file
            IO.File.WriteAllLines(csv, result.ToArray)

            ' ... crea file di excel
            Using ex As New OfficeOpenXml.ExcelPackage(New IO.FileInfo(xls))

                Dim ExcelTextFormat As New ExcelTextFormat()
                ExcelTextFormat.Delimiter = Chr(9)

                Dim worksheet As ExcelWorksheet = ex.Workbook.Worksheets.Add("Foglio 1")

                worksheet.Cells("A1").LoadFromText(New IO.FileInfo(csv), ExcelTextFormat, OfficeOpenXml.Table.TableStyles.Light9, True)

                worksheet.Cells(worksheet.Dimension.Address).AutoFitColumns()

                ex.Save()

            End Using


            ' ... apre il file
            System.Diagnostics.Process.Start(xls)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FileTxt_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.txtFiltro.Text = My.Settings.Filtro
        Me.fbd.SelectedPath = My.Settings.RootFolder
        Me.txtPrefisso.Text = My.Settings.Prefisso
        Me.cboCartellaExport.SelectedItem = My.Settings.ExportFolder

        If String.IsNullOrEmpty(My.Settings.Dalle) Then
            chkDalle.Checked = False
        Else
            chkDalle.Checked = True
            txtDalle.Value = CDate(String.Format("{0:dd/MM/yyyy} {1} ", Today, My.Settings.Dalle))
        End If
        If String.IsNullOrEmpty(My.Settings.Alle) Then
            chkAlle.Checked = False
        Else
            chkAlle.Checked = True
            txtAlle.Value = CDate(String.Format("{0:dd/MM/yyyy} {1} ", Today, My.Settings.Alle))
        End If
    End Sub

    Private Sub chkGroup_CheckedChanged(sender As Object, e As EventArgs)
        grdFiles.Rows.Clear()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork

        ' ... argument
        Dim argument As Arg = CType(e.Argument, Arg)

        ' ... inizializza elenco
        Dim elenco As New List(Of String)

        ' ... seleziona i file
        ContaRighe(argument.PercorsoIniziale, elenco)

        ' ... filtra per orario
        If argument.Dalle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetCreationTime(x).TimeOfDay >= CDate(argument.Dalle).TimeOfDay).ToList
        If argument.Alle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetCreationTime(x).TimeOfDay <= CDate(argument.Alle).TimeOfDay).ToList

        ' ... conta le righe dei file selezionati
        Dim g As List(Of Riga) = elenco.Select(Function(x) New Riga() With {.Cartella = IO.Path.GetDirectoryName(x), .NomeFile = IO.Path.GetFileName(x), .Righe = IO.File.ReadAllLines(x).Count}).ToList

        ' ... raggruppa
        If rbPercorsoCartella.Checked Then
            g = g.GroupBy(Function(x) x.Cartella).Select(Function(y) New Riga() With {.Cartella = y.Key, .NomeFile = String.Format("(numero file: {0})", y.Count), .Righe = y.Sum(Function(z) z.Righe)}).OrderBy(Function(o) o.Cartella).ToList
        ElseIf rbNomeCartella.Checked Then
            g = g.GroupBy(Function(x) IO.Path.GetFileName(x.Cartella)).Select(Function(y) New Riga() With {.Cartella = y.Key, .NomeFile = String.Format("(numero file: {0})", y.Count), .Righe = y.Sum(Function(z) z.Righe)}).OrderBy(Function(o) o.Cartella).ToList
        End If

        ' ... totali
        g.Add(New Riga() With {.Cartella = "", .NomeFile = "Totale:", .Righe = g.Sum(Function(x) x.Righe)})

        e.Result = g

    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted

        ' ... ricopia i file nella griglia
        For Each f As Riga In CType(e.Result, List(Of Riga))
            Me.grdFiles.Rows.Add(IO.Path.GetFileName(f.Cartella), f.NomeFile, f.Righe)
        Next

        ' ...
        Me.Enabled = True

        ' ... abilita l'export
        Me.btnEsporta.Enabled = grdFiles.Rows.Count > 0

        ' ... nessun file
        If grdFiles.Rows.Count = 0 Then MsgBox("Nessun file trovato!")

    End Sub

    Private Sub chkDalle_CheckedChanged(sender As Object, e As EventArgs) Handles chkDalle.CheckedChanged
        txtDalle.Visible = CType(sender, CheckBox).Checked
    End Sub

    Private Sub chkAlle_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlle.CheckedChanged
        txtAlle.Visible = CType(sender, CheckBox).Checked
    End Sub

    Private Function GetDownloadFolderPath() As String
        Return Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString()
    End Function

End Class
