<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Documents_Upload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Documents_Upload))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblFile = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbProject = New System.Windows.Forms.ComboBox()
        Me.BtnUploadFile = New System.Windows.Forms.Button()
        Me.BtnSelectFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File"
        '
        'LblFile
        '
        Me.LblFile.Location = New System.Drawing.Point(55, 13)
        Me.LblFile.Name = "LblFile"
        Me.LblFile.Size = New System.Drawing.Size(170, 13)
        Me.LblFile.TabIndex = 1
        Me.LblFile.Text = "Please select file..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Project"
        '
        'CmbProject
        '
        Me.CmbProject.FormattingEnabled = True
        Me.CmbProject.Location = New System.Drawing.Point(58, 41)
        Me.CmbProject.Name = "CmbProject"
        Me.CmbProject.Size = New System.Drawing.Size(248, 21)
        Me.CmbProject.TabIndex = 3
        '
        'BtnUploadFile
        '
        Me.BtnUploadFile.Location = New System.Drawing.Point(231, 70)
        Me.BtnUploadFile.Name = "BtnUploadFile"
        Me.BtnUploadFile.Size = New System.Drawing.Size(75, 23)
        Me.BtnUploadFile.TabIndex = 4
        Me.BtnUploadFile.Text = "Upload File"
        Me.BtnUploadFile.UseVisualStyleBackColor = True
        '
        'BtnSelectFile
        '
        Me.BtnSelectFile.Location = New System.Drawing.Point(231, 8)
        Me.BtnSelectFile.Name = "BtnSelectFile"
        Me.BtnSelectFile.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectFile.TabIndex = 5
        Me.BtnSelectFile.Text = "Browse File"
        Me.BtnSelectFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "All Files | *.*"
        '
        'Frm_Documents_Upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 105)
        Me.Controls.Add(Me.BtnSelectFile)
        Me.Controls.Add(Me.BtnUploadFile)
        Me.Controls.Add(Me.CmbProject)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblFile)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Documents_Upload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Document"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblFile As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents BtnUploadFile As System.Windows.Forms.Button
    Friend WithEvents BtnSelectFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
