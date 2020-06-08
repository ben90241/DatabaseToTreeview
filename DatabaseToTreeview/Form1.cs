using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseToTreeview
{

    public partial class Form1 : Form
    {
        SqlConnection sqlCn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Benson\source\repos\DatabaseToTreeview\DatabaseToTreeview\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("select * from Table", sqlCn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from [Table]", sqlCn);
            da.Fill(dt);
            treeView1.Nodes.Clear();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                TreeNode node = new TreeNode("Item# "+i);
                foreach (DataColumn col in dt.Columns)
                {
                    node.Nodes.Add(col.ColumnName.ToString()+": "+row[col.ColumnName].ToString());
                }
                treeView1.Nodes.Add(node);
            }
        }
    }

}
