<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SearchProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SearchProject))
        Me.DataGridViewProjects = New System.Windows.Forms.DataGridView()
        Me.GroupBox = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridViewProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewProjects
        '
        Me.DataGridViewProjects.AllowUserToAddRows = False
        Me.DataGridViewProjects.AllowUserToDeleteRows = False
        Me.DataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewProjects.Location = New System.Drawing.Point(10, 23)
        Me.DataGridViewProjects.Name = "DataGridViewProjects"
        Me.DataGridViewProjects.ReadOnly = True
        Me.DataGridViewProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewProjects.Size = New System.Drawing.Size(657, 180)
        Me.DataGridViewProjects.TabIndex = 0
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.DataGridViewProjects)
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox.Size = New System.Drawing.Size(677, 213)
        Me.GroupBox.TabIndex = 1
        Me.GroupBox.TabStop = False
        Me.GroupBox.Text = "My Projects"
        '
        'Frm_SearchProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(697, 233)
        Me.Controls.Add(Me.GroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SearchProject"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Project"
        CType(Me.DataGridViewProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewProjects As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
End Class
