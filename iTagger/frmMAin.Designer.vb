<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMAin
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
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.cmdOpenPath = New System.Windows.Forms.Button()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdGetTags = New System.Windows.Forms.Button()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.cmdReload = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALACEncoderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Enabled = False
        Me.txtPath.Location = New System.Drawing.Point(12, 35)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(294, 20)
        Me.txtPath.TabIndex = 0
        '
        'cmdOpenPath
        '
        Me.cmdOpenPath.Location = New System.Drawing.Point(312, 33)
        Me.cmdOpenPath.Name = "cmdOpenPath"
        Me.cmdOpenPath.Size = New System.Drawing.Size(48, 23)
        Me.cmdOpenPath.TabIndex = 1
        Me.cmdOpenPath.Text = "..."
        Me.cmdOpenPath.UseVisualStyleBackColor = True
        '
        'lvFiles
        '
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.GridLines = True
        Me.lvFiles.Location = New System.Drawing.Point(12, 61)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(697, 439)
        Me.lvFiles.TabIndex = 2
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Interpret"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Titel"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Länge"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Album"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Track"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "CD"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Genre"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Dateiname"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Kommentar"
        '
        'cmdGetTags
        '
        Me.cmdGetTags.Location = New System.Drawing.Point(610, 506)
        Me.cmdGetTags.Name = "cmdGetTags"
        Me.cmdGetTags.Size = New System.Drawing.Size(99, 23)
        Me.cmdGetTags.TabIndex = 3
        Me.cmdGetTags.Text = "Tags laden..."
        Me.cmdGetTags.UseVisualStyleBackColor = True
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(9, 506)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(150, 13)
        Me.lblSelection.TabIndex = 4
        Me.lblSelection.Text = "Ausgewählte Dateien: 0 von 0"
        '
        'cmdReload
        '
        Me.cmdReload.Location = New System.Drawing.Point(366, 33)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(75, 23)
        Me.cmdReload.TabIndex = 5
        Me.cmdReload.Text = "Reload"
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.ALACEncoderToolStripMenuItem, Me.ÜberToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(721, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'ÜberToolStripMenuItem
        '
        Me.ÜberToolStripMenuItem.Name = "ÜberToolStripMenuItem"
        Me.ÜberToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ÜberToolStripMenuItem.Text = "&Über"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'ALACEncoderToolStripMenuItem
        '
        Me.ALACEncoderToolStripMenuItem.Name = "ALACEncoderToolStripMenuItem"
        Me.ALACEncoderToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
        Me.ALACEncoderToolStripMenuItem.Text = "ALAC-Encoder"
        '
        'frmMAin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 540)
        Me.Controls.Add(Me.cmdReload)
        Me.Controls.Add(Me.lblSelection)
        Me.Controls.Add(Me.cmdGetTags)
        Me.Controls.Add(Me.lvFiles)
        Me.Controls.Add(Me.cmdOpenPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMAin"
        Me.Text = "iTagger"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents cmdOpenPath As System.Windows.Forms.Button
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdGetTags As System.Windows.Forms.Button
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents cmdReload As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÜberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ALACEncoderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
