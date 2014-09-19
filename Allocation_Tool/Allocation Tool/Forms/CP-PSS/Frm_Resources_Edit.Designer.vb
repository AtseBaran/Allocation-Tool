<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Resources_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Resources_Edit))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonHistory = New System.Windows.Forms.ToolStripButton()
        Me.LabelNewValue = New System.Windows.Forms.Label()
        Me.TextBoxNewValue = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxOldValue = New System.Windows.Forms.TextBox()
        Me.LabelComments = New System.Windows.Forms.Label()
        Me.TextBoxComments = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TextBoxNewValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSave, Me.ToolStripButtonCancel, Me.ToolStripButtonHistory})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(475, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = Global.Allocation_Tool.My.Resources.Resources.disk_save
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonCancel
        '
        Me.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCancel.Image = Global.Allocation_Tool.My.Resources.Resources.Delete
        Me.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancel.Name = "ToolStripButtonCancel"
        Me.ToolStripButtonCancel.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonCancel.Text = "Clear"
        '
        'ToolStripButtonHistory
        '
        Me.ToolStripButtonHistory.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonHistory.Image = CType(resources.GetObject("ToolStripButtonHistory.Image"), System.Drawing.Image)
        Me.ToolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonHistory.Name = "ToolStripButtonHistory"
        Me.ToolStripButtonHistory.Size = New System.Drawing.Size(105, 28)
        Me.ToolStripButtonHistory.Text = "Resources History"
        '
        'LabelNewValue
        '
        Me.LabelNewValue.AutoSize = True
        Me.LabelNewValue.Location = New System.Drawing.Point(12, 48)
        Me.LabelNewValue.Name = "LabelNewValue"
        Me.LabelNewValue.Size = New System.Drawing.Size(59, 13)
        Me.LabelNewValue.TabIndex = 1
        Me.LabelNewValue.Text = "New Value"
        '
        'TextBoxNewValue
        '
        Me.TextBoxNewValue.Location = New System.Drawing.Point(77, 46)
        Me.TextBoxNewValue.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.TextBoxNewValue.Name = "TextBoxNewValue"
        Me.TextBoxNewValue.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxNewValue.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Old Value"
        '
        'TextBoxOldValue
        '
        Me.TextBoxOldValue.Enabled = False
        Me.TextBoxOldValue.Location = New System.Drawing.Point(77, 72)
        Me.TextBoxOldValue.Name = "TextBoxOldValue"
        Me.TextBoxOldValue.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxOldValue.TabIndex = 4
        '
        'LabelComments
        '
        Me.LabelComments.AutoSize = True
        Me.LabelComments.Location = New System.Drawing.Point(203, 49)
        Me.LabelComments.Name = "LabelComments"
        Me.LabelComments.Size = New System.Drawing.Size(51, 13)
        Me.LabelComments.TabIndex = 5
        Me.LabelComments.Text = "Comment"
        '
        'TextBoxComments
        '
        Me.TextBoxComments.Location = New System.Drawing.Point(260, 46)
        Me.TextBoxComments.Multiline = True
        Me.TextBoxComments.Name = "TextBoxComments"
        Me.TextBoxComments.Size = New System.Drawing.Size(203, 46)
        Me.TextBoxComments.TabIndex = 6
        '
        'Frm_Resources_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(475, 107)
        Me.Controls.Add(Me.TextBoxComments)
        Me.Controls.Add(Me.LabelComments)
        Me.Controls.Add(Me.TextBoxOldValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxNewValue)
        Me.Controls.Add(Me.LabelNewValue)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Resources_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Resource"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TextBoxNewValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelNewValue As System.Windows.Forms.Label
    Friend WithEvents TextBoxNewValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxOldValue As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelComments As System.Windows.Forms.Label
    Friend WithEvents TextBoxComments As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButtonHistory As System.Windows.Forms.ToolStripButton
End Class
