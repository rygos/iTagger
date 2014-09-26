<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEncoder
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.cmdOpenPath = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.pbFile = New System.Windows.Forms.ProgressBar()
        Me.pbAll = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Enabled = False
        Me.txtPath.Location = New System.Drawing.Point(120, 14)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(222, 20)
        Me.txtPath.TabIndex = 2
        '
        'cmdOpenPath
        '
        Me.cmdOpenPath.Location = New System.Drawing.Point(348, 12)
        Me.cmdOpenPath.Name = "cmdOpenPath"
        Me.cmdOpenPath.Size = New System.Drawing.Size(41, 23)
        Me.cmdOpenPath.TabIndex = 3
        Me.cmdOpenPath.Text = "..."
        Me.cmdOpenPath.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pfad zu Dateien:"
        '
        'lvFiles
        '
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.Location = New System.Drawing.Point(15, 40)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(222, 308)
        Me.lvFiles.TabIndex = 5
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Datei"
        Me.ColumnHeader1.Width = 124
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Größe"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(323, 421)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(75, 23)
        Me.cmdStart.TabIndex = 6
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(49, 40)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.Size = New System.Drawing.Size(293, 263)
        Me.txtDebug.TabIndex = 7
        '
        'pbFile
        '
        Me.pbFile.Location = New System.Drawing.Point(89, 354)
        Me.pbFile.Name = "pbFile"
        Me.pbFile.Size = New System.Drawing.Size(309, 23)
        Me.pbFile.TabIndex = 8
        '
        'pbAll
        '
        Me.pbAll.Location = New System.Drawing.Point(89, 383)
        Me.pbAll.Name = "pbAll"
        Me.pbAll.Size = New System.Drawing.Size(309, 23)
        Me.pbAll.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Aktuelle Datei:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 393)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Gesamt:"
        '
        'frmEncoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 456)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbAll)
        Me.Controls.Add(Me.pbFile)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.lvFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOpenPath)
        Me.Controls.Add(Me.txtPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEncoder"
        Me.Text = "AAC/ALAC Encoder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents cmdOpenPath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents txtDebug As System.Windows.Forms.TextBox
    Friend WithEvents pbFile As System.Windows.Forms.ProgressBar
    Friend WithEvents pbAll As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
