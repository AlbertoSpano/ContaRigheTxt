﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.grdFiles = New System.Windows.Forms.DataGridView()
        Me.btnScegli = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstensione = New System.Windows.Forms.TextBox()
        Me.NomeFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Righe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEsporta = New System.Windows.Forms.Button()
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "txt"
        Me.OpenFileDialog1.FileName = "*.txt"
        Me.OpenFileDialog1.Filter = "File txt|*.txt"
        Me.OpenFileDialog1.Multiselect = True
        '
        'grdFiles
        '
        Me.grdFiles.AllowUserToAddRows = False
        Me.grdFiles.AllowUserToDeleteRows = False
        Me.grdFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeFile, Me.Righe, Me.FullPath})
        Me.grdFiles.Location = New System.Drawing.Point(337, 44)
        Me.grdFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdFiles.Name = "grdFiles"
        Me.grdFiles.ReadOnly = True
        Me.grdFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiles.Size = New System.Drawing.Size(572, 462)
        Me.grdFiles.TabIndex = 0
        '
        'btnScegli
        '
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(29, 84)
        Me.btnScegli.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnScegli.Name = "btnScegli"
        Me.btnScegli.Size = New System.Drawing.Size(259, 30)
        Me.btnScegli.TabIndex = 1
        Me.btnScegli.Text = "Scegli ..."
        Me.btnScegli.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Estensione file:"
        '
        'txtEstensione
        '
        Me.txtEstensione.Location = New System.Drawing.Point(158, 44)
        Me.txtEstensione.MaxLength = 6
        Me.txtEstensione.Name = "txtEstensione"
        Me.txtEstensione.Size = New System.Drawing.Size(130, 23)
        Me.txtEstensione.TabIndex = 3
        Me.txtEstensione.Text = ".txt"
        '
        'NomeFile
        '
        Me.NomeFile.HeaderText = "Nome file"
        Me.NomeFile.Name = "NomeFile"
        Me.NomeFile.ReadOnly = True
        Me.NomeFile.Width = 400
        '
        'Righe
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Righe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Righe.HeaderText = "Righe"
        Me.Righe.Name = "Righe"
        Me.Righe.ReadOnly = True
        '
        'FullPath
        '
        Me.FullPath.HeaderText = "FullPath"
        Me.FullPath.Name = "FullPath"
        Me.FullPath.ReadOnly = True
        Me.FullPath.Visible = False
        '
        'btnEsporta
        '
        Me.btnEsporta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEsporta.Enabled = False
        Me.btnEsporta.Location = New System.Drawing.Point(29, 134)
        Me.btnEsporta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(259, 30)
        Me.btnEsporta.TabIndex = 4
        Me.btnEsporta.Text = "Esporta elenco"
        Me.btnEsporta.UseVisualStyleBackColor = True
        '
        'FileTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 525)
        Me.Controls.Add(Me.btnEsporta)
        Me.Controls.Add(Me.txtEstensione)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnScegli)
        Me.Controls.Add(Me.grdFiles)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(600, 300)
        Me.Name = "FileTxt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File txt"
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents grdFiles As DataGridView
    Friend WithEvents btnScegli As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEstensione As TextBox
    Friend WithEvents NomeFile As DataGridViewTextBoxColumn
    Friend WithEvents Righe As DataGridViewTextBoxColumn
    Friend WithEvents FullPath As DataGridViewTextBoxColumn
    Friend WithEvents btnEsporta As Button
End Class
