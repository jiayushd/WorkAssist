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
    /// DataSearch.xaml 的交互逻辑
    /// </summary>
    public partial class DataSearch : Window
    {
        DataSet ds=new DataSet();
        public DataSearch()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds = taskInfos.GetAll();
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
        /// 点击初稿查询时，查询所有的初稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFirstVirsion_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = dpStartDate.SelectedDate.Value;
            DateTime endDate = dpEndDate.SelectedDate.Value;
            lvwTaskList.ItemsSource = null;
            lvwTaskList.ItemsSource = ConvertDStoDTLS(FirstVirsionInDateInterval(ds,startDate,endDate));
        }

        /// <summary>
        /// 点击提交查询时，查询所有的提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = dpStartDate.SelectedDate.Value;
            DateTime endDate = dpEndDate.SelectedDate.Value;
            lvwTaskList.ItemsSource = null;
            lvwTaskList.ItemsSource = ConvertDStoDTLS(DoneInDateInterval(ds, startDate, endDate));

        }


        /// <summary>
        /// 从ds（全局变量）中筛选出设定时间段内的初稿
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private DataSet FirstVirsionInDateInterval(DataSet ds, DateTime startDate, DateTime endDate)
        {
            DataSet dsTemp = new DataSet();
            dsTemp = ds.Clone();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["初稿日"].ToString() != "" && (DateTime)dr["初稿日"] >= startDate && (DateTime)dr["初稿日"] <= endDate)
                {
                    dsTemp.Tables[0].Rows.Add(dr.ItemArray);
                }
            }
            return dsTemp;
        }

        /// <summary>
        /// 从ds（全局变量）中筛选出设定时间段内的递交
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private DataSet DoneInDateInterval(DataSet ds, DateTime startDate, DateTime endDate)
        {
            DataSet dsTemp = new DataSet();
            dsTemp = ds.Clone();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["完成日"].ToString() != "" && (DateTime)dr["完成日"] >= startDate && (DateTime)dr["完成日"] <= endDate)
                {
                    dsTemp.Tables[0].Rows.Add(dr.ItemArray);
                }
            }
            return dsTemp;
        }


    }
}
