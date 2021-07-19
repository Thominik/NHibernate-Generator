using DownloadAPP.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace DownloadAPP.Services
{
    public class InformationSchemaService
    {
        public IList<InformationSchemaModel> GetSelectedTableData(TableModel table)
        {
            using (ISession session = NHService.OpenSession())
            {
                var x = session.CreateSQLQuery("select inf.ORDINAL_POSITION, inf.COLUMN_NAME, inf.DATA_TYPE, inf.CHARACTER_MAXIMUM_LENGTH, inf.IS_NULLABLE, col.is_identity " +
                    "from  sys.tables tab " +
                    "join sys.columns col on tab.object_id = col.object_id " +
                    "join INFORMATION_SCHEMA.COLUMNS inf on inf.COLUMN_NAME = col.name and inf.TABLE_NAME = tab.name " +
                    $"WHERE tab.name = '{table.name}'").SetResultTransformer(Transformers.AliasToBean(typeof(InformationSchemaModel))).List<InformationSchemaModel>();

                return x;
            }
        }        
    }
}
