using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WorkAssist.DAL;

namespace WorkAssist.ViewModel
{
    public class AttorneyStatus
    {
        string name;
        int intCN;
        int intForeign;
        int intTodo;
        int intFirstVirsion;
        int intAllOA;
        int intOAin30;
        DataSet dsCN;
        DataSet dsForeign;
        DataSet dsTodo;
        DataSet dsFirstVirsion;
        DataSet dsAllOA;
        DataSet dsOAin30;

        public int IntCN { get => intCN; set => intCN = value; }
        public int IntForeign { get => intForeign; set => intForeign = value; }
        public int IntTodo { get => intTodo; set => intTodo = value; }
        public int IntFirstVirsion { get => intFirstVirsion; set => intFirstVirsion = value; }
        public string Name { get => name; set => name = value; }
        public int IntAllOA { get => intAllOA; set => intAllOA = value; }
        public int IntOAin30 { get => intOAin30; set => intOAin30 = value; }
        public DataSet DsCN { get => dsCN; set => dsCN = value; }
        public DataSet DsForeign { get => dsForeign; set => dsForeign = value; }
        public DataSet DsTodo { get => dsTodo; set => dsTodo = value; }
        public DataSet DsFirstVirsion { get => dsFirstVirsion; set => dsFirstVirsion = value; }
        public DataSet DsAllOA { get => dsAllOA; set => dsAllOA = value; }
        public DataSet DsOAin30 { get => dsOAin30; set => dsOAin30 = value; }

        public AttorneyStatus()
        {            
            intCN = 0;
            intForeign = 0;
            intTodo = 0;
            intFirstVirsion = 0;
            IntAllOA = 0;
            IntOAin30 = 0;
        }

        /// <summary>
        /// 获取各种固定条件下的所有数据，用名字进行筛选。需要读取6次数据库
        /// </summary>
        /// <param name="name"></param>
        public AttorneyStatus(string name)
        {
            this.name = name;
            intCN = 0;
            intForeign = 0;
            intTodo = 0;
            intFirstVirsion = 0;
            IntAllOA = 0;
            IntOAin30 = 0;

            TaskInfo taskInfo = new TaskInfo();
            foreach (DataRow dr in taskInfo.GetAll_Not_Done().Tables[0].Rows)
            {
                if (dr["承办人"].ToString() == name)
                {
                    intCN++;
                }
            }

        }

        /// <summary>
        /// 从传入的ds中筛选出各个固定条件下的数量
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        public AttorneyStatus(DataSet ds,string name)
        {
            this.name = name;
            intCN = 0;
            intForeign = 0;
            intTodo = 0;
            intFirstVirsion = 0;
            IntAllOA = 0;
            IntOAin30 = 0;

            dsAllOA = ds.Clone();
            dsCN = ds.Clone();
            dsForeign = ds.Clone();
            dsTodo = ds.Clone();
            dsFirstVirsion = ds.Clone();
            dsOAin30 = ds.Clone();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string siftcondition = dr["任务名称"].ToString();
                if (dr["承办人"].ToString() == name)
                {
                    switch (siftcondition)
                    {
                        case "新申请":                            
                            switch (dr["代理人处理状态"].ToString())
                            {
                                case "完成:完成":
                                case "完成:结案":
                                case "不处理:不处理":
                                    break;
                                case "撰写:未处理":
                                case "撰写:撰写中":
                                    intTodo++;
                                    break;
                                default:
                                    intCN++;
                                    break;
                            }
                            break;
                        case "改写":
                        case "撰写":
                            intForeign++;
                            break;
                        case "OA答复":
                        case "驳回提复审（先请客户确认）":
                        case "答复补正":
                            switch (dr["代理人处理状态"].ToString())
                            {
                                case "完成:完成":
                                case "完成:结案":
                                case "不处理:不处理":
                                    break;
                                default:
                                    IntAllOA++;
                                    dsAllOA.Tables[0].Rows.Add(dr.ItemArray);
                                    if (((DateTime)dr["官方期限"] - DateTime.Now.Date).Days<=30)
                                    {
                                        IntOAin30 ++;
                                    }
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    if (dr["代理人处理状态"].ToString() == "返稿:客户确认中" || dr["代理人处理状态"].ToString() == "撰写:客户长期未确认")
                    {
                        intFirstVirsion++;
                    }
                }
            }
        }
    }
}
