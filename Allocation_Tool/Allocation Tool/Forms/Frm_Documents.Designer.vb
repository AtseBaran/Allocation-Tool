<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Documents
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
        Me.BindingNavigatorFiles = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButtonRefreshFiles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRemoveFiles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAddFiles = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewFiles = New System.Windows.Forms.DataGridView()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.BindingNavigatorFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorFiles.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridViewFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigatorFiles
        '
        Me.BindingNavigatorFiles.AddNewItem = Nothing
        Me.BindingNavigatorFiles.CountItem = Nothing
        Me.BindingNavigatorFiles.DeleteItem = Nothing
        Me.BindingNavigatorFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BindingNavigatorFiles.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.BindingNavigatorFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefreshFiles, Me.ToolStripButtonRemoveFiles, Me.ToolStripButtonAddFiles})
        Me.BindingNavigatorFiles.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigatorFiles.MoveFirstItem = Nothing
        Me.BindingNavigatorFiles.MoveLastItem = Nothing
        Me.BindingNavigatorFiles.MoveNextItem = Nothing
        Me.BindingNavigatorFiles.MovePreviousItem = Nothing
        Me.BindingNavigatorFiles.Name = "BindingNavigatorFiles"
        Me.BindingNavigatorFiles.PositionItem = Nothing
        Me.BindingNavigatorFiles.Size = New System.Drawing.Size(611, 35)
        Me.BindingNavigatorFiles.TabIndex = 3
        Me.BindingNavigatorFiles.Text = "BindingNavigator1"
        '
        'ToolStripButtonRefreshFiles
        '
        Me.ToolStripButtonRefreshFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRefreshFiles.Image = Global.Allocation_Tool.My.Resources.Resources.refresh
        Me.ToolStripButtonRefreshFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRefreshFiles.Name = "ToolStripButtonRefreshFiles"
        Me.ToolStripButtonRefreshFiles.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButtonRefreshFiles.Text = "Refresh"
        '
        'ToolStripButtonRemoveFiles
        '
        Me.ToolStripButtonRemoveFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonRemoveFiles.Image = Global.Allocation_Tool.My.Resources.Resources.Delete_Document
        Me.ToolStripButtonRemoveFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRemoveFiles.Name = "ToolStripButtonRemoveFiles"
        Me.ToolStripButtonRemoveFiles.Size = New System.Drawing.Size(108, 32)
        Me.ToolStripButtonRemoveFiles.Text = "Remove Files"
        Me.ToolStripButtonRemoveFiles.Visible = False
        '
        'ToolStripButtonAddFiles
        '
        Me.ToolStripButtonAddFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonAddFiles.Image = Global.Allocation_Tool.My.Resources.Resources.New_Document
        Me.ToolStripButtonAddFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddFiles.Name = "ToolStripButtonAddFiles"
        Me.ToolStripButtonAddFiles.Size = New System.Drawing.Size(87, 32)
        Me.ToolStripButtonAddFiles.Text = "Add Files"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewFiles, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BindingNavigatorFiles, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(611, 319)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'DataGridViewFiles
        '
        Me.DataGridViewFiles.AllowUserToAddRows = False
        Me.DataGridViewFiles.AllowUserToDeleteRows = False
        Me.DataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewFiles.Location = New System.Drawing.Point(3, 38)
        Me.DataGridViewFiles.Name = "DataGridViewFiles"
        Me.DataGridViewFiles.ReadOnly = True
        Me.DataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewFiles.Size = New System.Drawing.Size(605, 278)
        Me.DataGridViewFiles.TabIndex = 4
        '
        'Frm_Documents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 319)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Frm_Documents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documents"
        CType(Me.BindingNavigatorFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorFiles.ResumeLayout(False)
        Me.BindingNavigatorFiles.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridViewFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingNavigatorFiles As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButtonRefreshFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonRemoveFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonAddFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DataGridViewFiles As System.Windows.Forms.DataGridView
End Class
