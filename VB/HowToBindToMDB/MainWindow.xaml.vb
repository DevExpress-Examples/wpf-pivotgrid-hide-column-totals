Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports System
Imports Microsoft.Data.Sqlite

Namespace UnboundFieldExample
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Create a data source.
			Dim dt As DataTable

			Using connection As New SqliteConnection("Data Source=nwind.db;")
				connection.Open()
				Dim cmd As SqliteCommand = CType(SqliteFactory.Instance.CreateCommand(), SqliteCommand)
				cmd.CommandText = "SELECT * FROM OrderDetails" & vbCrLf & "INNER JOIN Products ON Products.ProductID = OrderDetails.ProductID"
				cmd.Connection = connection
				Using dr As SqliteDataReader = cmd.ExecuteReader()
					Do
						dt = New DataTable()
						dt.BeginLoadData()
						dt.Load(dr)
						dt.EndLoadData()

					Loop While Not dr.IsClosed AndAlso dr.NextResult()
				End Using
			End Using

			' Assign the data source to the PivotGrid control.
			pivotGridControl1.DataSource = dt
		End Sub

		Private Sub PivotGridControl1_CustomCellValue(ByVal sender As Object, ByVal e As PivotCellValueEventArgs)
			If e.ColumnValueType = FieldValueType.GrandTotal AndAlso e.DataField Is fieldDiscount Then
				e.Value = Nothing
			End If
		End Sub
	End Class
End Namespace
