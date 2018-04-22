using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkAssist.Model
{
    public class TaskInfo
    {
        string taskID;
        string taskName;
        string taskAttribute;
        string taskCatogry;
        string attorney;
        DateTime? distributeDate;
        DateTime? firstVirsionDeadlineInternal;
        DateTime? firstVirsionDeadlineOutside;
        DateTime? firstVirsionDate;
        DateTime? doneDeadlineInternal;
        DateTime? doneDeadlineOutside;
        DateTime? officalDeadline;
        DateTime? doneDate;
        string processStage;
        string taskStatus;
        double weight;
        string caseID;

        public string TaskID { get => taskID; set => taskID = value; }
        public string TaskName { get => taskName; set => taskName = value; }
        public string TaskAttribute { get => taskAttribute; set => taskAttribute = value; }
        public string TaskCatogry { get => taskCatogry; set => taskCatogry = value; }
        public string Attorney { get => attorney; set => attorney = value; }
        public DateTime? DistributeDate { get => distributeDate; set => distributeDate = value; }
        public DateTime? FirstVirsionDeadlineInternal { get => firstVirsionDeadlineInternal; set => firstVirsionDeadlineInternal = value; }
        public DateTime? FirstVirsionDeadlineOutside { get => firstVirsionDeadlineOutside; set => firstVirsionDeadlineOutside = value; }
        public DateTime? FirstVirsionDate { get => firstVirsionDate; set => firstVirsionDate = value; }
        public DateTime? DoneDeadlineInternal { get => doneDeadlineInternal; set => doneDeadlineInternal = value; }
        public DateTime? DoneDeadlineOutside { get => doneDeadlineOutside; set => doneDeadlineOutside = value; }
        public DateTime? OfficalDeadline { get => officalDeadline; set => officalDeadline = value; }
        public DateTime? DoneDate { get => doneDate; set => doneDate = value; }
        public string ProcessStage { get => processStage; set => processStage = value; }
        public string TaskStatus { get => taskStatus; set => taskStatus = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public double Weight { get => weight; set => weight = value; }
    }
}
