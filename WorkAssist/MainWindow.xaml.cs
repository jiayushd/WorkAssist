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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkAssist.DAL;
using WorkAssist.Model;
using WorkAssist.ViewModel;
using System.Data;
using WorkAssist.SubWindows;

namespace WorkAssist
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet ds = new DataSet();
        string currentUser;
        public string CurrentUser { get => currentUser; set => currentUser = value; }
        
        public MainWindow()
        {
            InitializeComponent();
            currentUser = "舒丁";
        }

        #region 各种固定分类

        /// <summary>
        /// 点击“国内”按钮在listview上展示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCN_Click(object sender, RoutedEventArgs e)
        {
            //使用数据访问层获取所有国内申请数据
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds.Clear();
            ds= taskInfos.GetAll_Not_Done();
            //使用listview展示
            abstracts.ItemsSource = null;
            abstracts.ItemsSource = ConvertDStoABS(ds);            
        }

        /// <summary>
        /// 点击“所有OA”按钮在listview上展示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllOA_Click(object sender, RoutedEventArgs e)
        {
            //使用数据访问层获取所有国内申请数据
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds.Clear();
            ds = taskInfos.GetAllOA_Not_Done();
            //使用listview展示
            abstracts.ItemsSource = null;
            abstracts.ItemsSource = ConvertDStoABS(ds);
            
        }

        /// <summary>
        /// 点击“30天内OA”按钮在listview上展示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOAin30_Click(object sender, RoutedEventArgs e)
        {
            //使用数据访问层获取所有国内申请数据
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds.Clear();
            ds = taskInfos.GetAllOA_Not_Done();
            //使用listview展示
            abstracts.ItemsSource = null;
            abstracts.ItemsSource = ConvertDStoABS(ds);
            
        }

        /// <summary>
        /// 选择listview中的一项后，展示详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Abstracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskAbstract tab = (TaskAbstract)abstracts.SelectedItem;
            if (tab != null)
            {
                //ds中的表设置主键
                DataColumn[] clos = new DataColumn[1];
                clos[0] = ds.Tables[0].Columns["案件任务ID"];
                ds.Tables[0].PrimaryKey = clos;
                //从ds中查找到选中的任务所对应的数据行
                DataRow dr = ds.Tables[0].Rows.Find(tab.TaskID);
                //将数据行转换为TaskDetails
                TaskDetails details = new TaskDetails(dr);                
                //进行展示
                spDetail.DataContext = details;
            }
        }

        /// <summary>
        /// 把dataset里面的数据转换成TaskAbstract的list
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private List<TaskAbstract> ConvertDStoABS(DataSet ds)
        {
            //新建摘要对象
            List<TaskAbstract> taskAbstracts = new List<TaskAbstract>();
            //把国内申请数据转换为摘要数据            
            foreach (DataRow dr in ds.Tables[0].Rows)                
            {
                if (dr["承办人"].ToString() == currentUser)
                {
                    TaskAbstract tab = new TaskAbstract(dr);
                    taskAbstracts.Add(tab);
                }
            }
            return taskAbstracts;
        }

        #endregion

        private void BtnDataSearch_Click(object sender, RoutedEventArgs e)
        {
            DataSearch searchWindow = new DataSearch();
            searchWindow.Show();
        }

        private void BtnAttorneyIndex_Click(object sender, RoutedEventArgs e)
        {
            AttorneyIndex attorneyidx = new AttorneyIndex();
            attorneyidx.Show();
        }

        private void BtnDepartmentMember_Click(object sender, RoutedEventArgs e)
        {
            SubWindows. DepartmentMember dm = new SubWindows.DepartmentMember();
            dm.Show();
        }
    }
}
