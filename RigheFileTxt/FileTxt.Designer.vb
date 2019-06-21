<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileTxt
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdFiles = New System.Windows.Forms.DataGridView()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Righe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnScegli = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnEsporta = New System.Windows.Forms.Button()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrefisso = New System.Windows.Forms.TextBox()
        Me.rbSingolo = New System.Windows.Forms.RadioButton()
        Me.rbPercorsoCartella = New System.Windows.Forms.RadioButton()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.grpOrario = New System.Windows.Forms.GroupBox()
        Me.chkAlle = New System.Windows.Forms.CheckBox()
        Me.chkDalle = New System.Windows.Forms.CheckBox()
        Me.txtAlle = New System.Windows.Forms.DateTimePicker()
        Me.txtDalle = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCartellaExport = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkRinomina = New System.Windows.Forms.CheckBox()
        Me.rbCreati = New System.Windows.Forms.RadioButton()
        Me.rbModificati = New System.Windows.Forms.RadioButton()
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrario.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdFiles
        '
        Me.grdFiles.AllowUserToAddRows = False
        Me.grdFiles.AllowUserToDeleteRows = False
        Me.grdFiles.AllowUserToResizeRows = False
        Me.grdFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.NomeFile, Me.FullPath, Me.Righe})
        Me.grdFiles.Location = New System.Drawing.Point(32, 214)
        Me.grdFiles.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFiles.MultiSelect = False
        Me.grdFiles.Name = "grdFiles"
        Me.grdFiles.ReadOnly = True
        Me.grdFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiles.Size = New System.Drawing.Size(926, 292)
        Me.grdFiles.TabIndex = 0
        '
        'Numero
        '
        Me.Numero.HeaderText = "#"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 60
        '
        'NomeFile
        '
        Me.NomeFile.HeaderText = "Cartella"
        Me.NomeFile.Name = "NomeFile"
        Me.NomeFile.ReadOnly = True
        Me.NomeFile.Width = 500
        '
        'FullPath
        '
        Me.FullPath.HeaderText = "Nome file"
        Me.FullPath.Name = "FullPath"
        Me.FullPath.ReadOnly = True
        Me.FullPath.Width = 200
        '
        'Righe
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N"
        Me.Righe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Righe.HeaderText = "Righe"
        Me.Righe.Name = "Righe"
        Me.Righe.ReadOnly = True
        '
        'btnScegli
        '
        Me.btnScegli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(803, 30)
        Me.btnScegli.Margin = New System.Windows.Forms.Padding(4)
        Me.btnScegli.Name = "btnScegli"
        Me.btnScegli.Size = New System.Drawing.Size(154, 30)
        Me.btnScegli.TabIndex = 1
        Me.btnScegli.Text = "Scegli ..."
        Me.btnScegli.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtro nome file:"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(141, 27)
        Me.txtFiltro.MaxLength = 12
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(130, 23)
        Me.txtFiltro.TabIndex = 3
        Me.txtFiltro.Text = ".txt"
        '
        'btnEsporta
        '
        Me.btnEsporta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEsporta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEsporta.Enabled = False
        Me.btnEsporta.Location = New System.Drawing.Point(804, 144)
        Me.btnEsporta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(154, 30)
        Me.btnEsporta.TabIndex = 4
        Me.btnEsporta.Text = "Esporta elenco"
        Me.btnEsporta.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFolder.Location = New System.Drawing.Point(32, 184)
        Me.txtFolder.MaxLength = 12
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(925, 23)
        Me.txtFolder.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Prefisso nomi numerici:"
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Location = New System.Drawing.Point(205, 67)
        Me.txtPrefisso.MaxLength = 1
        Me.txtPrefisso.Name = "txtPrefisso"
        Me.txtPrefisso.Size = New System.Drawing.Size(66, 23)
        Me.txtPrefisso.TabIndex = 8
        Me.txtPrefisso.Text = "L"
        Me.txtPrefisso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rbSingolo
        '
        Me.rbSingolo.AutoSize = True
        Me.rbSingolo.Location = New System.Drawing.Point(299, 26)
        Me.rbSingolo.Name = "rbSingolo"
        Me.rbSingolo.Size = New System.Drawing.Size(157, 21)
        Me.rbSingolo.TabIndex = 9
        Me.rbSingolo.Text = "Totali per singolo file"
        Me.rbSingolo.UseVisualStyleBackColor = True
        '
        'rbPercorsoCartella
        '
        Me.rbPercorsoCartella.AutoSize = True
        Me.rbPercorsoCartella.Checked = True
        Me.rbPercorsoCartella.Location = New System.Drawing.Point(299, 54)
        Me.rbPercorsoCartella.Name = "rbPercorsoCartella"
        Me.rbPercorsoCartella.Size = New System.Drawing.Size(198, 21)
        Me.rbPercorsoCartella.TabIndex = 10
        Me.rbPercorsoCartella.TabStop = True
        Me.rbPercorsoCartella.Text = "Totali per percorso cartella"
        Me.rbPercorsoCartella.UseVisualStyleBackColor = True
        '
        'bw
        '
        '
        'grpOrario
        '
        Me.grpOrario.Controls.Add(Me.rbModificati)
        Me.grpOrario.Controls.Add(Me.rbCreati)
        Me.grpOrario.Controls.Add(Me.chkAlle)
        Me.grpOrario.Controls.Add(Me.chkDalle)
        Me.grpOrario.Controls.Add(Me.txtAlle)
        Me.grpOrario.Controls.Add(Me.txtDalle)
        Me.grpOrario.Controls.Add(Me.Label4)
        Me.grpOrario.Controls.Add(Me.Label3)
        Me.grpOrario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpOrario.Location = New System.Drawing.Point(520, 26)
        Me.grpOrario.Name = "grpOrario"
        Me.grpOrario.Size = New System.Drawing.Size(276, 121)
        Me.grpOrario.TabIndex = 12
        Me.grpOrario.TabStop = False
        Me.grpOrario.Text = "Solo file creati/modificati nella fascia:"
        '
        'chkAlle
        '
        Me.chkAlle.AutoSize = True
        Me.chkAlle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAlle.Location = New System.Drawing.Point(100, 93)
        Me.chkAlle.Name = "chkAlle"
        Me.chkAlle.Size = New System.Drawing.Size(15, 14)
        Me.chkAlle.TabIndex = 8
        Me.chkAlle.UseVisualStyleBackColor = True
        '
        'chkDalle
        '
        Me.chkDalle.AutoSize = True
        Me.chkDalle.Checked = True
        Me.chkDalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDalle.Location = New System.Drawing.Point(100, 59)
        Me.chkDalle.Name = "chkDalle"
        Me.chkDalle.Size = New System.Drawing.Size(15, 14)
        Me.chkDalle.TabIndex = 7
        Me.chkDalle.UseVisualStyleBackColor = True
        '
        'txtAlle
        '
        Me.txtAlle.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtAlle.Location = New System.Drawing.Point(147, 86)
        Me.txtAlle.Name = "txtAlle"
        Me.txtAlle.ShowUpDown = True
        Me.txtAlle.Size = New System.Drawing.Size(88, 23)
        Me.txtAlle.TabIndex = 6
        Me.txtAlle.Value = New Date(2019, 4, 18, 23, 59, 0, 0)
        Me.txtAlle.Visible = False
        '
        'txtDalle
        '
        Me.txtDalle.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtDalle.Location = New System.Drawing.Point(147, 54)
        Me.txtDalle.Name = "txtDalle"
        Me.txtDalle.ShowUpDown = True
        Me.txtDalle.Size = New System.Drawing.Size(88, 23)
        Me.txtDalle.TabIndex = 5
        Me.txtDalle.Value = New Date(2019, 4, 18, 11, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "alle ore:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "dalle ore:"
        '
        'cboCartellaExport
        '
        Me.cboCartellaExport.FormattingEnabled = True
        Me.cboCartellaExport.Items.AddRange(New Object() {"... chiedi", "Documenti", "Download", "Temp", "Desktop"})
        Me.cboCartellaExport.Location = New System.Drawing.Point(145, 153)
        Me.cboCartellaExport.Name = "cboCartellaExport"
        Me.cboCartellaExport.Size = New System.Drawing.Size(352, 25)
        Me.cboCartellaExport.TabIndex = 13
        Me.cboCartellaExport.Text = "... chiedi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Cartella export:"
        '
        'chkRinomina
        '
        Me.chkRinomina.AutoSize = True
        Me.chkRinomina.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRinomina.Checked = True
        Me.chkRinomina.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRinomina.Location = New System.Drawing.Point(32, 112)
        Me.chkRinomina.Name = "chkRinomina"
        Me.chkRinomina.Size = New System.Drawing.Size(323, 21)
        Me.chkRinomina.TabIndex = 15
        Me.chkRinomina.Text = "Rinomina cartelle con aggiunta numero righe"
        Me.chkRinomina.UseVisualStyleBackColor = True
        '
        'rbCreati
        '
        Me.rbCreati.AutoSize = True
        Me.rbCreati.Location = New System.Drawing.Point(27, 28)
        Me.rbCreati.Name = "rbCreati"
        Me.rbCreati.Size = New System.Drawing.Size(63, 21)
        Me.rbCreati.TabIndex = 9
        Me.rbCreati.Text = "creati"
        Me.rbCreati.UseVisualStyleBackColor = True
        '
        'rbModificati
        '
        Me.rbModificati.AutoSize = True
        Me.rbModificati.Checked = True
        Me.rbModificati.Location = New System.Drawing.Point(100, 28)
        Me.rbModificati.Name = "rbModificati"
        Me.rbModificati.Size = New System.Drawing.Size(92, 21)
        Me.rbModificati.TabIndex = 10
        Me.rbModificati.TabStop = True
        Me.rbModificati.Text = "modificati"
        Me.rbModificati.UseVisualStyleBackColor = True
        '
        'FileTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 525)
        Me.Controls.Add(Me.chkRinomina)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboCartellaExport)
        Me.Controls.Add(Me.grpOrario)
        Me.Controls.Add(Me.rbPercorsoCartella)
        Me.Controls.Add(Me.rbSingolo)
        Me.Controls.Add(Me.txtPrefisso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFolder)
        Me.Controls.Add(Me.btnEsporta)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnScegli)
        Me.Controls.Add(Me.grdFiles)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(600, 300)
        Me.Name = "FileTxt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File txt"
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrario.ResumeLayout(False)
        Me.grpOrario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdFiles As DataGridView
    Friend WithEvents btnScegli As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnEsporta As Button
    Friend WithEvents fbd As FolderBrowserDialog
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrefisso As TextBox
    Friend WithEvents rbSingolo As RadioButton
    Friend WithEvents rbPercorsoCartella As RadioButton
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents grpOrario As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDalle As DateTimePicker
    Friend WithEvents txtAlle As DateTimePicker
    Friend WithEvents chkAlle As CheckBox
    Friend WithEvents chkDalle As CheckBox
    Friend WithEvents cboCartellaExport As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkRinomina As CheckBox
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents NomeFile As DataGridViewTextBoxColumn
    Friend WithEvents FullPath As DataGridViewTextBoxColumn
    Friend WithEvents Righe As DataGridViewTextBoxColumn
    Friend WithEvents rbModificati As RadioButton
    Friend WithEvents rbCreati As RadioButton
End Class
