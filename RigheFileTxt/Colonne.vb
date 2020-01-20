Imports Newtonsoft.Json

Public Class Colonna

    Public Property colFile1 As Integer
    Public Property colFile2 As Integer
    Public Property hyperLink As Object

End Class


Public Class Colonne

    Public Shared Function [Get]() As List(Of Colonna)

        Dim ret As List(Of Colonna) = JsonConvert.DeserializeObject(Of List(Of Colonna))(My.Settings.Colonne)

        If ret Is Nothing Then Return New List(Of Colonna) Else Return ret

    End Function

    Public Shared Sub [Set](c As List(Of Colonna))

        My.Settings.Colonne = JsonConvert.SerializeObject(c)

    End Sub

End Class
