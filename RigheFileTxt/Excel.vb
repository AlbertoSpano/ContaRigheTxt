Imports System.IO
Imports System.Runtime.CompilerServices
Imports OfficeOpenXml
Imports OfficeOpenXml.Table

Public Module Excel

    <Extension()>
    Public Function ConvertTableToObjects(Of T As Class)(ByVal table As ExcelTable) As IEnumerable(Of T)
        Dim convertDateTime = New Func(Of Double, DateTime)(Function(excelDate)
                                                                If excelDate < 1 Then Throw New ArgumentException("Excel dates cannot be smaller than 0.")
                                                                Dim dateOfReference = New DateTime(1900, 1, 1)

                                                                If excelDate > 60.0R Then
                                                                    excelDate = excelDate - 2
                                                                Else
                                                                    excelDate = excelDate - 1
                                                                End If

                                                                Return dateOfReference.AddDays(excelDate)
                                                            End Function)
        Dim tprops = Activator.CreateInstance(Of T).[GetType].GetProperties.ToList
        Dim start = table.Address.Start
        Dim [end] = table.Address.[End]
        Dim cells = New List(Of ExcelRangeBase)()

        For r = start.Row To [end].Row
            For c = start.Column To [end].Column
                cells.Add(table.WorkSheet.Cells(r, c))
            Next
        Next

        Dim groups = cells.GroupBy(Function(cell) cell.Start.Row).ToList()
        Dim types = groups.Skip(1).First().Select(Function(rcell) rcell.Value.[GetType]()).ToList()
        Dim colnames = groups.First().Select(Function(hcell, idx) New With {Key .Name = hcell.Value.ToString(), Key .index = idx}).Where(Function(o) tprops.[Select](Function(p) p.Name).Contains(o.Name)).ToList()
        Dim rowvalues = groups.Skip(1).[Select](Function(cg) cg.[Select](Function(c) c.Value).ToList())
        Dim collection = rowvalues.[Select](Function(row)
                                                Dim tnew = Activator.CreateInstance(Of T)
                                                colnames.ForEach(Function(colname) As Boolean

                                                                     Dim val = row(colname.index)
                                                                     Dim type = types(colname.index)
                                                                     Dim prop = tprops.First(Function(p) p.Name = colname.Name)

                                                                     If type = GetType(Double) Then

                                                                         If Not String.IsNullOrWhiteSpace(val?.ToString()) Then
                                                                             Dim unboxedVal = CDbl(val)

                                                                             If prop.PropertyType = GetType(Int32) Then
                                                                                 prop.SetValue(tnew, CInt(unboxedVal), Nothing)
                                                                             ElseIf prop.PropertyType = GetType(Double) Then
                                                                                 prop.SetValue(tnew, unboxedVal, Nothing)
                                                                             ElseIf prop.PropertyType = GetType(DateTime) Then
                                                                                 prop.SetValue(tnew, convertDateTime(unboxedVal), Nothing)
                                                                             Else
                                                                                 Throw New NotImplementedException(String.Format("Type '{0}' not implemented yet!", prop.PropertyType.Name))
                                                                             End If
                                                                         End If

                                                                     Else
                                                                         prop.SetValue(tnew, val, Nothing)
                                                                     End If

                                                                     Return True

                                                                 End Function)
                                                Return tnew
                                            End Function)
        Return collection
    End Function

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

End Module
