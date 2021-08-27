<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578657/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2122)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/HowToBindToMDB/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/HowToBindToMDB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/HowToBindToMDB/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/HowToBindToMDB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to: Display Unbound Data in a PivotGrid Control


<p>This example shows how to add an unbound field to the <strong>PivotGridControl</strong>, to represent the total sum of an order.</p>


<h3>Description</h3>

<p>Assume that the <strong>PivotGridControl</strong> is bound to the <strong>Order Details</strong> datatable (from the <strong>nwind</strong> sample database), which contains <strong>UnitPrice</strong>, <strong>Quantity</strong> and <strong>Discount</strong> fields. There isn&#39;t any field which represents the total sum, however this can be calculated manually as follows: &quot;UnitPrice*Quantity*(1-Discount)&quot;.</p><p>To solve this task, first it is necessary to create a pivot grid field, whose <strong>PivotGridField.UnboundType</strong> property should be set to <strong>FieldUnboundColumnType.Decimal</strong>. Then, you should handle the <strong>PivotGridControl.CustomUnboundFieldData</strong> event and manually populate the field with data.</p>

<br/>


