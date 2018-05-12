using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkAssist.ViewModel;
using System.Data;
using System.Text.RegularExpressions;

namespace WorkAssist.SubWindows
{
    /// <summary>
    /// InsertMember.xaml 的交互逻辑
    /// </summary>
    public partial class InsertMember : Window
    {
        public DataSet ds = new DataSet();
        public InsertMember()
        {
            InitializeComponent();
            MemberInfoDetails mid = new MemberInfoDetails();
            gridMemberInfo.DataContext = mid;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MemberInfoDetails mid = (MemberInfoDetails)gridMemberInfo.DataContext;
            string message = IsFormLegal(mid);
            if (message == "")
            {
                if (Insert(mid))
                {
                    MessageBox.Show("新增成功！");
                }
            }
            else
            {
                MessageBox.Show(message);
            }


        }

        /// <summary>
        /// 插入公司职员表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        private bool Insert(MemberInfoDetails mid)
        {
            string strSQL = "INSERT INTO 公司职员 ";
            strSQL += "(姓名,电话,邮箱,分公司,部门,组别,系统账号,在职状态,入行时间,入职时间,职业经历) VALUES ";
            strSQL += "('" + mid.Name + "',";
            strSQL += "'" + mid.PhoneNumber + "',";
            strSQL += "'" + mid.Email + "',";
            strSQL += "'" + mid.SubCompany + "',";
            strSQL += "'" + mid.Department + "',";
            strSQL += "'" + mid.Group + "',";
            strSQL += "'" + mid.Account + "',";
            if (mid.IsOnJob)
            {
                strSQL += "1,";
            }
            else
            {
                strSQL += "0,";
            }
            if (mid.ProfessionStartDate != null)
            {
                strSQL += "#" + mid.ProfessionStartDate.Value.Date + "#,";
            }
            else
            {
                strSQL += "null,";
            }
            if (mid.CompanyEntryDate != null)
            {
                strSQL += "#" + mid.CompanyEntryDate.Value.Date + "#,";
            }
            else
            {
                strSQL += "null,";
            }
            strSQL += "'" + mid.WorkingExperience + "')";


            DAL.DepartmentMember ddm = new DAL.DepartmentMember();
            if (ddm.ExcuteSQL(strSQL))
            {
                //ds.Clear();
                //ds = ddm.GetAll();
                //List<MemberTree> department = new List<MemberTree>() { GetAllMembers(ds) };
                //memberTree.ItemsSource = department;
                return true;
            }
            else
                return false;
        }

        private string IsFormLegal(MemberInfoDetails mid)
        {
            string message = "";
            if (mid.Name == "")
            {
                message += "姓名为空！\n";
            }
            if (mid.Account == "")
            {
                message += "账号为空！\n";
            }

            string pattern = @"^\S\d{5}$";
            if (!Regex.IsMatch(mid.Account, pattern))
            {
                message += "账号不符合规范，应为H+5位数字！\n";
            }

            string selectStatement = "系统账号='" + mid.Account + "' ";
            DataRow[] drs = ds.Tables[0].Select(selectStatement);
            if (drs.Count() > 0)
            {
                message += "账号已被使用！\n";
            }

            return message;
        }
    }
}
