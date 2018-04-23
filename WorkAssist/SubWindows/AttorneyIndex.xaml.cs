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
using System.Data;
using WorkAssist.ViewModel;

namespace WorkAssist.SubWindows
{
    /// <summary>
    /// AttorneyIndex.xaml 的交互逻辑
    /// </summary>
    public partial class AttorneyIndex : Window
    {
        DataSet ds = new DataSet();
        AttorneyStatus ats=new  AttorneyStatus();
        public AttorneyIndex()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            //ds = taskInfos.GetAll();
            //spStatus.DataContext = ats;

            DAL.DepartmentMember members = new DAL.DepartmentMember();
            List<MemberTree> department = new List<MemberTree> (){ GetAllMembers(members.GetAll())};
            memberTree.ItemsSource = department;
            
        }

        private void BtnAttorney_Click(object sender, RoutedEventArgs e)
        {
            //获取代理人状态数据保存在ats对象实例中
            ats= new AttorneyStatus(ds,"舒丁");
            spStatus.DataContext = ats;
        }

        private void TblkAllOA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            detail.ItemsSource = ConvertDStoDTLS(ats.DsAllOA);

        }

        private List<TaskDetails> ConvertDStoDTLS(DataSet ds)
        {
            //新建摘要对象
            List<TaskDetails> taskDetails = new List<TaskDetails>();
            //把国内申请数据转换为摘要数据            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TaskDetails dtls = new TaskDetails(dr);
                taskDetails.Add(dtls);
            }
            return taskDetails;
        }


        /// <summary>
        /// 获取部门所有成员，并以membertree的形式返回
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private MemberTree GetAllMembers(DataSet ds)
        {
            MemberTree Department = new MemberTree();
            Department.Name = "电学部";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["部门"].ToString()=="电子部")
                {
                //新建一个与datarow对应的子树
                MemberTree Company = new MemberTree();
                Company.Name = dr["分公司"].ToString();
                Company.Children = new List<MemberTree>();
                MemberTree Group = new MemberTree();
                Group.Name = dr["组别"].ToString();
                Group.Children = new List<MemberTree>();
                MemberTree Member = new MemberTree();
                Member.Name = dr["姓名"].ToString();

                Group.Children.Add(Member);
                Company.Children.Add(Group);

                //将子树合并到部门树中去
                Department.Add(Company);
                }
            }
            return Department;                
        }

    }
}
