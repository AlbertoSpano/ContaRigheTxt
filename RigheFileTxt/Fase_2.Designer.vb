<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Fase_2
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
        Me.btnScegli = New System.Windows.Forms.Button()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.grdColonne = New System.Windows.Forms.DataGridView()
        Me.File1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.File2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hyperlink = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtHyperlink = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEsegui = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.grdColonne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnScegli
        '
        Me.btnScegli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(774, 51)
        Me.btnScegli.Margin = New System.Windows.Forms.Padding(4)
        Me.btnScegli.Name = "btnScegli"
        Me.btnScegli.Size = New System.Drawing.Size(136, 30)
        Me.btnScegli.TabIndex = 15
        Me.btnScegli.Text = "Scegli cartella ..."
        Me.btnScegli.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFolder.Location = New System.Drawing.Point(15, 55)
        Me.txtFolder.MaxLength = 12
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(752, 22)
        Me.txtFolder.TabIndex = 14
        Me.txtFolder.TabStop = False
        '
        'grdColonne
        '
        Me.grdColonne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdColonne.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.File1, Me.File2, Me.Hyperlink})
        Me.grdColonne.Location = New System.Drawing.Point(12, 85)
        Me.grdColonne.Name = "grdColonne"
        Me.grdColonne.Size = New System.Drawing.Size(409, 209)
        Me.grdColonne.TabIndex = 16
        '
        'File1
        '
        Me.File1.DataPropertyName = "colFile1"
        Me.File1.HeaderText = "Colonne File 1"
        Me.File1.Name = "File1"
        Me.File1.Width = 120
        '
        'File2
        '
        Me.File2.DataPropertyName = "colFile2"
        Me.File2.HeaderText = "Colonne File 2"
        Me.File2.Name = "File2"
        Me.File2.Width = 120
        '
        'Hyperlink
        '
        Me.Hyperlink.DataPropertyName = "Hyperlink"
        Me.Hyperlink.HeaderText = "Hyperlink"
        Me.Hyperlink.MaxInputLength = 5
        Me.Hyperlink.Name = "Hyperlink"
        '
        'txtHyperlink
        '
        Me.txtHyperlink.Location = New System.Drawing.Point(12, 335)
        Me.txtHyperlink.Name = "txtHyperlink"
        Me.txtHyperlink.Size = New System.Drawing.Size(531, 22)
        Me.txtHyperlink.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Formato collegamento ipertestuale:"
        '
        'btnEsegui
        '
        Me.btnEsegui.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEsegui.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEsegui.Location = New System.Drawing.Point(774, 89)
        Me.btnEsegui.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEsegui.Name = "btnEsegui"
        Me.btnEsegui.Size = New System.Drawing.Size(136, 30)
        Me.btnEsegui.TabIndex = 20
        Me.btnEsegui.Text = "Esegui ..."
        Me.btnEsegui.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(507, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Genera file xls da file csv con inserimento collegamento ipertestuale"
        '
        'Fase_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 444)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEsegui)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHyperlink)
        Me.Controls.Add(Me.grdColonne)
        Me.Controls.Add(Me.btnScegli)
        Me.Controls.Add(Me.txtFolder)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Fase_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fase 2"
        CType(Me.grdColonne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnScegli As Button
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents fbd As FolderBrowserDialog
    Friend WithEvents grdColonne As DataGridView
    Friend WithEvents txtHyperlink As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents File1 As DataGridViewTextBoxColumn
    Friend WithEvents File2 As DataGridViewTextBoxColumn
    Friend WithEvents Hyperlink As DataGridViewTextBoxColumn
    Friend WithEvents btnEsegui As Button
    Friend WithEvents Label2 As Label
End Class
