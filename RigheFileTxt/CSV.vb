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
            righe = IO.File.ReadLines(fullPath, System.Text.Encoding.GetEncoding("Windows-1252")).ToList
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

    Public Function CreaHyperlink(pattern As String, index As Integer, c As List(Of Colonna)) As List(Of String)

        Dim s As New List(Of String)
        Dim ch As List(Of Colonna)
        ch = c.Where(Function(x) x.hyperLink IsNot Nothing).ToList

        For i As Integer = startRow To righe.Count - 1
            Dim riga As String() = righe(i).Split(separatore)
            Dim sRiga As String = pattern
            For j As Integer = 0 To ch.Count - 1
                Dim r As String = If(index = 1, riga(ch(j).colFile1 - 1), riga(ch(j).colFile2 - 1)).Replace("/", "")
                Dim marcatore As String = "{" + ch(j).hyperLink.ToString + "}"
                sRiga = sRiga.Replace(marcatore, r)
            Next
            s.Add(sRiga)
        Next

        Return s

    End Function

    Public Function EstraiColonne(cols As List(Of Integer), escludiPrimaRiga As Boolean) As List(Of String)

        Dim s As New List(Of String)

        For i As Integer = If(escludiPrimaRiga, 1, 0) To righe.Count - 1
            Dim riga As String() = righe(i).Split(separatore)
            Dim sRiga As String = String.Empty
            For j As Integer = 0 To cols.Count - 1
                Dim r As String = If(cols(j) = 0, String.Empty, riga(cols(j) - 1))
                If IsDate(r) Then r = String.Format("'{0}", r)
                sRiga += If(sRiga.Length = 0, "", separatore) + r
            Next
            s.Add(sRiga)
        Next

        Return s

    End Function

    Public Function AggiungiColonna(righe As List(Of String), valore As String, Optional intestazione As String = Nothing) As List(Of String)

        Dim start As Integer = 0
        If intestazione IsNot Nothing Then
            start = 1
            righe(0) = righe(0) + separatore + intestazione
        End If

        For i As Integer = start To righe.Count - 1
            righe(i) = righe(i) + separatore + valore
        Next

        Return righe

    End Function

    Public Function AggiungiColonna(righe As List(Of String), valori As List(Of String), Optional intestazione As String = Nothing) As List(Of String)

        Dim start As Integer = 0
        If intestazione IsNot Nothing Then
            start = 1
            righe(0) = righe(0) + separatore + intestazione
        End If

        For i As Integer = start To righe.Count - 1
            righe(i) = righe(i) + separatore + valori(i - start)
        Next

        Return righe

    End Function

    Public Shared Function EliminaRighe(newFile As String, elencoRigheDaEliminare As List(Of Integer), startCod As Integer, lungCod As Integer) As Info

        Dim r As New List(Of String)

        Using sr As New IO.StreamReader(newFile)
            While sr.Peek > -1
                r.Add(sr.ReadLine)
            End While
        End Using

        Dim righeRimaste As IEnumerable(Of String) = r.Where(Function(x) Not elencoRigheDaEliminare.Contains(CInt(x.Substring(startCod, lungCod))))

        IO.File.WriteAllLines(newFile, righeRimaste)

        Return New Info With {.NumeroRigheOld = r.Count, .NumeroRigheNew = righeRimaste.Count}

    End Function

End Class

Public Class Separatore
    Public Property Carattere As Char
    Public Property Descrizione As String
End Class
