Imports System.ComponentModel

Public Class Fase_2

    Private Sub Fase_2_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        If Not Valida(source, txtHyperlink.Text) Then Return

        Colonne.Set(source)

        My.Settings.HyperLink = txtHyperlink.Text

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

    End Sub

End Class