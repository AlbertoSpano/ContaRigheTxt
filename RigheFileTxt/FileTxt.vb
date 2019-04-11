Imports Microsoft.Office.Interop
Imports OfficeOpenXml

Public Class FileTxt

    Public Class Riga
        Public Property Cartella As String
        Public Property NomeFile As String
        Public Property Righe As Integer
    End Class

    Private pattern As String

    Private Sub btnScegli_Click(sender As Object, e As EventArgs) Handles btnScegli.Click

        pattern = txtFiltro.Text

        My.Settings.Filtro = Me.txtFiltro.Text
        My.Settings.Save()

        Me.FolderBrowserDialog1.ShowNewFolderButton = False

        If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

            Me.Cursor = Cursors.WaitCursor

            ' ... memorizza la cartella radice selezionata e prefisso
            My.Settings.RootFolder = Me.FolderBrowserDialog1.SelectedPath
            My.Settings.Prefisso = Me.txtPrefisso.Text
            My.Settings.Save()

            ' ...
            Me.txtFolder.Text = My.Settings.RootFolder

            ' ... elimina righe precedente selezione
            Me.grdFiles.Rows.Clear()

            ' ... inizializza elenco
            Dim elenco As New List(Of String)

            ' ... seleziona i file
            ContaRighe(Me.FolderBrowserDialog1.SelectedPath, elenco)

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

            ' ... ricopia i file nella griglia
            For Each f As Riga In g
                Me.grdFiles.Rows.Add(IO.Path.GetFileName(f.Cartella), f.NomeFile, f.Righe)
            Next

            ' ...
            Me.Cursor = Cursors.Default

            ' ... abilita l'export
            Me.btnEsporta.Enabled = grdFiles.Rows.Count > 0

            ' ... nessun file
            If grdFiles.Rows.Count = 0 Then MsgBox("Nessun file trovato!")

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
            ' ... nome file temporaneo export
            Dim matrice As String = IO.Path.Combine(System.IO.Path.GetTempPath(), IO.Path.GetRandomFileName)
            Dim csv As String = matrice + ".csv"
            Dim xls As String = matrice + ".xls"

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
        Me.FolderBrowserDialog1.SelectedPath = My.Settings.RootFolder
        Me.txtPrefisso.Text = My.Settings.Prefisso
    End Sub

    Private Sub chkGroup_CheckedChanged(sender As Object, e As EventArgs)
        grdFiles.Rows.Clear()
    End Sub

End Class
