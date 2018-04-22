using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;


namespace WorkAssist.DAL
{
    public class DBAccess
    {
        //定义连接对象
        OleDbConnection cnn = null;
        //定义文件位置
        string strPath="";
        //定义连接字符串
        string strCon = "";


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public DBAccess(string path)
        {
            //实例化连接对象
            strPath = path;
            strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath;
            cnn = new OleDbConnection(strCon);            
        }

        /// <summary>
        /// 增/删/改的操作
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public bool ExcuteSQL(string strSQL)
        {
            int res = 0;
            try
            {
                //打开连接
                cnn.Open();
                //定义命令对象
                OleDbCommand command = new OleDbCommand(strSQL, cnn);
                res = command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                cnn.Close();
            }
            return res > 0;
        }

        /// <summary>
        /// 通过查询得到数据集
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataSet GetDataSetBySQL(string strSQL)
        {
            DataSet ds = new DataSet();
            try
            {                
                cnn.Open();//打开连接
                //定义适配器对象
                OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, cnn);
                //填充表
                adapter.Fill(ds);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {                
                cnn.Close();//关闭连接
            }
            //返回数据集
            return ds;
        }

    }
}
