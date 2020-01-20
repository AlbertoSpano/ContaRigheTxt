Imports System.ComponentModel

Public Class Fase_2

    Private Sub Fase_2_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim bs As New BindingList(Of Separatore)
        bs.Add(New Separatore With {.Carattere = Chr(9), .Descrizione = "Tabulazione"})
        bs.Add(New Separatore With {.Carattere = ";"c, .Descrizione = "Punto e virgola"})
        bs.Add(New Separatore With {.Carattere = ","c, .Descrizione = "Virgola"})


        cboSeparatore.DataSource = bs
        cboSeparatore.ValueMember = "Carattere"
        cboSeparatore.DisplayMember = "Descrizione"
        cboSeparatore.Refresh()
        cboSeparatore.SelectedItem = bs.FirstOrDefault(Function(x) x.Carattere = My.Settings.SeparatoreCsv)

        AddHandler cboSeparatore.SelectedIndexChanged, AddressOf cboSeparatore_SelectedIndexChanged

        caricaColonne()
        txtHyperlink.Text = My.Settings.HyperLink

    End Sub

    Private Sub Fase_2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Salva()
    End Sub

    Private Sub caricaColonne()
        Dim bl As New BindingList(Of Colonna)(Colonne.Get)
        Dim bs As New BindingSource(bl, Nothing)
        grdColonne.DataSource = bs
    End Sub

    Private Sub Salva()

        Dim source As New List(Of Colonna)

        For Each row As DataGridViewRow In grdColonne.Rows
            If Not row.IsNewRow Then
                source.Add(New Colonna() With {.colFile1 = CInt(row.Cells(0).Value), .colFile2 = CInt(row.Cells(1).Value), .hyperLink = row.Cells(2).Value})
            End If
        Next

        Valida(source, txtHyperlink.Text)

        Colonne.Set(source)

    End Sub

    Private Function Valida(source As List(Of Colonna), hyperlink As String) As Boolean

        Dim hyp As List(Of Object) = source.Where(Function(x) x.hyperLink IsNot Nothing).Select(Function(x) x.hyperLink).ToList

        For Each h As Object In hyp
            Dim search As String = String.Format("{{{0}}}", h)
            If hyperlink.IndexOf(search) = -1 Then
                MsgBox("Marcatore " + search + " non trovato nel formato della stringa ipertestuale!")
                Return False
            End If
        Next

        Dim sleft As String() = hyperlink.Split("{"c)
        Dim sright As String() = hyperlink.Split("}"c)

        Dim hh As New List(Of String)

        If sleft.Count = 1 And sright.Count = 1 Then
            MsgBox("Il formato della stringa ipertestuale non contiene alcun marcatore!")
            Return False
        ElseIf sleft.Count <> sright.Count Then
            MsgBox("Il formato della stringa ipertestuale non corretto!")
            Return False
        Else
            For i As Integer = 1 To sleft.Count - 1
                Dim s As String() = sleft(i).Split("}"c)
                If s.Count < 2 Then
                    MsgBox("Il formato della stringa ipertestuale non corretto!")
                    Return False
                Else
                    hh.Add(s(0))
                End If
            Next
        End If

        For Each sh As String In hh
            If Not hyp.Contains(sh) Then
                MsgBox("Il formato della stringa ipertestuale non il marcatore {" + sh + "}!")
                Return False
            End If
        Next

        Return True

    End Function

    Private Sub btnEsegui_Click(sender As Object, e As EventArgs) Handles btnEsegui.Click

        Dim c As List(Of Colonna) = Colonne.Get
        Dim c1 As List(Of Integer) = c.Select(Function(x) x.colFile1).ToList
        Dim c2 As List(Of Integer) = c.Select(Function(x) x.colFile2).ToList
        Dim content As List(Of String)

        ' ... itera tra le sottocartelle
        For Each d As String In IO.Directory.GetDirectories(My.Settings.RootFolderFase2)
            ' ...
            Dim i As Integer = 1
            ' ... itera tra i file csv
            For Each f As String In IO.Directory.GetFiles(d, "*.csv")
                ' ... gestione file csv
                Dim cv As New CSVgest(f, True, My.Settings.SeparatoreCsv)
                ' ... estrae le colonne
                content = New List(Of String)
                Select Case i
                    Case 1
                        content = cv.EstraiColonne(c1)
                    Case 2
                        content = cv.EstraiColonne(c2)
                    Case Else
                        Continue For
                End Select
                ' ... aggiunge colonne
                If content.Count > 0 Then
                    ' ... aggiunge la colonna con il nome del file
                    content = cv.AggiungiColonna(content, "File", IO.Path.GetFileName(f))
                    ' ... aggiunge colonna iperlink
                    content = cv.AggiungiColonna(content, "Hyperlink", cv.CreaHyperlink(My.Settings.HyperLink, i, c))
                    ' ... nome file xls
                    Dim nomeFileXls As String = IO.Path.Combine(IO.Path.GetDirectoryName(f), IO.Path.GetFileNameWithoutExtension(f) + ".xlsx")
                    ' ... crea file xls
                    Excel.CreaXls(content, nomeFileXls, My.Settings.SeparatoreCsv)
                End If
            Next
        Next

    End Sub

    Private Sub btnScegli_Click(sender As Object, e As EventArgs) Handles btnScegli.Click

        If fbd.ShowDialog = DialogResult.OK Then

            My.Settings.RootFolderFase2 = fbd.SelectedPath
            My.Settings.Save()
            Me.txtFolderFase2.Text = fbd.SelectedPath

        End If

    End Sub

    Private Sub cboSeparatore_SelectedIndexChanged(sender As Object, e As EventArgs)
        My.Settings.SeparatoreCsv = CChar(cboSeparatore.SelectedValue)
        My.Settings.Save()
    End Sub

    Private Sub txtHyperlink_LostFocus(sender As Object, e As EventArgs) Handles txtHyperlink.LostFocus
        My.Settings.HyperLink = txtHyperlink.Text
        My.Settings.Save()
    End Sub

End Class