using DevExpress.Xpf.PivotGrid;
using System.Data;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace UnboundFieldExample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender,RoutedEventArgs e) {
            // Create a data source.
            DataTable dt;

            using (SqliteConnection connection = new SqliteConnection("Data Source=nwind.db;")) {
                connection.Open();
                SqliteCommand cmd = (SqliteCommand)SqliteFactory.Instance.CreateCommand();
                cmd.CommandText = "SELECT * FROM OrderDetails\r\nINNER JOIN Products ON Products.ProductID = OrderDetails.ProductID";
                cmd.Connection = connection;
                using (SqliteDataReader dr = cmd.ExecuteReader()) {
                    do {
                        dt = new DataTable();
                        dt.BeginLoadData();
                        dt.Load(dr);
                        dt.EndLoadData();

                    } while (!dr.IsClosed && dr.NextResult());
                }
            }

            // Assign the data source to the PivotGrid control.
            pivotGridControl1.DataSource = dt;
        }
        private void AddField(string caption,FieldArea area,string columnName,int index) {
            PivotGridField field = pivotGridControl1.Fields.Add();
            field.Caption = caption;
            field.Area = area;
            field.DataBinding = new DataSourceColumnBinding(columnName);
            field.AreaIndex = index;
        }
        private void PivotGridControl1_CustomCellValue(object sender,PivotCellValueEventArgs e) {
            if (e.ColumnValueType == FieldValueType.GrandTotal
                   && e.DataField == fieldDiscount)
                e.Value = null;
        }
    }
}
