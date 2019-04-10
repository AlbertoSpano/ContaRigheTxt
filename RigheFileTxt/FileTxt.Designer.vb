<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileTxt
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdFiles = New System.Windows.Forms.DataGridView()
        Me.NomeFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Righe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnScegli = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnEsporta = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.chkGroup = New System.Windows.Forms.CheckBox()
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grdFiles.Location = New System.Drawing.Point(32, 123)
        Me.grdFiles.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFiles.Name = "grdFiles"
        Me.grdFiles.ReadOnly = True
        Me.grdFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiles.Size = New System.Drawing.Size(865, 383)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Righe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Righe.HeaderText = "Righe"
        Me.Righe.Name = "Righe"
        Me.Righe.ReadOnly = True
        '
        'btnScegli
        '
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(516, 26)
        Me.btnScegli.Margin = New System.Windows.Forms.Padding(4)
        Me.btnScegli.Name = "btnScegli"
        Me.btnScegli.Size = New System.Drawing.Size(186, 30)
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
        Me.btnEsporta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEsporta.Enabled = False
        Me.btnEsporta.Location = New System.Drawing.Point(710, 26)
        Me.btnEsporta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(186, 30)
        Me.btnEsporta.TabIndex = 4
        Me.btnEsporta.Text = "Esporta elenco"
        Me.btnEsporta.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFolder.Location = New System.Drawing.Point(32, 93)
        Me.txtFolder.MaxLength = 12
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(864, 23)
        Me.txtFolder.TabIndex = 5
        '
        'chkGroup
        '
        Me.chkGroup.AutoSize = True
        Me.chkGroup.Checked = True
        Me.chkGroup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkGroup.Location = New System.Drawing.Point(301, 29)
        Me.chkGroup.Name = "chkGroup"
        Me.chkGroup.Size = New System.Drawing.Size(139, 21)
        Me.chkGroup.TabIndex = 6
        Me.chkGroup.Text = "totali per cartella"
        Me.chkGroup.UseVisualStyleBackColor = True
        '
        'FileTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 525)
        Me.Controls.Add(Me.chkGroup)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdFiles As DataGridView
    Friend WithEvents btnScegli As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnEsporta As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents NomeFile As DataGridViewTextBoxColumn
    Friend WithEvents FullPath As DataGridViewTextBoxColumn
    Friend WithEvents Righe As DataGridViewTextBoxColumn
    Friend WithEvents chkGroup As CheckBox
End Class
