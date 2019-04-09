Public Class FileTxt



    Private Sub btnScegli_Click(sender As Object, e As EventArgs) Handles btnScegli.Click

        Dim ext As String = Me.txtEstensione.Text
        ext = ext.TrimStart("*"c)

        ext = If(ext.StartsWith("."), "", ".") + ext

        My.Settings.Estensione = ext
        My.Settings.Save()

        Me.OpenFileDialog1.DefaultExt = ext
        Me.OpenFileDialog1.FileName = "*" + ext
        Me.OpenFileDialog1.Filter = String.Format("File (*{0})|{0}", ext)

        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then

            Me.grdFiles.Rows.Clear()

            For Each f As String In Me.OpenFileDialog1.FileNames
                Me.grdFiles.Rows.Add(IO.Path.GetFileName(f), IO.File.ReadAllLines(f).Count, f)
            Next

            Me.btnEsporta.Enabled = grdFiles.Rows.Count > 0

        End If

    End Sub

    Private Sub btnEsporta_Click(sender As Object, e As EventArgs) Handles btnEsporta.Click

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim ftmp As String = IO.Path.Combine(System.IO.Path.GetTempPath(), IO.Path.GetRandomFileName + ".csv")

            Dim result As New List(Of String)
            result.Add(String.Format("{0}{1}{2}{1}{3}", "Nome file", vbTab, "Righe", "Percorso completo"))

            For Each d As DataGridViewRow In grdFiles.Rows
                result.Add(String.Format("{0}{1}{2}{1}{3}", d.Cells(0).Value, vbTab, d.Cells(1).Value, d.Cells(2).Value))
            Next

            IO.File.WriteAllLines(ftmp, result.ToArray)

            System.Diagnostics.Process.Start(ftmp)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FileTxt_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.txtEstensione.Text = My.Settings.Estensione

    End Sub

End Class
