﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdFiles = New System.Windows.Forms.DataGridView()
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
        Me.rbNomeCartella = New System.Windows.Forms.RadioButton()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.grpOrario = New System.Windows.Forms.GroupBox()
        Me.txtDalle = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAlle = New System.Windows.Forms.DateTimePicker()
        Me.chkDalle = New System.Windows.Forms.CheckBox()
        Me.chkAlle = New System.Windows.Forms.CheckBox()
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
        Me.grdFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeFile, Me.FullPath, Me.Righe})
        Me.grdFiles.Location = New System.Drawing.Point(32, 169)
        Me.grdFiles.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFiles.MultiSelect = False
        Me.grdFiles.Name = "grdFiles"
        Me.grdFiles.ReadOnly = True
        Me.grdFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiles.Size = New System.Drawing.Size(906, 337)
        Me.grdFiles.TabIndex = 0
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N"
        Me.Righe.DefaultCellStyle = DataGridViewCellStyle4
        Me.Righe.HeaderText = "Righe"
        Me.Righe.Name = "Righe"
        Me.Righe.ReadOnly = True
        '
        'btnScegli
        '
        Me.btnScegli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(783, 23)
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
        Me.btnEsporta.Location = New System.Drawing.Point(783, 72)
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
        Me.txtFolder.Location = New System.Drawing.Point(33, 139)
        Me.txtFolder.MaxLength = 12
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(905, 23)
        Me.txtFolder.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Prefisso nomi numerici:"
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Location = New System.Drawing.Point(205, 59)
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
        Me.rbPercorsoCartella.Location = New System.Drawing.Point(299, 54)
        Me.rbPercorsoCartella.Name = "rbPercorsoCartella"
        Me.rbPercorsoCartella.Size = New System.Drawing.Size(198, 21)
        Me.rbPercorsoCartella.TabIndex = 10
        Me.rbPercorsoCartella.Text = "Totali per percorso cartella"
        Me.rbPercorsoCartella.UseVisualStyleBackColor = True
        '
        'rbNomeCartella
        '
        Me.rbNomeCartella.AutoSize = True
        Me.rbNomeCartella.Checked = True
        Me.rbNomeCartella.Location = New System.Drawing.Point(299, 81)
        Me.rbNomeCartella.Name = "rbNomeCartella"
        Me.rbNomeCartella.Size = New System.Drawing.Size(180, 21)
        Me.rbNomeCartella.TabIndex = 11
        Me.rbNomeCartella.TabStop = True
        Me.rbNomeCartella.Text = "Totali per nome cartella"
        Me.rbNomeCartella.UseVisualStyleBackColor = True
        '
        'bw
        '
        '
        'grpOrario
        '
        Me.grpOrario.Controls.Add(Me.chkAlle)
        Me.grpOrario.Controls.Add(Me.chkDalle)
        Me.grpOrario.Controls.Add(Me.txtAlle)
        Me.grpOrario.Controls.Add(Me.txtDalle)
        Me.grpOrario.Controls.Add(Me.Label4)
        Me.grpOrario.Controls.Add(Me.Label3)
        Me.grpOrario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpOrario.Location = New System.Drawing.Point(520, 26)
        Me.grpOrario.Name = "grpOrario"
        Me.grpOrario.Size = New System.Drawing.Size(256, 107)
        Me.grpOrario.TabIndex = 12
        Me.grpOrario.TabStop = False
        Me.grpOrario.Text = "Solo file creati nella fascia:"
        '
        'txtDalle
        '
        Me.txtDalle.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtDalle.Location = New System.Drawing.Point(147, 33)
        Me.txtDalle.Name = "txtDalle"
        Me.txtDalle.ShowUpDown = True
        Me.txtDalle.Size = New System.Drawing.Size(88, 23)
        Me.txtDalle.TabIndex = 5
        Me.txtDalle.Value = New Date(2019, 4, 18, 11, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "alle ore:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "dalle ore:"
        '
        'txtAlle
        '
        Me.txtAlle.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtAlle.Location = New System.Drawing.Point(147, 65)
        Me.txtAlle.Name = "txtAlle"
        Me.txtAlle.ShowUpDown = True
        Me.txtAlle.Size = New System.Drawing.Size(88, 23)
        Me.txtAlle.TabIndex = 6
        Me.txtAlle.Value = New Date(2019, 4, 18, 23, 59, 0, 0)
        Me.txtAlle.Visible = False
        '
        'chkDalle
        '
        Me.chkDalle.AutoSize = True
        Me.chkDalle.Checked = True
        Me.chkDalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDalle.Location = New System.Drawing.Point(100, 38)
        Me.chkDalle.Name = "chkDalle"
        Me.chkDalle.Size = New System.Drawing.Size(15, 14)
        Me.chkDalle.TabIndex = 7
        Me.chkDalle.UseVisualStyleBackColor = True
        '
        'chkAlle
        '
        Me.chkAlle.AutoSize = True
        Me.chkAlle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAlle.Location = New System.Drawing.Point(100, 72)
        Me.chkAlle.Name = "chkAlle"
        Me.chkAlle.Size = New System.Drawing.Size(15, 14)
        Me.chkAlle.TabIndex = 8
        Me.chkAlle.UseVisualStyleBackColor = True
        '
        'FileTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 525)
        Me.Controls.Add(Me.grpOrario)
        Me.Controls.Add(Me.rbNomeCartella)
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
    Friend WithEvents rbNomeCartella As RadioButton
    Friend WithEvents NomeFile As DataGridViewTextBoxColumn
    Friend WithEvents FullPath As DataGridViewTextBoxColumn
    Friend WithEvents Righe As DataGridViewTextBoxColumn
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents grpOrario As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDalle As DateTimePicker
    Friend WithEvents txtAlle As DateTimePicker
    Friend WithEvents chkAlle As CheckBox
    Friend WithEvents chkDalle As CheckBox
End Class
