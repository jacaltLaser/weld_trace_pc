using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace 星链激光制管机控制软件
{

    public class DataBase
    {
        private static string basePath= System.Environment.CurrentDirectory + @"\DataBase.mdb";//记录数据库
        private OleDbConnection dbConnection;
        private string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + basePath + ";";
        public DataBase()
        {
            dbConnection = new OleDbConnection(strConnection);
            // DataBaseToDataSet();
        }


        private OleDbCommand dbCommonand;
        private string strCommonand = "";
        public string StrCommonand
        {
            get
            {
                return strCommonand;
            }
            set
            {
                dbConnection = new OleDbConnection(strConnection);
                dbCommonand = new OleDbCommand(StrCommonand, dbConnection);
                strCommonand = value;
            }
        }



        /// <summary>
        /// 打开数据库的连接，异常提示 :打开数据库文件出错
        /// </summary>
        /// <returns></returns>
        public bool OpendbConn(OleDbConnection dbConnect)
        {
            if (dbConnect.State != ConnectionState.Open)
            {
                try
                {
                    if (new FileInfo(basePath).Exists)//数据库是否存在
                    {
                        dbConnect.Open();
                        if (dbConnect.State == ConnectionState.Open)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开数据库文件出错 :" + ex.Message,  "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return true;
        }
        /// <summary>
        /// 关闭数据库的连接，异常提示 :关闭数据库文件出错
        /// </summary>
        /// <returns></returns>
        public bool ClosedbConn(OleDbConnection dbConnect)
        {
            if (dbConnect.State != ConnectionState.Closed)
            {
                try
                {
                    dbConnect.Close();
                    if (dbConnect.State == ConnectionState.Closed)
                        return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭数据库文件出错 :" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }



        /// <summary> 
        /// 获取表的datatable
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable GetdataTable(string table)
        {
            DataSet dataSet = new DataSet();
            //连接数据库
            OleDbConnection dbConn = new OleDbConnection(strConnection);

            if (OpendbConn(dbConn))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from " + table, dbConn);
                //填充DataSet
                if (dataSet != null)
                {
                    adapter.Fill(dataSet, table);
                }
            }
            ClosedbConn(dbConn);

           

            DataTable dtNew = new DataTable();
            try
            {
                dtNew = LinqSortDataTable(dataSet.Tables[0], false);
            }
            catch { }

            
            dtNew.PrimaryKey = new DataColumn[] { dtNew.Columns[0]};
           

            return dtNew;

        }
        /// <summary>
        /// 数据表的排序
        /// </summary>
        /// <param name="tmpDt">要排序的表</param>
        /// <param name="flag">ture;升序，false:降序</param>
        /// <returns></returns>
        public DataTable LinqSortDataTable(DataTable tmpDt, bool flag)
        {
            DataTable dtsort = tmpDt.Clone();

            for (int i = 0; i < dtsort.Rows.Count; i++)
            {
                dtsort.Rows[i][0] = i + 1;
            }
            if (tmpDt.Rows.Count > 0)
            {
                if (flag)
                    dtsort = tmpDt.Rows.Cast<DataRow>().OrderBy(r => Convert.ToDecimal(r["ID"])).CopyToDataTable();
                else
                    dtsort = tmpDt.Rows.Cast<DataRow>().OrderByDescending(r => Convert.ToDecimal(r["ID"])).CopyToDataTable();
            }

            return dtsort;
        }
        /// <summary>
        /// 更新数据表
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdatedataTable(string tablename, DataTable table)
        {
            bool succFlag = false;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);
            //连接数据库
            OleDbConnection dbConn = new OleDbConnection(strConnection);
            try
            {
                if (OpendbConn(dbConn))
                {
                    //将DataSet变换显示在与其关联的目标数据库
                    OleDbDataAdapter adapter = new OleDbDataAdapter("select * from " + tablename, dbConn);
                    OleDbCommandBuilder commdBuilder = new OleDbCommandBuilder(adapter);
                    commdBuilder.QuotePrefix = "[";
                    commdBuilder.QuoteSuffix = "]";
                    adapter.Update(table);
                    table.AcceptChanges();
                    commdBuilder.RefreshSchema();
                }
                succFlag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新数据库文件出错 :" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                succFlag = false;
            }
            finally
            {
                ClosedbConn(dbConn);
            }
            return succFlag;
        }

        /// <summary>
        /// 根据name和value获取表中对应的DataRow
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataRow getRowFormDataTalbe(string name, string value, DataTable table)
        {
            DataRow[] getRow;
            string findStr = name+"='" + value + "'";
            getRow = table.Select(findStr);
            if (getRow.Count() > 0)
                return getRow[0];

            return null;
        }

        /// <summary>
        /// 对连接的数据库执行响应的处理指令
        /// </summary>
        /// <param name="connectStr"> 定义的数据库连接字符串 </param>
        /// <param name="sqlStr"> 要执行的SQL指令 </param>
        public void sqlCmd(string sqlStr)
        {
            //连接数据库
            OleDbConnection dbConn = new OleDbConnection(strConnection);
            try
            {
                if (OpendbConn(dbConn))
                {
                    //注意增删改查的代码均插入在该行代码之后
                    OleDbCommand comm = dbConn.CreateCommand();
                    comm.CommandText = sqlStr;
                    comm.Connection = dbConn;

                    //这句话位置只能放在这里，不能前边
                    comm.ExecuteNonQuery();
                    comm.Dispose();
                    
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                dbConn.Close();
            }
        }
        /************************************************************************************************************************************************************/
        //DataSet :对应数据库表的一个集合，实际上是数据库表在内存中的一个缓存

        //DataTable :对应数据库表，是数据库表行的集合

        //DataRow :对应数据库表-行

        //OleDbConnection :建立数据库连接

        //OleDbDataAdapter :由数据库生成DataSet,并负责DataSet与数据库的同步

        //OleDbCommandBuilder :生成更新数据库所需的指令

        //DataSet、DataTable、DataRow用于数据在缓存中的操作，这上面的操作只有更新到数据库中，修改结果才会被永久保存。
        //OleDbDataAdapter和OleDbCommandBuilder用来生成DataSet，完成数据库更新。

        //OleDbDataAdapter :可以直接和DataSet联系，并操作数据源的，它的功能相对强大一些，因此也比较耗系统资源！

        //OleDbDataReader :则有些类似于ADO中的哪个只读向前的记录集，它最常用在只需要依次读取并显示数据的时候，
        //OleDbDataAdapter来说，他耗用的系统资源要小！其实，OleDbDataReader能实现的功能，OleDbDataAdapter都可以实现，
        //不过从资源使用率的角度考虑我们应该尽量使用前者！但有些功能，却是必须使用OleDbDataAdapter才可以实现的！


        //C#中提供的DataReader可以从数据库中每次提取一条数据

        //SQL常用命令使用方法 :
        //(1) 数据记录筛选 :
        //sql="select * from 数据表 where 字段名=字段值 order by 字段名 [desc]"
        //sql="select * from 数据表 where 字段名 like '%字段值%' order by 字段名 [desc]"
        //sql="select top 10 * from 数据表 where 字段名 order by 字段名 [desc]"
        //sql="select * from 数据表 where 字段名 in ('值1','值2','值3')"
        //sql="select * from 数据表 where 字段名 between 值1 and 值2"
        //(2) 更新数据记录 :
        //sql="update 数据表 set 字段名=字段值 where 条件表达式"
        //sql="update 数据表 set 字段1=值1,字段2=值2 …… 字段n=值n where 条件表达式"
        //(3) 删除数据记录 :
        //sql="delete from 数据表 where 条件表达式"
        //sql="delete from 数据表" (将数据表所有记录删除)
        //(4) 添加数据记录 :
        //sql="insert into 数据表 (字段1,字段2,字段3 …) values (值1,值2,值3 …)"
        //sql="insert into 目标数据表 select * from 源数据表" (把源数据表的记录添加到目标数据表)

        //DataAdapter是 DataSet 与数据源的桥梁。形象的来说，DataAdapter 是一个运输车，它把信息从数据库运到DataSet中，同样也可以把DataSet中的信息运送到数据库中。
        // 我们主要使用 DataAdapter 的 fill 方法来讲数据库的信息运送到 DataSet 中。DataSet 相当于在内存中模拟出一个数据库。
        //所以，从数据库来的信息要同样在 DataSet 中有相应的表（我们一般用数据库中真实的表名来命名）来存储。也就是说，
        //我们要告诉 fill 方法，内存中的目标数据库和目标数据表。需要注意的是，使用 DataAdapter 检索表的全部内容会花费些时间，
        //尤其是在表中有很多行时。这是因为访问数据库，定位和处理数据，然后将数据传输到客户端是需要很长时间的。
        /************************************************************************************************************************************************************/
        /************************************************************************************************************************************************************/
        /************************************************************************************************************************************************************/


    }

}
