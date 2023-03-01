using System.Windows;
using DevExpress.Xpf.PivotGrid;
using System;

namespace UnboundFieldExample {
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
        private void PivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            if (e.ColumnValueType == FieldValueType.GrandTotal
                   && e.DataField == fieldDiscount)
                e.Value = null;
        }
    }
}
