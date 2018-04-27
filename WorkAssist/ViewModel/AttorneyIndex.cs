using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WorkAssist.ViewModel
{
    public class AttorneyIndex
    {
        string name;
        double firstVirsionWeight;//初稿权值
        double doneWeight;//递交权值
        DateTime startDate;//计算区间起始日期
        DateTime endDate;//计算区间结束日期
        int numofDoneOA;//递交OA的数量
        int numofHandled;//经手新申请案件数量
        int numofExceedlimit;//超期案件数量
        int daysofExceedlimit;//超期天数

        public double FirstVirsionWeight { get => firstVirsionWeight; set => firstVirsionWeight = value; }
        public double DoneWeight { get => doneWeight; set => doneWeight = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public int NumofDoneOA { get => numofDoneOA; set => numofDoneOA = value; }
        public int NumofHandled { get => numofHandled; set => numofHandled = value; }
        public int NumofExceedlimit { get => numofExceedlimit; set => numofExceedlimit = value; }
        public int DaysofExceedlimit { get => daysofExceedlimit; set => daysofExceedlimit = value; }
        public string Name { get => name; set => name = value; }

        public AttorneyIndex(DataSet ds, DateTime startdate, DateTime enddate)
        {
            startDate = startdate;
            endDate = enddate;
            firstVirsionWeight = 0;
            doneWeight = 0;
            numofDoneOA = 0;
            numofHandled = 0;
            numofExceedlimit = 0;
            daysofExceedlimit = 0;

            //根据起始日期和结束日期计算区间段内的各种指标

            List<TaskDetails> tds = ConvertDStoDTLS(ds);
            foreach (TaskDetails td in tds)
            {
                //初稿权值累加
                if (td.FirstVirsionDate>=startDate && td.FirstVirsionDate<=endDate)
                {
                    firstVirsionWeight = firstVirsionWeight + td.Weight;
                    if (td.TaskName == "OA答复")
                    {
                        numofDoneOA = numofDoneOA + 1;
                    }
                }
                //递交权值累加
                if (td.DoneDate >= startDate && td.DoneDate <= endDate)
                {
                    doneWeight = doneWeight + td.Weight;

                }
                //经手新申请数量累加
                if (td.TaskName=="新申请")
                {
                    numofHandled = numofHandled + 1;
                }
                //超期新申请数量及超期天数累加：完成了初稿，但记录超期
                if (td.TaskName == "新申请" && td.FirstVirsionDate>td.FirstVirsionDeadlineOutside)
                {
                    numofExceedlimit = numofExceedlimit + 1;
                    daysofExceedlimit = (td.FirstVirsionDate - td.FirstVirsionDeadlineOutside).Value.Days;
                }

                //超期新申请数量累加：未完成初稿，但初稿期限已过。
                if (td.TaskName == "新申请" && td.FirstVirsionDeadlineOutside < DateTime.Now.Date)
                {
                    numofExceedlimit = numofExceedlimit + 1;
                    daysofExceedlimit = (DateTime.Now.Date-td.FirstVirsionDeadlineOutside).Value.Days;
                }
            }

        }

        /// <summary>
        /// 把dataset转换为taskdetails
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
      
    }
}
