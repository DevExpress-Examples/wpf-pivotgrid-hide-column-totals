# How to: Display Unbound Data in a PivotGrid Control


<p>This example shows how to add an unbound field to the <strong>PivotGridControl</strong>, to represent the total sum of an order.</p>


<h3>Description</h3>

<p>Assume that the <strong>PivotGridControl</strong> is bound to the <strong>Order Details</strong> datatable (from the <strong>nwind</strong> sample database), which contains <strong>UnitPrice</strong>, <strong>Quantity</strong> and <strong>Discount</strong> fields. There isn&#39;t any field which represents the total sum, however this can be calculated manually as follows: &quot;UnitPrice*Quantity*(1-Discount)&quot;.</p><p>To solve this task, first it is necessary to create a pivot grid field, whose <strong>PivotGridField.UnboundType</strong> property should be set to <strong>FieldUnboundColumnType.Decimal</strong>. Then, you should handle the <strong>PivotGridControl.CustomUnboundFieldData</strong> event and manually populate the field with data.</p>

<br/>


