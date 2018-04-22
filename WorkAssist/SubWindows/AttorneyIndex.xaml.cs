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
            DAL.TaskInfo taskInfos = new DAL.TaskInfo();
            ds = taskInfos.GetAll();
            spStatus.DataContext = ats;
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
    }
}
