using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkAssist.Model
{
    class CaseInfo
    {
        List<TaskInfo> tasklist;
        string caseID;//案件ID
        string attorneySeries;//我方案号
        string clientSeries;//客户案号
        string applicationID;//申请号
        DateTime entrustDate;//委托日期
        string salesmanID;//案源人
        string clientID;//客户名称
        string techdocumentName;//开案名称
        string casedocumentName;//案件名称
        string extraInfo;//备注信息
        string appType;//申请类型
        string appStatus;//内部状态
        DateTime applicationDate;//申请日

        public string CaseID { get => caseID; set => caseID = value; }
        public string AttorneySeries { get => attorneySeries; set => attorneySeries = value; }
        public string ClientSeries { get => clientSeries; set => clientSeries = value; }
        public string ApplicationID { get => applicationID; set => applicationID = value; }
        public DateTime EntrustDate { get => entrustDate; set => entrustDate = value; }
        public string SalesmanID { get => salesmanID; set => salesmanID = value; }
        public string ClientID { get => clientID; set => clientID = value; }
        public string TechdocumentName { get => techdocumentName; set => techdocumentName = value; }
        public string CasedocumentName { get => casedocumentName; set => casedocumentName = value; }
        public string ExtraInfo { get => extraInfo; set => extraInfo = value; }
        public string AppType { get => appType; set => appType = value; }
        public string AppStatus { get => appStatus; set => appStatus = value; }
        public DateTime ApplicationDate { get => applicationDate; set => applicationDate = value; }
    }
}
