using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WorkAssist.DAL
{
    class TaskInfo
    {
        public DataSet GetAll()
        {
            //定义查询语句
            string strSQL = "SELECT * FROM Tasks, Cases ";
            strSQL = strSQL + "WHERE Tasks.案件ID = Cases.案件ID ";
            //strSQL = strSQL + "AND 任务名称 = '新申请' AND (任务状态 NOT IN('代理人-不处理', '代理人-完成')) ";
            //strSQL = strSQL + "AND (代理人处理状态 Not In('完成:完成', '完成:结案')) ";
            //strSQL = strSQL + "AND 完成日 IS NULL ORDER BY[定稿期限(内)]";

            DBAccess db = new DBAccess("C:\\WORK\\MyData\\数据集.accdb");
            return db.GetDataSetBySQL(strSQL);
        }

        /// <summary>
        /// 返回所有未完成的新申请
        /// </summary>
        /// <returns></returns>
        public DataSet GetAll_Not_Done()
        {
            //定义查询语句
            string strSQL = "SELECT * FROM Tasks, Cases "; 
            strSQL = strSQL + "WHERE Tasks.案件ID = Cases.案件ID ";
            strSQL = strSQL + "AND 任务名称 = '新申请' AND (任务状态 NOT IN('代理人-不处理', '代理人-完成')) ";
            strSQL = strSQL + "AND (代理人处理状态 Not In('完成:完成', '完成:结案')) ";
            strSQL = strSQL + "AND 完成日 IS NULL ORDER BY[定稿期限(内)]";

            DBAccess db = new DBAccess("C:\\WORK\\MyData\\数据集.accdb");
            return db.GetDataSetBySQL(strSQL);
        }

        /// <summary>
        /// 返回所有未完成的OA
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllOA_Not_Done()
        {
            //定义查询语句
            string strSQL = "SELECT * FROM Tasks, Cases ";
            strSQL = strSQL + "WHERE Tasks.案件ID = Cases.案件ID ";
            strSQL = strSQL + "AND 任务名称 IN ('OA答复', '驳回提复审（先请客户确认）','答复补正') AND (任务状态 NOT IN('代理人-不处理', '代理人-完成')) ";
            strSQL = strSQL + "AND (代理人处理状态 Not In('完成:完成', '完成:结案')) ";
            strSQL = strSQL + "AND 完成日 IS NULL ORDER BY[官方期限]";

            DBAccess db = new DBAccess("C:\\WORK\\MyData\\数据集.accdb");
            return db.GetDataSetBySQL(strSQL);
        }
    }
}
