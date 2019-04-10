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

            ' ... memorizza la cartella radice selezionata
            My.Settings.RootFolder = Me.FolderBrowserDialog1.SelectedPath
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
            If chkGroup.Checked Then
                g = g.GroupBy(Function(x) x.Cartella).Select(Function(y) New Riga() With {.Cartella = y.Key, .NomeFile = String.Format("(numero file: {0})", y.Count), .Righe = y.Sum(Function(z) z.Righe)}).ToList
            End If

            ' ... totali
            g.Add(New Riga() With {.Cartella = "", .NomeFile = "Totale:", .Righe = g.Sum(Function(x) x.Righe)})

            ' ... ricopia i file nella griglia
            For Each f As Riga In g
                Me.grdFiles.Rows.Add(IO.Path.GetFileName(f.Cartella), f.NomeFile, f.Righe)
            Next

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
            Dim ftmp As String = IO.Path.Combine(System.IO.Path.GetTempPath(), IO.Path.GetRandomFileName + ".csv")

            Dim result As New List(Of String)

            ' ... intestazioni colonne
            result.Add(String.Format("{0}{1}{2}{1}{3}", "Cartella", vbTab, "Nome file", "Righe"))

            For Each d As DataGridViewRow In grdFiles.Rows
                ' ... cartella
                Dim c As String = d.Cells(0).Value.ToString
                ' ... se il nome cartella è un numero antepone un apice
                If IsNumeric(c) Then c = "'" + c
                ' ... riga excel
                result.Add(String.Format("{0}{1}{2}{1}{3}", c, vbTab, d.Cells(1).Value, d.Cells(2).Value))
            Next

            ' ... scrive nel file
            IO.File.WriteAllLines(ftmp, result.ToArray)

            ' ... apre il file
            System.Diagnostics.Process.Start(ftmp)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FileTxt_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.txtFiltro.Text = My.Settings.Filtro
        Me.FolderBrowserDialog1.SelectedPath = My.Settings.RootFolder

    End Sub

    Private Sub chkGroup_CheckedChanged(sender As Object, e As EventArgs) Handles chkGroup.CheckedChanged
        grdFiles.Rows.Clear()
    End Sub

End Class
