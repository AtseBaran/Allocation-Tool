<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Reports_Popup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Reports_Popup))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.CheckedListBox, 0, 1)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(369, 281)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonFilter, Me.ToolStripDropDownButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(369, 35)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButtonFilter
        '
        Me.ToolStripButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFilter.Image = Global.Allocation_Tool.My.Resources.Resources.filter
        Me.ToolStripButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFilter.Name = "ToolStripButtonFilter"
        Me.ToolStripButtonFilter.Size = New System.Drawing.Size(28, 32)
        Me.ToolStripButtonFilter.Text = "Filter"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.NoneToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Allocation_Tool.My.Resources.Resources.checkbox_checked
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(37, 32)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'NoneToolStripMenuItem
        '
        Me.NoneToolStripMenuItem.Name = "NoneToolStripMenuItem"
        Me.NoneToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.NoneToolStripMenuItem.Text = "None"
        '
        'CheckedListBox
        '
        Me.CheckedListBox.CheckOnClick = True
        Me.CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Location = New System.Drawing.Point(3, 38)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(363, 240)
        Me.CheckedListBox.TabIndex = 1
        '
        'Frm_Reports_Popup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 281)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Reports_Popup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select..."
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckedListBox As System.Windows.Forms.CheckedListBox
End Class
