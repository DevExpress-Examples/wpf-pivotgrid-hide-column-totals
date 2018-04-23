using System.Data;
using System.Data.OleDb;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using HowToBindToMDB.NwindDataSetTableAdapters;
using System;

namespace HowToBindToMDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        NwindDataSet.OrderDetailsDataTable dataTable = new NwindDataSet.OrderDetailsDataTable();
        OrderDetailsTableAdapter dataAdapter = new OrderDetailsTableAdapter();

        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = dataTable;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            dataAdapter.Fill(dataTable);
        }

        private void pivotGridControl1_CustomUnboundFieldData(object sender, PivotCustomFieldDataEventArgs e) {
            if(e.Field == fieldTotalSum) {
                decimal unitPrice = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"));
                int qty = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"));
                decimal discount = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"));
                e.Value = unitPrice * qty * (1 - discount);
            }
        }
    }
}
