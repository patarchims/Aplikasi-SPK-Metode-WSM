Public Class Report_Rangking
    Private Sub Report_Rangking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshReport()
    End Sub
    Sub RefreshReport()
        Me.CRV.RefreshReport()
        Me.CRV.ReportSource = RptReport1
        Me.CRV.Zoom(85)
    End Sub
End Class