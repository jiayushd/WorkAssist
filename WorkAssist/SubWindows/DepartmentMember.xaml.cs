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
    /// DepartmentMember.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentMember : Window
    {
        DataSet ds = new DataSet();
        public DepartmentMember()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            DAL.DepartmentMember members = new DAL.DepartmentMember();
            ds = members.GetAll();
            chkbxIsOnJob.IsChecked = false;
            List<MemberTree> department = new List<MemberTree>() { GetAllActiveMembers(ds) };
            memberTree.ItemsSource = department;
            btnEdit.IsEnabled = false;

        }



        /// <summary>
        /// 获取部门所有成员，并以membertree的形式返回
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private MemberTree GetAllActiveMembers(DataSet ds)
        {
            MemberTree Department = new MemberTree();
            Department.Name = "电学部";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["部门"].ToString() == "电子部" && dr["在职状态"].ToString() != "False")
                {
                    //新建一个与datarow对应的子树
                    MemberTree Company = new MemberTree();
                    Company.Name = dr["分公司"].ToString();
                    Company.Children = new List<MemberTree>();
                    MemberTree Group = new MemberTree();
                    Group.Name = dr["组别"].ToString();
                    Group.Children = new List<MemberTree>();
                    MemberTree Member = new MemberTree();
                    //Member.Name = dr["姓名"].ToString()+"("+dr["系统账号"].ToString()+")";
                    Member.Name = dr["姓名"].ToString();

                    Member.Account = dr["系统账号"].ToString();

                    Group.Children.Add(Member);
                    Company.Children.Add(Group);

                    //将子树合并到部门树中去
                    Department.Add(Company);
                }
            }
            return Department;
        }

        /// <summary>
        /// 获取部门所有活动成员，并以membertree的形式返回
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private MemberTree GetAllMembers(DataSet ds)
        {
            MemberTree Department = new MemberTree();
            Department.Name = "电学部";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["部门"].ToString() == "电子部")
                {
                    //新建一个与datarow对应的子树
                    MemberTree Company = new MemberTree();
                    Company.Name = dr["分公司"].ToString();
                    Company.Children = new List<MemberTree>();
                    MemberTree Group = new MemberTree();
                    Group.Name = dr["组别"].ToString();
                    Group.Children = new List<MemberTree>();
                    MemberTree Member = new MemberTree();
                    //Member.Name = dr["姓名"].ToString()+"("+dr["系统账号"].ToString()+")";
                    Member.Name = dr["姓名"].ToString();

                    Member.Account = dr["系统账号"].ToString();

                    Group.Children.Add(Member);
                    Company.Children.Add(Group);

                    //将子树合并到部门树中去
                    Department.Add(Company);
                }
            }
            return Department;
        }

        /// <summary>
        /// 选中一个节点时，若选中的是名字，则显示该名字对应的信息详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MemberTree tvi = (MemberTree)memberTree.SelectedItem;
            string selectStatement = "";
            if (tvi.Account !="")
            {
                 selectStatement = "姓名='" + tvi.Name + "' and 系统账号 LIKE '%" + tvi.Account + "'";
            }
            else
            {
                 selectStatement = "姓名='" + tvi.Name + "'";
            }
            DataRow[] drs = ds.Tables[0].Select(selectStatement);
            if (drs.Count()>0)
            {
                btnEdit.IsEnabled = true;
                gridMemberInfo.DataContext = new MemberInfoDetails(drs[0]);
            }
        }


        /// <summary>
        /// 修改公司职员表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        private bool Update(MemberInfoDetails mid)
        {

            string strSQL = "UPDATE 公司职员 SET ";
            strSQL += "电话='" + mid.PhoneNumber + "',";
            strSQL += "邮箱='"+mid.Email+"',";
            strSQL += "分公司='"+mid.SubCompany+"',";
            strSQL += "部门='"+mid.Department+"',";
            strSQL += "组别='"+mid.Group+"',";
            strSQL += "系统账号='" + mid.Account + "',";
            if (mid.IsOnJob)
            {
                strSQL += "在职状态=1,";
            }
            else
            {
                strSQL += "在职状态=0,";
            }
            if (mid.ProfessionStartDate != null)
            {
                strSQL += "入行时间=#"+mid.ProfessionStartDate.Value.Date+"#,";
            }
            if (mid.CompanyEntryDate != null)
            {
                strSQL += "入职时间=#"+mid.CompanyEntryDate.Value.Date + "#,";
            }
            strSQL += "职业经历='"+mid.WorkingExperience+"'";
            strSQL += " WHERE 姓名='" + mid.Name + "'";

            DAL.DepartmentMember ddm = new DAL.DepartmentMember();
            ds.Clear();
            ds = ddm.GetAll();
            return ddm.ExcuteSQL(strSQL);      

        }



        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MemberInfoDetails mid = (MemberInfoDetails)gridMemberInfo.DataContext;
            string message = IsFormLegal(mid);
            if (message == "")
            {
                if (Update(mid))
                {
                    MessageBox.Show("保存成功！");
                }
            }
            else
            {
                MessageBox.Show(message);
            }


            List<MemberTree> department = new List<MemberTree>() { GetAllMembers(ds) };

            memberTree.ItemsSource = department;

            btnEdit.Visibility = Visibility.Visible;
            txtBoxName.IsEnabled = false;
            txtBoxID.IsEnabled = false;
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertMember im = new InsertMember();
            im.ds = ds;
            im.Show();
        }


        private string IsFormLegal(MemberInfoDetails mid)
        {
            string message="";
            if (mid.Name=="")
            {
                message += "姓名为空！\n";
            }
            if (mid.Account=="")
            {
                message += "账号为空！\n";
            }

            string pattern = @"^\S\d{5}$";
            if (!Regex.IsMatch(mid.Account,pattern))
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtBoxName.IsEnabled = true;
            txtBoxID.IsEnabled = true;
            btnEdit.Visibility = Visibility.Collapsed;
        }

        private void ChkbxIsOnJob_Checked(object sender, RoutedEventArgs e)
        {
            List<MemberTree>  department = new List<MemberTree>() { GetAllMembers(ds) };
            memberTree.ItemsSource = department;
        }

        private void ChkbxIsOnJob_Unchecked(object sender, RoutedEventArgs e)
        {
            List<MemberTree>    department = new List<MemberTree>() { GetAllActiveMembers(ds) };            
            memberTree.ItemsSource = department;
        }
    }
}
