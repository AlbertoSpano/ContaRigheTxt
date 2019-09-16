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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.rbModificati = New System.Windows.Forms.RadioButton()
        Me.rbCreati = New System.Windows.Forms.RadioButton()
        Me.chkAlle = New System.Windows.Forms.CheckBox()
        Me.chkDalle = New System.Windows.Forms.CheckBox()
        Me.txtAlle = New System.Windows.Forms.DateTimePicker()
        Me.txtDalle = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkRinomina = New System.Windows.Forms.CheckBox()
        Me.chkApriFileAlTermine = New System.Windows.Forms.CheckBox()
        Me.chkAccorpaFile = New System.Windows.Forms.CheckBox()
        Me.txtPatternAccorpamento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpAccorpamento = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCreaCodiceCiclo = New System.Windows.Forms.CheckBox()
        Me.txtColServpsValoreA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtColServpsValoreDa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtColServpsA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtColServpsDa = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tabSel = New System.Windows.Forms.TabPage()
        Me.tabGen = New System.Windows.Forms.TabPage()
        Me.lnkToggleSettings = New System.Windows.Forms.LinkLabel()
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrario.SuspendLayout()
        Me.grpAccorpamento.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.tabSel.SuspendLayout()
        Me.tabGen.SuspendLayout()
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
        Me.grdFiles.Location = New System.Drawing.Point(32, 78)
        Me.grdFiles.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFiles.MultiSelect = False
        Me.grdFiles.Name = "grdFiles"
        Me.grdFiles.ReadOnly = True
        Me.grdFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiles.Size = New System.Drawing.Size(1040, 465)
        Me.grdFiles.TabIndex = 0
        Me.grdFiles.TabStop = False
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Righe.DefaultCellStyle = DataGridViewCellStyle6
        Me.Righe.HeaderText = "Righe"
        Me.Righe.Name = "Righe"
        Me.Righe.ReadOnly = True
        '
        'btnScegli
        '
        Me.btnScegli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScegli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScegli.Location = New System.Drawing.Point(791, 44)
        Me.btnScegli.Margin = New System.Windows.Forms.Padding(4)
        Me.btnScegli.Name = "btnScegli"
        Me.btnScegli.Size = New System.Drawing.Size(136, 30)
        Me.btnScegli.TabIndex = 13
        Me.btnScegli.Text = "Scegli cartella ..."
        Me.btnScegli.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtro nome file:"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(132, 37)
        Me.txtFiltro.MaxLength = 12
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(130, 23)
        Me.txtFiltro.TabIndex = 0
        Me.txtFiltro.Text = ".txt"
        '
        'btnEsporta
        '
        Me.btnEsporta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEsporta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEsporta.Enabled = False
        Me.btnEsporta.Location = New System.Drawing.Point(935, 44)
        Me.btnEsporta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(136, 30)
        Me.btnEsporta.TabIndex = 15
        Me.btnEsporta.Text = "Esegui"
        Me.btnEsporta.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFolder.Location = New System.Drawing.Point(32, 48)
        Me.txtFolder.MaxLength = 12
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(752, 23)
        Me.txtFolder.TabIndex = 5
        Me.txtFolder.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Prefisso nomi numerici:"
        '
        'txtPrefisso
        '
        Me.txtPrefisso.Location = New System.Drawing.Point(196, 70)
        Me.txtPrefisso.MaxLength = 1
        Me.txtPrefisso.Name = "txtPrefisso"
        Me.txtPrefisso.Size = New System.Drawing.Size(66, 23)
        Me.txtPrefisso.TabIndex = 1
        Me.txtPrefisso.Text = "L"
        Me.txtPrefisso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rbSingolo
        '
        Me.rbSingolo.AutoSize = True
        Me.rbSingolo.Location = New System.Drawing.Point(272, 186)
        Me.rbSingolo.Name = "rbSingolo"
        Me.rbSingolo.Size = New System.Drawing.Size(193, 21)
        Me.rbSingolo.TabIndex = 4
        Me.rbSingolo.Text = "Totali righe per singolo file"
        Me.rbSingolo.UseVisualStyleBackColor = True
        '
        'rbPercorsoCartella
        '
        Me.rbPercorsoCartella.AutoSize = True
        Me.rbPercorsoCartella.Checked = True
        Me.rbPercorsoCartella.Location = New System.Drawing.Point(23, 186)
        Me.rbPercorsoCartella.Name = "rbPercorsoCartella"
        Me.rbPercorsoCartella.Size = New System.Drawing.Size(234, 21)
        Me.rbPercorsoCartella.TabIndex = 3
        Me.rbPercorsoCartella.TabStop = True
        Me.rbPercorsoCartella.Text = "Totali righe per percorso cartella"
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
        Me.grpOrario.Location = New System.Drawing.Point(430, 37)
        Me.grpOrario.Name = "grpOrario"
        Me.grpOrario.Size = New System.Drawing.Size(276, 121)
        Me.grpOrario.TabIndex = 12
        Me.grpOrario.TabStop = False
        Me.grpOrario.Text = "Solo file creati/modificati nella fascia:"
        '
        'rbModificati
        '
        Me.rbModificati.AutoSize = True
        Me.rbModificati.Checked = True
        Me.rbModificati.Location = New System.Drawing.Point(100, 28)
        Me.rbModificati.Name = "rbModificati"
        Me.rbModificati.Size = New System.Drawing.Size(92, 21)
        Me.rbModificati.TabIndex = 8
        Me.rbModificati.TabStop = True
        Me.rbModificati.Text = "modificati"
        Me.rbModificati.UseVisualStyleBackColor = True
        '
        'rbCreati
        '
        Me.rbCreati.AutoSize = True
        Me.rbCreati.Location = New System.Drawing.Point(27, 28)
        Me.rbCreati.Name = "rbCreati"
        Me.rbCreati.Size = New System.Drawing.Size(63, 21)
        Me.rbCreati.TabIndex = 7
        Me.rbCreati.Text = "creati"
        Me.rbCreati.UseVisualStyleBackColor = True
        '
        'chkAlle
        '
        Me.chkAlle.AutoSize = True
        Me.chkAlle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAlle.Location = New System.Drawing.Point(100, 93)
        Me.chkAlle.Name = "chkAlle"
        Me.chkAlle.Size = New System.Drawing.Size(15, 14)
        Me.chkAlle.TabIndex = 11
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
        Me.chkDalle.TabIndex = 9
        Me.chkDalle.UseVisualStyleBackColor = True
        '
        'txtAlle
        '
        Me.txtAlle.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtAlle.Location = New System.Drawing.Point(147, 86)
        Me.txtAlle.Name = "txtAlle"
        Me.txtAlle.ShowUpDown = True
        Me.txtAlle.Size = New System.Drawing.Size(88, 23)
        Me.txtAlle.TabIndex = 12
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
        Me.txtDalle.TabIndex = 10
        Me.txtDalle.Value = New Date(2019, 4, 18, 11, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "alle ore:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "dalle ore:"
        '
        'chkRinomina
        '
        Me.chkRinomina.AutoSize = True
        Me.chkRinomina.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRinomina.Location = New System.Drawing.Point(20, 106)
        Me.chkRinomina.Name = "chkRinomina"
        Me.chkRinomina.Size = New System.Drawing.Size(323, 21)
        Me.chkRinomina.TabIndex = 2
        Me.chkRinomina.Text = "Rinomina cartelle con aggiunta numero righe"
        Me.chkRinomina.UseVisualStyleBackColor = True
        '
        'chkApriFileAlTermine
        '
        Me.chkApriFileAlTermine.AutoSize = True
        Me.chkApriFileAlTermine.Location = New System.Drawing.Point(21, 204)
        Me.chkApriFileAlTermine.Name = "chkApriFileAlTermine"
        Me.chkApriFileAlTermine.Size = New System.Drawing.Size(161, 21)
        Me.chkApriFileAlTermine.TabIndex = 14
        Me.chkApriFileAlTermine.Text = "apri file xls al termine"
        Me.chkApriFileAlTermine.UseVisualStyleBackColor = True
        '
        'chkAccorpaFile
        '
        Me.chkAccorpaFile.AutoSize = True
        Me.chkAccorpaFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAccorpaFile.Location = New System.Drawing.Point(20, 23)
        Me.chkAccorpaFile.Name = "chkAccorpaFile"
        Me.chkAccorpaFile.Size = New System.Drawing.Size(164, 21)
        Me.chkAccorpaFile.TabIndex = 5
        Me.chkAccorpaFile.Text = "Accorpa per tipo file:"
        Me.chkAccorpaFile.UseVisualStyleBackColor = True
        '
        'txtPatternAccorpamento
        '
        Me.txtPatternAccorpamento.Enabled = False
        Me.txtPatternAccorpamento.Location = New System.Drawing.Point(448, 21)
        Me.txtPatternAccorpamento.MaxLength = 2
        Me.txtPatternAccorpamento.Name = "txtPatternAccorpamento"
        Me.txtPatternAccorpamento.Size = New System.Drawing.Size(66, 23)
        Me.txtPatternAccorpamento.TabIndex = 6
        Me.txtPatternAccorpamento.Text = "10"
        Me.txtPatternAccorpamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(210, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(232, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Lunghezza parte dx nome file tipo:"
        '
        'grpAccorpamento
        '
        Me.grpAccorpamento.Controls.Add(Me.chkAccorpaFile)
        Me.grpAccorpamento.Controls.Add(Me.txtPatternAccorpamento)
        Me.grpAccorpamento.Controls.Add(Me.Label6)
        Me.grpAccorpamento.Location = New System.Drawing.Point(21, 21)
        Me.grpAccorpamento.Name = "grpAccorpamento"
        Me.grpAccorpamento.Size = New System.Drawing.Size(529, 61)
        Me.grpAccorpamento.TabIndex = 20
        Me.grpAccorpamento.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCreaCodiceCiclo)
        Me.GroupBox1.Controls.Add(Me.txtColServpsValoreA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtColServpsValoreDa)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtColServpsA)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtColServpsDa)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(669, 94)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'chkCreaCodiceCiclo
        '
        Me.chkCreaCodiceCiclo.AutoSize = True
        Me.chkCreaCodiceCiclo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCreaCodiceCiclo.Location = New System.Drawing.Point(20, 37)
        Me.chkCreaCodiceCiclo.Name = "chkCreaCodiceCiclo"
        Me.chkCreaCodiceCiclo.Size = New System.Drawing.Size(236, 21)
        Me.chkCreaCodiceCiclo.TabIndex = 22
        Me.chkCreaCodiceCiclo.Text = "Crea file codice/ciclo da servps:"
        Me.chkCreaCodiceCiclo.UseVisualStyleBackColor = True
        '
        'txtColServpsValoreA
        '
        Me.txtColServpsValoreA.Location = New System.Drawing.Point(604, 51)
        Me.txtColServpsValoreA.MaxLength = 3
        Me.txtColServpsValoreA.Name = "txtColServpsValoreA"
        Me.txtColServpsValoreA.Size = New System.Drawing.Size(35, 23)
        Me.txtColServpsValoreA.TabIndex = 21
        Me.txtColServpsValoreA.Text = "10"
        Me.txtColServpsValoreA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(577, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "a:"
        '
        'txtColServpsValoreDa
        '
        Me.txtColServpsValoreDa.Location = New System.Drawing.Point(524, 51)
        Me.txtColServpsValoreDa.MaxLength = 3
        Me.txtColServpsValoreDa.Name = "txtColServpsValoreDa"
        Me.txtColServpsValoreDa.Size = New System.Drawing.Size(35, 23)
        Me.txtColServpsValoreDa.TabIndex = 19
        Me.txtColServpsValoreDa.Text = "10"
        Me.txtColServpsValoreDa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(488, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "da:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(296, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Colonna ciclo file servps:"
        '
        'txtColServpsA
        '
        Me.txtColServpsA.Location = New System.Drawing.Point(604, 25)
        Me.txtColServpsA.MaxLength = 3
        Me.txtColServpsA.Name = "txtColServpsA"
        Me.txtColServpsA.Size = New System.Drawing.Size(35, 23)
        Me.txtColServpsA.TabIndex = 12
        Me.txtColServpsA.Text = "10"
        Me.txtColServpsA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(577, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "a:"
        '
        'txtColServpsDa
        '
        Me.txtColServpsDa.Location = New System.Drawing.Point(524, 25)
        Me.txtColServpsDa.MaxLength = 3
        Me.txtColServpsDa.Name = "txtColServpsDa"
        Me.txtColServpsDa.Size = New System.Drawing.Size(35, 23)
        Me.txtColServpsDa.TabIndex = 10
        Me.txtColServpsDa.Text = "10"
        Me.txtColServpsDa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(488, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 17)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "da:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(296, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(183, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Colonna codice file servps:"
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tabSel)
        Me.tabSettings.Controls.Add(Me.tabGen)
        Me.tabSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabSettings.Location = New System.Drawing.Point(32, 9)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(752, 28)
        Me.tabSettings.TabIndex = 22
        '
        'tabSel
        '
        Me.tabSel.Controls.Add(Me.Label1)
        Me.tabSel.Controls.Add(Me.txtPrefisso)
        Me.tabSel.Controls.Add(Me.Label2)
        Me.tabSel.Controls.Add(Me.rbSingolo)
        Me.tabSel.Controls.Add(Me.rbPercorsoCartella)
        Me.tabSel.Controls.Add(Me.txtFiltro)
        Me.tabSel.Controls.Add(Me.chkRinomina)
        Me.tabSel.Controls.Add(Me.grpOrario)
        Me.tabSel.Location = New System.Drawing.Point(4, 26)
        Me.tabSel.Name = "tabSel"
        Me.tabSel.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSel.Size = New System.Drawing.Size(744, 277)
        Me.tabSel.TabIndex = 0
        Me.tabSel.Text = "Opzioni selezione"
        Me.tabSel.UseVisualStyleBackColor = True
        '
        'tabGen
        '
        Me.tabGen.Controls.Add(Me.GroupBox1)
        Me.tabGen.Controls.Add(Me.grpAccorpamento)
        Me.tabGen.Controls.Add(Me.chkApriFileAlTermine)
        Me.tabGen.Location = New System.Drawing.Point(4, 26)
        Me.tabGen.Name = "tabGen"
        Me.tabGen.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGen.Size = New System.Drawing.Size(744, 0)
        Me.tabGen.TabIndex = 1
        Me.tabGen.Text = "Opzioni generazione"
        Me.tabGen.UseVisualStyleBackColor = True
        '
        'lnkToggleSettings
        '
        Me.lnkToggleSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkToggleSettings.Location = New System.Drawing.Point(907, 9)
        Me.lnkToggleSettings.Name = "lnkToggleSettings"
        Me.lnkToggleSettings.Size = New System.Drawing.Size(165, 20)
        Me.lnkToggleSettings.TabIndex = 23
        Me.lnkToggleSettings.TabStop = True
        Me.lnkToggleSettings.Text = "mostra opzioni"
        Me.lnkToggleSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FileTxt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 562)
        Me.Controls.Add(Me.lnkToggleSettings)
        Me.Controls.Add(Me.tabSettings)
        Me.Controls.Add(Me.grdFiles)
        Me.Controls.Add(Me.btnEsporta)
        Me.Controls.Add(Me.btnScegli)
        Me.Controls.Add(Me.txtFolder)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1100, 600)
        Me.Name = "FileTxt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File txt"
        CType(Me.grdFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrario.ResumeLayout(False)
        Me.grpOrario.PerformLayout()
        Me.grpAccorpamento.ResumeLayout(False)
        Me.grpAccorpamento.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSel.ResumeLayout(False)
        Me.tabSel.PerformLayout()
        Me.tabGen.ResumeLayout(False)
        Me.tabGen.PerformLayout()
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
    Friend WithEvents chkRinomina As CheckBox
    Friend WithEvents rbModificati As RadioButton
    Friend WithEvents rbCreati As RadioButton
    Friend WithEvents chkApriFileAlTermine As CheckBox
    Friend WithEvents chkAccorpaFile As CheckBox
    Friend WithEvents txtPatternAccorpamento As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents grpAccorpamento As GroupBox
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents NomeFile As DataGridViewTextBoxColumn
    Friend WithEvents FullPath As DataGridViewTextBoxColumn
    Friend WithEvents Righe As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtColServpsA As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtColServpsDa As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtColServpsValoreA As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtColServpsValoreDa As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkCreaCodiceCiclo As CheckBox
    Friend WithEvents tabSettings As TabControl
    Friend WithEvents tabSel As TabPage
    Friend WithEvents tabGen As TabPage
    Friend WithEvents lnkToggleSettings As LinkLabel
End Class
