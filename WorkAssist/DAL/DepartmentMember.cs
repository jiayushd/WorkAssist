using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WorkAssist.DAL
{
    public class DepartmentMember
    {

        public DataSet GetAll()
        {
            //定义查询语句
            string strSQL = "SELECT * FROM 公司职员 ";

            DBAccess db = new DBAccess("C:\\WORK\\MyData\\数据集.accdb");
            return db.GetDataSetBySQL(strSQL);
        }
    }
}
