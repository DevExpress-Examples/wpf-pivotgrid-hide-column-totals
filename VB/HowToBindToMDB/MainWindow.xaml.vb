Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System

Namespace HowToBindToMDB
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private dataTable As New NwindDataSet.OrderDetailsDataTable()
		Private dataAdapter As New OrderDetailsTableAdapter()

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = dataTable
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			dataAdapter.Fill(dataTable)
		End Sub

		Private Sub pivotGridControl1_CustomUnboundFieldData(ByVal sender As Object, ByVal e As PivotCustomFieldDataEventArgs)
			If Object.ReferenceEquals(e.Field, fieldTotalSum) Then
				Dim unitPrice As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"))
				Dim qty As Integer = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"))
				Dim discount As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"))
				e.Value = unitPrice * qty * (1 - discount)
			End If
		End Sub
	End Class
End Namespace
