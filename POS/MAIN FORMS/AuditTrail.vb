Imports MySql.Data.MySqlClient
Public Class AuditTrail
    Public ATGroupName As String = ""
    Public ATUserName As String = ""
    Public ATFromDate As String = ""
    Public ATToDate As String = ""
    Public ATRowLimit As String = ""
    Private Sub AuditTrail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogs(True)
    End Sub

    Public Sub LoadLogs(LoadOnly As Boolean)
        Try
            DataGridViewAuditTrail.Rows.Clear()
            Dim ConnectionLocal As MySqlConnection = LocalhostConn()
            Dim Query As String = ""
            If LoadOnly Then
                Query = "SELECT * FROM loc_audit_trail WHERE DATE_FORMAT(created_at, '%Y-%m-%d') = '" & Format(Now(), "yyyy-MM-dd") & "' LIMIT 100"
            Else
                Query = "SELECT * FROM loc_audit_trail WHERE DATE_FORMAT(created_at, '%Y-%m-%d') >= '" & ATFromDate & "' AND DATE_FORMAT(created_at, '%Y-%m-%d') <= '" & ATToDate & "'"
                If ATGroupName <> "All" Then
                    Query &= "AND group_name = '" & ATGroupName & "'"
                End If
                If ATUserName <> "All" Then
                    Query &= "AND crew_id = '" & ATUserName & "'"
                End If
                If ATRowLimit <> "All" Then
                    Query &= " LIMIT  " & ATRowLimit & ""
                End If
            End If

            Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
            Dim Da As MySqlDataAdapter = New MySqlDataAdapter(Command)
            Dim Dt As DataTable = New DataTable
            Da.Fill(Dt)

            For i As Integer = 0 To Dt.Rows.Count - 1 Step +1
                DataGridViewAuditTrail.Rows.Add(Dt(i)(0), Dt(i)(1), Dt(i)(2), Dt(i)(3), Dt(i)(4), Dt(i)(5), Dt(i)(6), Dt(i)(7))
                If Dt(i)(3) = "Normal" Then
                    DataGridViewAuditTrail.Rows(i).Cells(3).Style.BackColor = Color.LightGreen
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub LogToAuditTral(GroupName As String, Description As String, Severity As String)
        Try
            If ValidLocalConnection Then

                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim Query As String = "INSERT INTO loc_audit_trail (`created_at`, `group_name`, `severity`, `crew_id`, `description`,`info`, `store_id`, `synced`) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)"
                Dim Command As MySqlCommand = New MySqlCommand(Query, ConnectionLocal)
                Command.Parameters.Add("@1", MySqlDbType.Text).Value = FullDate24HR()
                Command.Parameters.Add("@2", MySqlDbType.Text).Value = GroupName
                Command.Parameters.Add("@3", MySqlDbType.Text).Value = Severity
                Command.Parameters.Add("@4", MySqlDbType.Text).Value = If(ClientCrewID <> "", ClientCrewID, "N/A")
                Command.Parameters.Add("@5", MySqlDbType.Text).Value = Description
                Command.Parameters.Add("@6", MySqlDbType.Text).Value = "DG POS, " & My.Settings.Version & " , ID : X"
                Command.Parameters.Add("@7", MySqlDbType.Text).Value = ClientStoreID
                Command.Parameters.Add("@8", MySqlDbType.Text).Value = "Unsynced"
                Command.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Enabled = False
        AuditTrailFilter.Show()
    End Sub

    Private Sub AuditTrail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MDIFORM.newMDIchildReports.Enabled = True
        MDIFORM.Enabled = True
    End Sub
End Class