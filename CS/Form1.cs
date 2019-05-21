using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;

namespace Q143749 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button == navigator.Buttons.CustomButtons[0]) {
                FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(navigator.ViewInfo.Buttons);
                Point mousePosition = navigator.PointToClient(Control.MousePosition);
                NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                menuPosition = navigator.PointToScreen(menuPosition);
                popupMenu1.ShowPopup(menuPosition);
            }
        }

        DataTable CreateTable()
        {
            DataTable table = new DataTable();
            DataRow dataRow;

            table.Columns.Add("Prod_NO", typeof(string));
            table.Columns.Add("Prod_Name", typeof(string));
            table.Columns.Add("Order_Date", typeof(string));
            table.Columns.Add("Quantity", typeof(string));

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "101";
            dataRow["Prod_Name"] = "Product1";
            dataRow["Order_Date"] = "12/06/2012";
            dataRow["Quantity"] = "50";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "102";
            dataRow["Prod_Name"] = "Product2";
            dataRow["Order_Date"] = "15/06/2012";
            dataRow["Quantity"] = "70";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "102";
            dataRow["Prod_Name"] = "Product2";
            dataRow["Order_Date"] = "15/06/2012";
            dataRow["Quantity"] = "70";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "103";
            dataRow["Prod_Name"] = "Product3";
            dataRow["Order_Date"] = "18/06/2012";
            dataRow["Quantity"] = "30";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "104";
            dataRow["Prod_Name"] = "Product4";
            dataRow["Order_Date"] = "25/06/2012";
            dataRow["Quantity"] = "20";
            table.Rows.Add(dataRow);

            return table;
        }

        private void Form1_Load(object sender, EventArgs e) {
            gridControl1.DataSource = CreateTable();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
    }
}