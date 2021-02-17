using DevExpress.XtraEditors;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 个人理财
{
    public partial class incomeExpenditure : DevExpress.XtraEditors.XtraForm
    {
        public incomeExpenditure()
        {
            InitializeComponent();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void incomeExpenditure_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connStr = "Database=BillManagement;Data Source=localhost;User Id=root;Password=123456";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string shouruleixing = "";
            if (shouRU.Checked)
            {
                shouruleixing = "0";
            }
            else
            {
                shouruleixing = "1";

            }
            DataRow shouruleibie = ((System.Data.DataRowView)shouRuLeiBie.GetSelectedDataRow()).Row;
            shouruleibie["Name"].ToString();
            MySqlCommand cmd2 = new MySqlCommand("Select CateId FROM category WHERE CaName= @lb", conn);
        }
}