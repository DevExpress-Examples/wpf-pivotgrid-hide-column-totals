Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System

Namespace HowToBindToMDB

    Public Partial Class MainWindow
        Inherits Window

        Private dataTable As NwindDataSet.OrderDetailsDataTable = New NwindDataSet.OrderDetailsDataTable()

        Private dataAdapter As OrderDetailsTableAdapter = New OrderDetailsTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = dataTable
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            dataAdapter.Fill(dataTable)
        End Sub

        Private Sub pivotGridControl1_CustomUnboundFieldData(ByVal sender As Object, ByVal e As PivotCustomFieldDataEventArgs)
            If e.Field Is Me.fieldTotalSum Then
                Dim unitPrice As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"))
                Dim qty As Integer = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"))
                Dim discount As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"))
                e.Value = unitPrice * qty * (1 - discount)
            End If
        End Sub
    End Class
End Namespace
