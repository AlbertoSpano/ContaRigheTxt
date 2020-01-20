<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkFase1 = New System.Windows.Forms.LinkLabel()
        Me.lnkFase2 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Gestione file SERVPS e CONTPS"
        '
        'lnkFase1
        '
        Me.lnkFase1.AutoSize = True
        Me.lnkFase1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkFase1.Location = New System.Drawing.Point(219, 117)
        Me.lnkFase1.Name = "lnkFase1"
        Me.lnkFase1.Size = New System.Drawing.Size(93, 24)
        Me.lnkFase1.TabIndex = 1
        Me.lnkFase1.TabStop = True
        Me.lnkFase1.Text = " - Fase 1"
        '
        'lnkFase2
        '
        Me.lnkFase2.AutoSize = True
        Me.lnkFase2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkFase2.Location = New System.Drawing.Point(219, 171)
        Me.lnkFase2.Name = "lnkFase2"
        Me.lnkFase2.Size = New System.Drawing.Size(93, 24)
        Me.lnkFase2.TabIndex = 2
        Me.lnkFase2.TabStop = True
        Me.lnkFase2.Text = " - Fase 2"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 293)
        Me.Controls.Add(Me.lnkFase2)
        Me.Controls.Add(Me.lnkFase1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lnkFase1 As LinkLabel
    Friend WithEvents lnkFase2 As LinkLabel
End Class
