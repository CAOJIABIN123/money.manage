using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace 个人理财
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (userName.Text != "" || passWord.Text != "" || verificationCode.Text != "")
            {
                userName.Text = "";
                passWord.Text = "";
                verificationCode.Text = "";
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connStr = "Database=BillManagement;Data Source=localhost;User Id=root;Password=123456";
            MySqlConnection conn = new MySqlConnection(connStr);
                      conn.Open();
            #region 查询
            //验空
            if (userName.Text == "")
            {
                MessageBox.Show("用户名不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (passWord.Text == "")
            {
                MessageBox.Show("密码不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verificationCode.Text == "")
            {
                MessageBox.Show("验证不能为空", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (verificationCode.Text != textEdit4.Text)
            {
                MessageBox.Show("验证码错误，请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //创建命令
                string username = userName.Text;//获取输入用户名
                string password = passWord.Text;//获取输入密码
                string sqlSel = "select count(*) from UserBill where UserName = '" + username + "' and UserPassWord = '" + password + "'";//查询语句
                MySqlCommand com = new MySqlCommand(sqlSel, conn);
                //判断executeScalar方法返回的参数是否大于0，大于0表示查找有数据
                if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("欢迎加入个人理财系!", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    zhuti home = new zhuti();
                    this.Hide();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("账户或者密码错误！请重新输入", "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                #endregion
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            textEdit4.Text = Convert.ToString(rd.Next(1000, 10000));
        }
    }
}
