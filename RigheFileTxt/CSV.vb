Imports System.Text
Imports OfficeOpenXml

Public Class CSVgest

    Private fullPath As String
    Private intestazione As Boolean
    Private separatore As Char
    Private startRow As Integer = 0
    Private errore As Boolean = False
    Private righe As List(Of String)
    Private colonne As String()

    Public Sub New(fullPath As String, intestazione As Boolean, separatore As Char)

        Me.fullPath = fullPath
        Me.intestazione = intestazione
        Me.separatore = separatore
        Me.righe = New List(Of String)
        Me.startRow = If(intestazione, 1, 0)

        If String.IsNullOrEmpty(separatore) Then
            errore = True
            Throw New Exception("Separatore non valido!")
        End If

        If IO.File.Exists(fullPath) Then
            righe = IO.File.ReadLines(fullPath).ToList
            LeggiIntestazione()
        Else
            errore = True
            Throw New Exception(String.Format("File {0} inesistente!", fullPath))
        End If


    End Sub

    Private Sub LeggiIntestazione()

        If intestazione And righe.Count > 0 Then
            colonne = righe(0).Split(separatore)
        End If

    End Sub

    Public Function EstraiColonne(cols As List(Of Integer)) As String

        Dim s As New StringBuilder

        For i As Integer = startRow To righe.Count - 1
            Dim riga As String() = righe(i).Split(separatore)
            Dim sRiga As String = String.Empty
            For j As Integer = 0 To cols.Count - 1
                sRiga += If(sRiga.Length = 0, "", separatore) + riga(cols(j))
            Next
            s.AppendLine(sRiga)
        Next

        Return s.ToString

    End Function

    Public Shared Sub EliminaRighe(newFile As String, elencoRigheDaEliminare As List(Of Integer), startCod As Integer, lungCod As Integer)

        Dim r As New List(Of String)

        Using sr As New IO.StreamReader(newFile)
            While sr.Peek > -1
                r.Add(sr.ReadLine)
            End While
        End Using

        IO.File.WriteAllLines(newFile, r.Where(Function(x) Not elencoRigheDaEliminare.Contains(CInt(x.Substring(startCod, lungCod)))))

    End Sub

End Class
