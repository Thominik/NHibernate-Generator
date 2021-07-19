using DownloadAPP.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DownloadAPP.Services
{
    public class TableService
    {
        private DataTable dtAccounts = new DataTable();
        SqlConnection cnn;
        IList<string> columnsList = new List<string>();
        IList<string> openMyTable = new List<string>();
        public IList<TableModel> GetAll()
        {
            using (ISession session = NHService.OpenSession())
            {
                IList<TableModel> allTables = session.CreateSQLQuery($"SELECT object_id, name from sys.tables")
                    .SetResultTransformer(Transformers.AliasToBean(typeof(TableModel))).List<TableModel>();
                return allTables;
            }
        }

        public IList<string> GetAllFromTable(TableModel table)
        {

            using (ISession session = NHService.OpenSession())
            {
                columnsList = session.CreateSQLQuery
                    ($"SELECT name from sys.columns WHERE object_id = '{table.object_id}'").List<string>();
            }

            return columnsList;
        }
    }
}
