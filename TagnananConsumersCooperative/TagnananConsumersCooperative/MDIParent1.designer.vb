<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.DASHBOARDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.STOCKSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.STOCKRECIEVINGREPORTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.STOCKCARDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RETURNTOSTOCKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.POSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CUSTOMERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.user = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.fullname = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RECEIPTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.Silver
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DASHBOARDToolStripMenuItem, Me.STOCKSToolStripMenuItem, Me.POSToolStripMenuItem1, Me.CUSTOMERToolStripMenuItem, Me.REPORTSToolStripMenuItem, Me.RECEIPTSToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1350, 27)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'DASHBOARDToolStripMenuItem
        '
        Me.DASHBOARDToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.DASHBOARDToolStripMenuItem.Name = "DASHBOARDToolStripMenuItem"
        Me.DASHBOARDToolStripMenuItem.Size = New System.Drawing.Size(99, 21)
        Me.DASHBOARDToolStripMenuItem.Text = "DASHBOARD"
        '
        'STOCKSToolStripMenuItem
        '
        Me.STOCKSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.STOCKRECIEVINGREPORTToolStripMenuItem, Me.STOCKCARDToolStripMenuItem, Me.RETURNTOSTOCKToolStripMenuItem})
        Me.STOCKSToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.STOCKSToolStripMenuItem.Name = "STOCKSToolStripMenuItem"
        Me.STOCKSToolStripMenuItem.Size = New System.Drawing.Size(66, 21)
        Me.STOCKSToolStripMenuItem.Text = "STOCKS"
        '
        'STOCKRECIEVINGREPORTToolStripMenuItem
        '
        Me.STOCKRECIEVINGREPORTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VIEWToolStripMenuItem, Me.ADDToolStripMenuItem})
        Me.STOCKRECIEVINGREPORTToolStripMenuItem.Name = "STOCKRECIEVINGREPORTToolStripMenuItem"
        Me.STOCKRECIEVINGREPORTToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.STOCKRECIEVINGREPORTToolStripMenuItem.Text = "STOCK RECIEVING REPORT"
        '
        'VIEWToolStripMenuItem
        '
        Me.VIEWToolStripMenuItem.Name = "VIEWToolStripMenuItem"
        Me.VIEWToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.VIEWToolStripMenuItem.Text = "VIEW"
        '
        'ADDToolStripMenuItem
        '
        Me.ADDToolStripMenuItem.Name = "ADDToolStripMenuItem"
        Me.ADDToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.ADDToolStripMenuItem.Text = "ADD"
        '
        'STOCKCARDToolStripMenuItem
        '
        Me.STOCKCARDToolStripMenuItem.AutoSize = False
        Me.STOCKCARDToolStripMenuItem.Name = "STOCKCARDToolStripMenuItem"
        Me.STOCKCARDToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.STOCKCARDToolStripMenuItem.Text = "STOCKCARD"
        '
        'RETURNTOSTOCKToolStripMenuItem
        '
        Me.RETURNTOSTOCKToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VIEWToolStripMenuItem1, Me.ADDToolStripMenuItem1})
        Me.RETURNTOSTOCKToolStripMenuItem.Name = "RETURNTOSTOCKToolStripMenuItem"
        Me.RETURNTOSTOCKToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.RETURNTOSTOCKToolStripMenuItem.Text = "RETURN TO STOCK"
        '
        'VIEWToolStripMenuItem1
        '
        Me.VIEWToolStripMenuItem1.Name = "VIEWToolStripMenuItem1"
        Me.VIEWToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.VIEWToolStripMenuItem1.Text = "VIEW"
        '
        'ADDToolStripMenuItem1
        '
        Me.ADDToolStripMenuItem1.Name = "ADDToolStripMenuItem1"
        Me.ADDToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.ADDToolStripMenuItem1.Text = "RETURN"
        '
        'POSToolStripMenuItem1
        '
        Me.POSToolStripMenuItem1.ForeColor = System.Drawing.Color.Maroon
        Me.POSToolStripMenuItem1.Name = "POSToolStripMenuItem1"
        Me.POSToolStripMenuItem1.Size = New System.Drawing.Size(45, 21)
        Me.POSToolStripMenuItem1.Text = "POS"
        '
        'CUSTOMERToolStripMenuItem
        '
        Me.CUSTOMERToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.CUSTOMERToolStripMenuItem.Name = "CUSTOMERToolStripMenuItem"
        Me.CUSTOMERToolStripMenuItem.Size = New System.Drawing.Size(87, 21)
        Me.CUSTOMERToolStripMenuItem.Text = "CUSTOMER"
        '
        'REPORTSToolStripMenuItem
        '
        Me.REPORTSToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.REPORTSToolStripMenuItem.Name = "REPORTSToolStripMenuItem"
        Me.REPORTSToolStripMenuItem.Size = New System.Drawing.Size(75, 21)
        Me.REPORTSToolStripMenuItem.Text = "REPORTS"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 707)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1350, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(-2, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1350, 674)
        Me.Panel1.TabIndex = 13
        '
        'user
        '
        Me.user.Depth = 0
        Me.user.Location = New System.Drawing.Point(973, 0)
        Me.user.MouseState = MaterialSkin.MouseState.HOVER
        Me.user.Name = "user"
        Me.user.Primary = True
        Me.user.Size = New System.Drawing.Size(288, 27)
        Me.user.TabIndex = 20
        Me.user.Text = "USER"
        Me.user.UseVisualStyleBackColor = True
        '
        'fullname
        '
        Me.fullname.Depth = 0
        Me.fullname.Location = New System.Drawing.Point(627, 0)
        Me.fullname.MouseState = MaterialSkin.MouseState.HOVER
        Me.fullname.Name = "fullname"
        Me.fullname.Primary = True
        Me.fullname.Size = New System.Drawing.Size(247, 27)
        Me.fullname.TabIndex = 22
        Me.fullname.Text = "FULLNAME"
        Me.fullname.UseVisualStyleBackColor = True
        Me.fullname.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkGray
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Image = Global.TagnananConsumersCooperative.My.Resources.Resources.logout
        Me.Button2.Location = New System.Drawing.Point(1267, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 27)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "LOG-OUT"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(893, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'RECEIPTSToolStripMenuItem
        '
        Me.RECEIPTSToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.RECEIPTSToolStripMenuItem.Name = "RECEIPTSToolStripMenuItem"
        Me.RECEIPTSToolStripMenuItem.Size = New System.Drawing.Size(76, 21)
        Me.RECEIPTSToolStripMenuItem.Text = "RECIEPTS"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fullname)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents DASHBOARDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents STOCKSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents STOCKRECIEVINGREPORTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents STOCKCARDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RETURNTOSTOCKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CUSTOMERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents VIEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents POSToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents user As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents REPORTSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fullname As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RECEIPTSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
