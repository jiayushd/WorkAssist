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
        //ViewModel.AttorneyIndex ai;
        public AttorneyIndex()
        {
            InitializeComponent();
            
            dpStart.SelectedDate = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            dpEnd.SelectedDate = DateTime.Now.Date;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds = taskInfos.GetAll();
            
            //spStatus.DataContext = ats;

            DAL.DepartmentMember members = new DAL.DepartmentMember();
            DataSet dsmem = members.GetAll();
            //MessageBox.Show(dsmem.Tables[0].Rows[0]["在职状态"].ToString());
            List<MemberTree> department = new List<MemberTree> (){ GetAllMembers(dsmem) };
            memberTree.ItemsSource = department;
            
        }


        #region 私有方法

        /// <summary>
        /// 将ds转换为案件详情taskdetails
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
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
                if (dr["部门"].ToString()=="电子部" && dr["在职状态"].ToString()!="False")
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

        /// <summary>
        /// 获取某个节点上的所有叶子节点，也即所有的代理人
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        private List<MemberTree> GetAllLeafofOneNode(MemberTree mt)
        {
            List<MemberTree> leafs = new List<MemberTree>();

            if (mt.Children!=null)
            {
                foreach (MemberTree mtchild in mt.Children)
                {
                    foreach (MemberTree mtleaf in GetAllLeafofOneNode(mtchild))
                    {
                        leafs.Add(mtleaf);
                    }
                }

            }
            else
            {
                leafs.Add(mt);
            }

            return leafs;
        }

        /// <summary>
        /// 如果是叶子节点，则获取指标详情
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        private ViewModel.AttorneyIndex GetAttorneyIndexofOne(MemberTree mt)
        {
            DataRow[] drs = ds.Tables[0].Select("承办人 LIKE '" + mt.Name + "'");
            DataSet dstemp = new DataSet();
            dstemp = ds.Clone();
            foreach (DataRow dr in drs)
            {
                dstemp.Tables[0].Rows.Add(dr.ItemArray);
            }
            ViewModel.AttorneyIndex aii = new ViewModel.AttorneyIndex(dstemp, dpStart.SelectedDate, dpEnd.SelectedDate);
            aii.Name = mt.Name;
            aii.PercentofExceed= Math.Round(aii.PercentofExceed, 3);
            return aii;
        }
        #endregion


        /// <summary>
        /// 点击节点的处理逻辑：获取该节点下的所有人名，并生成指标数据填入表中。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            List<MemberTree> leafs = new List<MemberTree>();//创建叶子列表用于保存所有的叶子节点
            MemberTree mt = new MemberTree();//创建成员树对象，用于保存所选择的节点数实例
            List<ViewModel.AttorneyIndex> indices = new List<ViewModel.AttorneyIndex>();//创建指标详情列表，用于保存所选择的节点下的所有叶子节点的指标详情

            mt = (MemberTree)memberTree.SelectedItem;
            leafs = GetAllLeafofOneNode(mt);

            foreach (MemberTree leaf in leafs)
            {
                indices.Add(GetAttorneyIndexofOne(leaf));
            }

            dgDetail.ItemsSource = indices;

            //MemberTree mt = new MemberTree();
            //mt = (MemberTree)memberTree.SelectedItem;

            //if (mt.Children==null)
            //{
            //    DataRow[] drs= ds.Tables[0].Select("承办人 LIKE '"+mt.Name+"'");
            //    DataSet dstemp = new DataSet();
            //    dstemp = ds.Clone();
            //    foreach (DataRow dr in drs)
            //    {
            //        dstemp.Tables[0].Rows.Add(dr.ItemArray);
            //    }
            //    ai = new ViewModel.AttorneyIndex(dstemp,dpStart.SelectedDate,dpEnd.SelectedDate);
            //    spIndex.DataContext = ai;
        }

    

        #region 个人案件状态区各数字点击后展示相关的列表
        private void TblkAllOA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            detail.ItemsSource = ConvertDStoDTLS(ats.DsAllOA);

        }

        #endregion

        #region 指标详情区各数字点击后展示相关的列表
        private void TbNumofHandled_MouseDown(object sender, MouseButtonEventArgs e)
            {

                //TaskList tl = new TaskList(ai.TdsHandled);
                //tl.Show();

            }

        private void TbNumofExceedlimit_MouseDown(object sender, MouseButtonEventArgs e)
            {

                //TaskList tl = new TaskList(ai.TdsExceedlimit);
                //tl.Show();
            }

        #endregion


    }
}
