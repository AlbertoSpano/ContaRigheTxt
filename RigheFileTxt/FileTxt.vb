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
    Private destFolder As String
    Private destFolderName As String
    Private currentFolder As String
    Private rightNameLengthForAccorpation As Integer = 10

    Private Sub btnScegli_Click(sender As Object, e As EventArgs) Handles btnScegli.Click

        pattern = txtFiltro.Text

        My.Settings.Filtro = Me.txtFiltro.Text
        My.Settings.Dalle = If(Me.chkDalle.Checked, Me.txtDalle.Text, Nothing)
        My.Settings.Alle = If(Me.chkAlle.Checked, Me.txtAlle.Text, Nothing)
        My.Settings.Creati = If(rbCreati.Checked, "C", "M")
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

            ' ... cartella corrente
            currentFolder = IO.Directory.GetParent(My.Settings.RootFolder).FullName

            ' ... nuova destinazione cartelle e files
            destFolder = IO.Path.Combine(currentFolder, "_" + IO.Path.GetFileName(My.Settings.RootFolder))
            destFolderName = IO.Path.GetFileName(destFolder)
            Try
                If IO.Directory.Exists(destFolder) Then IO.Directory.Delete(destFolder, True)
            Catch ex As Exception
                If ex.InnerException Is Nothing Then
                    MsgBox(ex.Message)
                Else
                    MsgBox(ex.InnerException.Message)
                End If
                Me.Enabled = True
                Return
            End Try

            ' ... crea copia della struttura cartelle e files
            CopyFolder(My.Settings.RootFolder, destFolder)

            ' ... argomento per backgroundworker
            Dim argument As New Arg
            argument.PercorsoIniziale = destFolder
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

            ' ... nome file temporaneo export
            Dim csv As String = IO.Path.Combine(currentFolder, destFolderName) + ".csv"
            Dim xls As String = IO.Path.Combine(currentFolder, destFolderName) + ".xlsx"

            Try
                IO.File.Delete(csv)
                IO.File.Delete(xls)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim result As New List(Of String)

            ' ... intestazioni colonne
            result.Add(String.Format("{0}{1}{2}", "Cartella", vbTab, "Righe"))

            For Each d As DataGridViewRow In grdFiles.Rows
                ' ... cartella
                Dim c As String = d.Cells(1).Value.ToString
                ' ... se il nome cartella è un numero antepone un apice
                If IsNumeric(c) Then c = My.Settings.Prefisso + c
                ' ... riga excel
                result.Add(String.Format("{0}{1}{2}", c, vbTab, d.Cells(3).Value))
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

            ' ... elimina file csv
            IO.File.Delete(csv)

            ' ... apre il file
            If chkApriFileAlTermine.Checked Then System.Diagnostics.Process.Start(xls)

            ' ... accorpa file
            If chkAccorpaFile.Checked Then AccorpaFile

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FileTxt_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.txtFiltro.Text = My.Settings.Filtro
        Me.fbd.SelectedPath = My.Settings.RootFolder
        Me.txtPrefisso.Text = My.Settings.Prefisso
        Me.rbCreati.Checked = My.Settings.Creati = "C"

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
        If rbCreati.Checked Then
            If argument.Dalle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetCreationTime(x).TimeOfDay >= CDate(argument.Dalle).TimeOfDay).ToList
            If argument.Alle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetCreationTime(x).TimeOfDay <= CDate(argument.Alle).TimeOfDay).ToList
        Else
            If argument.Dalle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetLastWriteTime(x).TimeOfDay >= CDate(argument.Dalle).TimeOfDay).ToList
            If argument.Alle IsNot Nothing Then elenco = elenco.Where(Function(x) IO.File.GetLastWriteTime(x).TimeOfDay <= CDate(argument.Alle).TimeOfDay).ToList
        End If

        ' ... conta le righe dei file selezionati
        Dim g As List(Of Riga) = elenco.Select(Function(x) New Riga() With {.Cartella = IO.Path.GetDirectoryName(x), .NomeFile = IO.Path.GetFileName(x), .Righe = IO.File.ReadAllLines(x).Count}).ToList

        ' ... raggruppa
        If rbPercorsoCartella.Checked Then
            g = g.GroupBy(Function(x) x.Cartella).Select(Function(y) New Riga() With {.Cartella = y.Key,
                                                                                      .NomeFile = String.Format("(numero file: {0})", y.Count),
                                                                                      .Righe = y.Sum(Function(z) z.Righe)}).OrderBy(Function(o) o.Cartella).ToList
        End If

        ' ... totali
        g.Add(New Riga() With {.Cartella = "", .NomeFile = "Totale:", .Righe = g.Sum(Function(x) x.Righe)})

        e.Result = g

    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted

        Me.grdFiles.Rows.Clear()

        ' ... ricopia i file nella griglia
        Dim n As Integer = 0
        For Each f As Riga In CType(e.Result, List(Of Riga))
            n += 1
            Me.grdFiles.Rows.Add(n, IO.Path.GetFileName(f.Cartella), f.NomeFile, f.Righe)
        Next

        ' ...
        Me.Enabled = True

        ' ... abilita l'export
        Me.btnEsporta.Enabled = grdFiles.Rows.Count > 0

        ' ... nessun file
        If grdFiles.Rows.Count = 0 Then
            MsgBox("Nessun file trovato!")
        Else
            ' ... rinomina cartelle
            If chkRinomina.Checked Then
                For Each f As Riga In CType(e.Result, List(Of Riga)).Where(Function(x) Not String.IsNullOrEmpty(x.Cartella))
                    IO.Directory.Move(f.Cartella, String.Format("{0} {1}", f.Cartella, f.Righe))
                Next
            End If
        End If


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

    Private Sub AccorpaFile()

        AccorpaFileRecursione(destFolder)

    End Sub

    Private Sub AccorpaFileRecursione(source As String)

        Dim tipi As IEnumerable(Of String) = IO.Directory.GetFiles(source).Cast(Of String).GroupBy(Function(x) x.Substring(x.Length - rightNameLengthForAccorpation)).Select(Function(x) x.Key)

        For Each t As String In tipi
            Dim content As String = String.Empty
            For Each f As String In IO.Directory.GetFiles(source, "*" + t)
                content += IO.File.ReadAllText(f)
            Next
            If content.Length > 0 Then
                Dim newFile As String = IO.Path.Combine(source, t)
                IO.File.WriteAllText(newFile, content)
            End If
        Next


        For Each d As String In IO.Directory.GetDirectories(source, "*", IO.SearchOption.AllDirectories)
            AccorpaFileRecursione(d)
        Next

    End Sub

    Private Sub CopyFolder(ByVal sourceFolder As String, ByVal destFolder As String)

        If Not IO.Directory.Exists(destFolder) Then IO.Directory.CreateDirectory(destFolder)

        Dim files As String() = IO.Directory.GetFiles(sourceFolder)

        For Each file As String In files
            Dim name As String = IO.Path.GetFileName(file)
            Dim dest As String = IO.Path.Combine(destFolder, name)
            IO.File.Copy(file, dest)
        Next

        Dim folders As String() = IO.Directory.GetDirectories(sourceFolder)

        For Each folder As String In folders
            Dim name As String = IO.Path.GetFileName(folder)
            Dim dest As String = IO.Path.Combine(destFolder, name)
            CopyFolder(folder, dest)
        Next
    End Sub

    Private Sub chkAccorpaFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccorpaFile.CheckedChanged
        txtPatternAccorpamento.Enabled = chkAccorpaFile.Checked
    End Sub

End Class

