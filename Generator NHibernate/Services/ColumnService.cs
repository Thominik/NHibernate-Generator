using DownloadAPP.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace DownloadAPP.Services
{
    public class ColumnService
    {
        public IList<ColumModel> GetAll()
        {
            using (ISession session = NHService.OpenSession())
            {
                var allColums = session.Query<ColumModel>().ToList();
                return allColums;
            }
        }
    }
}
