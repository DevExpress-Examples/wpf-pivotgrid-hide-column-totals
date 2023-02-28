Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports System

Namespace UnboundFieldExample
	Partial Public Class MainWindow
		Inherits Window
		Private dataTable As New DataSet1.OrderDetailsDataTable()
		Private dataAdapter As New DataSet1TableAdapters.OrderDetailsTableAdapter()
		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = dataTable
		End Sub
		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			dataAdapter.Fill(dataTable)
		End Sub
		Private Sub PivotGridControl1_CustomCellValue(ByVal sender As Object, ByVal e As PivotCellValueEventArgs)
			If e.ColumnValueType = FieldValueType.GrandTotal AndAlso e.DataField Is fieldDiscount Then
				e.Value = Nothing
			End If
		End Sub
	End Class
End Namespace
