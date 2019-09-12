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
    Private cartellaParziali As String = "Parziali"
    Private sepNumRighe As Char = "@"c

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

            My.Settings.AccorpaFile = Me.chkAccorpaFile.Checked
            My.Settings.CreaCodiceCiclo = Me.chkCreaCodiceCiclo.Checked
            My.Settings.LunghezzaDxTipoAccorpa = CInt(Me.txtPatternAccorpamento.Text)

            My.Settings.Save()


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
            CreaXls(csv, xls)

            ' ... elimina file csv
            IO.File.Delete(csv)

            ' ... apre il file
            If chkApriFileAlTermine.Checked Then System.Diagnostics.Process.Start(xls)

            ' ... accorpa file
            If chkAccorpaFile.Checked Then AccorpaFile()

            ' ... codice/ciclo
            If chkCreaCodiceCiclo.Checked Then CollegaFileRecursione(destFolder)


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
        Me.chkRinomina.Checked = My.Settings.RinominaConNumeroRighe

        Me.chkAccorpaFile.Checked = My.Settings.AccorpaFile
        Me.txtPatternAccorpamento.Text = My.Settings.LunghezzaDxTipoAccorpa.ToString
        Me.chkCreaCodiceCiclo.Checked = My.Settings.CreaCodiceCiclo

        Me.txtColServpsDa.Text = My.Settings.ColServpsDa.ToString
        Me.txtColServpsA.Text = My.Settings.ColServpsA.ToString
        Me.txtColServpsValoreDa.Text = My.Settings.ColServpaValoreDa.ToString
        Me.txtColServpsValoreA.Text = My.Settings.ColServpaValoreA.ToString

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
                    IO.Directory.Move(f.Cartella, String.Format("{0}{1}{2}", f.Cartella, sepNumRighe, f.Righe))
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

        ' ... se trattasi della cartella parziale continua
        If IO.Path.GetFileName(source) = cartellaParziali Then Return

        If source <> destFolder Then

            ' ... elenco tipi
            Dim tipi As IEnumerable(Of String) = IO.Directory.GetFiles(source).Cast(Of String).GroupBy(Function(x) x.Substring(x.Length - rightNameLengthForAccorpation)).Select(Function(x) x.Key)

            ' ... crea cartella parziali
            Dim pathParziali As String = IO.Path.Combine(source, cartellaParziali)
            If Not IO.Directory.Exists(pathParziali) Then IO.Directory.CreateDirectory(pathParziali)

            For Each t As String In tipi
                Dim content As String = String.Empty
                For Each f As String In IO.Directory.GetFiles(source, "*" + t)
                    ' ... unisce contenuto file
                    content += IO.File.ReadAllText(f)
                    ' ... sposta il file nella cartella Parziali
                    IO.File.Move(f, IO.Path.Combine(pathParziali, IO.Path.GetFileName(f)))
                Next
                If content.Length > 0 Then
                    ' ... crea nuovo file con contenuto unito
                    Dim newFile As String = NomeFileAccorpato(source, t)
                    IO.File.WriteAllText(newFile, content)
                End If
            Next

        End If

        ' ... avvia la ricorsione
        For Each d As String In IO.Directory.GetDirectories(source, "*", IO.SearchOption.AllDirectories)
            AccorpaFileRecursione(d)
        Next

    End Sub

    Private Function NomeFileAccorpato(source As String, tipo As String) As String
        Return IO.Path.Combine(source, String.Format("{0}_{1}", IO.Path.GetFileName(source), tipo))
    End Function

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

    Private Sub tabSettings_Click(sender As Object, e As EventArgs) Handles tabSettings.Click
        If tabSettings.Height < 270 Then
            tabSettings.Height = 270
            lnkToggleSettings.Text = "Nascondi opzioni"
        End If
    End Sub

    Private Sub btnCollega_Click(sender As Object, e As EventArgs)

        If Not IsNumeric(Me.txtColServpsDa.Text) Then
            MsgBox("Campo non numerico!", MsgBoxStyle.Critical)
            Me.txtColServpsDa.Focus()
            Return
        End If

        If Not IsNumeric(Me.txtColServpsA.Text) Then
            MsgBox("Campo non numerico!", MsgBoxStyle.Critical)
            Me.txtColServpsA.Focus()
            Return
        End If

        If Not IsNumeric(Me.txtColServpsValoreDa.Text) Then
            MsgBox("Campo non numerico!", MsgBoxStyle.Critical)
            Me.txtColServpsValoreDa.Focus()
            Return
        End If

        If Not IsNumeric(Me.txtColServpsValoreA.Text) Then
            MsgBox("Campo non numerico!", MsgBoxStyle.Critical)
            Me.txtColServpsValoreA.Focus()
            Return
        End If

        My.Settings.ColServpsDa = CInt(Me.txtColServpsDa.Text)
        My.Settings.ColServpsA = CInt(Me.txtColServpsA.Text)
        My.Settings.ColServpaValoreDa = CInt(Me.txtColServpsValoreDa.Text)
        My.Settings.ColServpaValoreA = CInt(Me.txtColServpsValoreA.Text)
        My.Settings.Save()

        CollegaFileRecursione(destFolder)

        MsgBox("File creato con successo!")

    End Sub

    Private Sub CollegaFileRecursione(source As String)

        ' ... se trattasi della cartella parziale continua
        If IO.Path.GetFileName(source) = cartellaParziali Then Return

        For Each f As String In IO.Directory.GetFiles(source, "*SERVPS.hst")
            Dim fCodCiclo As String = IO.Path.Combine(destFolder, IO.Path.GetFileName(source).Split(sepNumRighe)(0))
            Dim ret As New List(Of String)
            ret.Add(String.Format("{0}{1}{2}", "Codice", vbTab, "Ciclo"))
            Dim righe As String() = IO.File.ReadAllLines(f)
            For Each riga As String In righe
                If riga.Length >= My.Settings.ColServpsA And riga.Length >= My.Settings.ColServpaValoreA Then
                    Dim cod As String = riga.Substring(My.Settings.ColServpsDa - 1, My.Settings.ColServpsA - My.Settings.ColServpsDa + 1)
                    Dim ciclo As String = riga.Substring(My.Settings.ColServpaValoreDa - 1, My.Settings.ColServpaValoreA - My.Settings.ColServpaValoreDa + 1)
                    If IsNumeric(cod) And IsNumeric(ciclo) Then
                        ret.Add(String.Format("{0}{1}{2}", cod, vbTab, ciclo))
                    End If
                End If
            Next
            IO.File.WriteAllLines(fCodCiclo + ".csv", ret)
            CreaXls(fCodCiclo + ".csv", fCodCiclo + ".xlsx")
            IO.File.Delete(fCodCiclo + ".csv")
        Next

        ' ... avvia la ricorsione
        For Each d As String In IO.Directory.GetDirectories(source, "*", IO.SearchOption.AllDirectories)
            CollegaFileRecursione(d)
        Next

    End Sub

    Private Sub grdFiles_MouseClick(sender As Object, e As MouseEventArgs) Handles grdFiles.MouseClick
        If tabSettings.Height > 28 Then
            tabSettings.Height = 28
            lnkToggleSettings.Text = "Mostra opzioni"
        End If
    End Sub

    Private Sub CreaXls(sourceCsvPath As String, destXlsPath As String)

        ' ... crea file di excel
        Using ex As New OfficeOpenXml.ExcelPackage(New IO.FileInfo(destXlsPath))

            Dim ExcelTextFormat As New ExcelTextFormat()
            ExcelTextFormat.Delimiter = Chr(9)

            Dim worksheet As ExcelWorksheet = ex.Workbook.Worksheets.Add("Foglio 1")

            worksheet.Cells("A1").LoadFromText(New IO.FileInfo(sourceCsvPath), ExcelTextFormat, OfficeOpenXml.Table.TableStyles.Light9, True)

            worksheet.Cells(worksheet.Dimension.Address).AutoFitColumns()

            ex.Save()

        End Using
    End Sub

    Private Sub lnkToggleSettings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkToggleSettings.LinkClicked
        If tabSettings.Height > 28 Then
            tabSettings.Height = 28
            lnkToggleSettings.Text = "Mostra opzioni"
        Else
            tabSettings.Height = 270
            lnkToggleSettings.Text = "Nascondi opzioni"
        End If
    End Sub

End Class

