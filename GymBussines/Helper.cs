using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymBussines
{
  public static class Helper
    {
        public static void clearText(Control frm)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is TextBox)
                    item.Text = string.Empty;
                if (item is GroupBox)
                    clearText(item);
                if (item is NumericUpDown)
                    ((NumericUpDown)item).Value = 0;
            }


        }
        public static void FillComb(Control Ctrl, DataTable Source, string Display = null, string Value = null)
        {
            if (Ctrl is ComboBox)
            {
            //    DataRow dr = Source.NewRow();
             //   dr[Display] = "اختر";
            //    Source.Rows.InsertAt(dr, 0);

                ((ComboBox)Ctrl).DataSource = Source;
                ((ComboBox)Ctrl).DisplayMember = Display; //dt.Columns["Name"].ToString;
                ((ComboBox)Ctrl).ValueMember = Value;
                ((ComboBox)Ctrl).SelectedIndex = 0;
            }
            else
            {
                ((DataGridView)Ctrl).DataSource = Source;
            }
        

    }
        public static void alertSuccess(this Label l,string message= "تم بنجاح")
        {

            l.ForeColor = Color.Green;
            l.Text = message;
        }
        public static void alertFailed(this Label l,string message="حدث خطأ")
        {

            l.ForeColor = Color.Red;
            l.Text = message;
        }
        public static void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            while (source.SelectedItems.Count > 0)
            {
                source.Items.Remove(source.SelectedItems[0]);
            }
        }
    }

}
