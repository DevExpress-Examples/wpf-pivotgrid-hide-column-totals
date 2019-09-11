using System.Windows;
using DevExpress.Xpf.PivotGrid;
using System;

namespace UnboundFieldExample
{
    public partial class MainWindow : Window {
        DataSet1.OrderDetailsDataTable dataTable = new DataSet1.OrderDetailsDataTable();
        DataSet1TableAdapters.OrderDetailsTableAdapter dataAdapter = new DataSet1TableAdapters.OrderDetailsTableAdapter();

        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = dataTable;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            dataAdapter.Fill(dataTable);
        }

        private void pivotGridControl1_CustomUnboundFieldData(object sender, 
                PivotCustomFieldDataEventArgs e) {
            if(e.Field == fieldTotalSum) {
                decimal unitPrice = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"));
                int qty = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"));
                decimal discount = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"));
                e.Value = unitPrice * qty * (1 - discount);
            }
        }

        private void PivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            if (e.DataField == fieldDiscount && e.RowValueType == FieldValueType.GrandTotal)
                e.Value = String.Empty;
        }
    }
}
