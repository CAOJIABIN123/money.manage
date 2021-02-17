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
            //获取收入类别
            string shouruleibie = "";
            if (shouRuLeiBie.ItemIndex != -1)
            {
                shouruleibie = shouRuLeiBie.EditValue.ToString();
            }
            else
            {
                shouRuLeiBie.ItemIndex = 0;
            }
            //获取类别编号
            MySqlCommand cmd2 = new MySqlCommand("Select CateId FROM category WHERE CaName= @lb", conn);
            cmd2.Parameters.AddWithValue("lb", shouruleibie);
            MySqlDataReader reader2 = cmd2.ExecuteReader();//创建MysqlDataReader对象
            int liebieid = 0;
            while (reader2.Read()) {

                liebieid = Convert.ToInt32(reader2[0]);
             }
            reader2.Close();
            //获取日期
            string date = "";
            if (rQ.ItemIndex != -1)
            {
                date = rQ.EditValue.ToString();
            }
            else
            {
                rQ.ItemIndex = 0;
            }
            //获取说明
            string shuoming = "";
            shuoming = shuoMing.Text;
            //获取收支人
            string shouzhiren = "";
            CheckEdit[] person = new CheckEdit[] { My, Family, Relative, Friend, Classmate, Other };
            for (int i = 0; i < person.Length; i++) {
                if (person[i].Checked) {

                    shouzhiren += person[i].Text + "";
            }
        }
            //获取金额
            string jiner = "";
            jiner = jinEr.Text;
            //导入数据表
            MySqlCommand cmdd = new MySqlCommand("insert into incomeAndExpenses set InType=@ty,InDate=@dat,Person=@per,Money=@mon,InExplain=@exp,CateId=@cate", conn);
            cmdd.Parameters.AddWithValue("ty", shouruleixing);//添加值
            cmdd.Parameters.AddWithValue("dat", date);
            cmdd.Parameters.AddWithValue("per", shouzhiren);
            cmdd.Parameters.AddWithValue("mon", jiner);
            cmdd.Parameters.AddWithValue("exp", shuoming);
            cmdd.Parameters.AddWithValue("cate", liebieid);