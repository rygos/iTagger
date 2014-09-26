Public Class frmEncoder

    Private Sub frmEncoder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub StartProcess(sArgs As String)

        Dim Proc = New Process()

        Proc.StartInfo.FileName = Application.StartupPath & "\qaac\qaac.exe"
        Proc.StartInfo.Arguments = sArgs

        Proc.StartInfo.RedirectStandardOutput = True
        Proc.StartInfo.RedirectStandardError = True
        Proc.EnableRaisingEvents = True
        Application.DoEvents()
        Proc.StartInfo.CreateNoWindow = True
        Proc.StartInfo.UseShellExecute = False

        AddHandler Proc.ErrorDataReceived, AddressOf proc_OutputDataReceived
        AddHandler Proc.OutputDataReceived, AddressOf proc_OutputDataReceived
        Proc.Start()
        Proc.BeginErrorReadLine()
        Proc.BeginOutputReadLine()
        'Proc.WaitForExit()

    End Sub


    Delegate Sub UpdateTextBoxDelg(ByVal text As String)
    Public myDelegate As UpdateTextBoxDelg = New UpdateTextBoxDelg(AddressOf UpdateTextBox)


    Public Sub proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If Me.InvokeRequired = True Then
            Me.Invoke(myDelegate, e.Data)
        Else
            UpdateTextBox(e.Data)
        End If

    End Sub

    Public Sub UpdateTextBox(ByVal text As String)
        txtDebug.Text = txtDebug.Text & text & "-" & vbNewLine
    End Sub

    Private Sub List_All_Files(odir As IO.DirectoryInfo)
        Dim oSubDir As IO.DirectoryInfo
        Dim oFile As IO.FileInfo


        ' zunächst alle Dateien des Ordners aufspüren
        For Each oFile In odir.GetFiles()
            If oFile.Extension = ".mp3" Then
                If oFile.Name.StartsWith("._") = False Then
                    With oFile
                        lvwAddItem(lvFiles, oFile.FullName, oFile.Length)
                    End With
                End If
            End If
        Next

        ' Jetzt alle Unterverzeichnis durchlaufen
        ' und die Prozedur rekursiv selbst aufrufen
        For Each oSubDir In odir.GetDirectories()
            List_All_Files(oSubDir)
        Next
    End Sub

    Private Sub cmdOpenPath_Click(sender As Object, e As EventArgs) Handles cmdOpenPath.Click
        Dim ofd As New FolderBrowserDialog

        ofd.ShowDialog()

        Dim sPath As String = ofd.SelectedPath
        txtPath.Text = sPath
        If sPath <> vbNullString Then
            Dim oDir As New IO.DirectoryInfo(sPath)
            List_All_Files(oDir)
        End If
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        pbAll.Maximum = lvFiles.Items.Count - 1
        pbFile.Maximum = 100

        Debug.Print("-q 0 -o """ & Application.StartupPath & "\test.mp4"" """ & lvFiles.Items(0).SubItems(0).Text & """")

        StartProcess("-q 0 -o """ & Application.StartupPath & "\test.mp4"" """ & lvFiles.Items(0).SubItems(0).Text & """")
    End Sub
End Class