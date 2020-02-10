Imports System.IO
Imports System.Runtime.CompilerServices
Imports OfficeOpenXml
Imports OfficeOpenXml.Table

Public Module Excel

    Public Sub CreaXls(sourceCsvPath As String, destXlsPath As String, separatore As Char)

        ' ... crea file di excel
        Using ex As New OfficeOpenXml.ExcelPackage(New IO.FileInfo(destXlsPath))

            Dim ExcelTextFormat As New ExcelTextFormat()

            ExcelTextFormat.Delimiter = separatore

            Dim worksheet As ExcelWorksheet = ex.Workbook.Worksheets.Add("Foglio 1")

            worksheet.Cells("A1").LoadFromText(New IO.FileInfo(sourceCsvPath), ExcelTextFormat, OfficeOpenXml.Table.TableStyles.Light9, True)

            worksheet.Cells(worksheet.Dimension.Address).AutoFitColumns()

            ex.Save()

        End Using

    End Sub

    Public Sub CreaXls(source As List(Of String), destXlsPath As String, separatore As Char)

        Dim tmpFile As String = IO.Path.GetTempFileName
        IO.File.WriteAllLines(tmpFile, source)

        CreaXls(tmpFile, destXlsPath, separatore)

    End Sub

    Public Function LeggiFileXls(filePath As String, intestazione As Boolean) As List(Of Integer)

        Dim ret As New List(Of Integer)

        If IO.File.Exists(filePath) Then

            Dim fi = New FileInfo(filePath)

            Using package = New ExcelPackage(fi)
                Dim workbook As ExcelWorkbook = package.Workbook
                Dim worksheet As ExcelWorksheet = workbook.Worksheets.First()
                Dim inizio As ExcelCellAddress = worksheet.Dimension.Start
                Dim fine As ExcelCellAddress = worksheet.Dimension.End
                For i As Integer = inizio.Row To fine.Row
                    If intestazione And i = 1 Then Continue For
                    ret.Add(CInt(worksheet.Cells(i, 1).Text))
                Next
            End Using

        End If

        Return ret

    End Function

    Public Sub AggiungiHyperLink(nomeFile As String, colIndex As Integer)

        Using ex As New OfficeOpenXml.ExcelPackage(New IO.FileInfo(nomeFile))
            Dim w As ExcelWorksheet = ex.Workbook.Worksheets(1)
            w.Column(colIndex).Hidden = True
            For rowINdex As Integer = 2 To w.Dimension.End.Row
                w.Cells(rowINdex, colIndex + 1).FormulaR1C1 = String.Format("=HYPERLINK(RC[-1],""Link"")")
            Next
            ex.Save()
        End Using
    End Sub

End Module
