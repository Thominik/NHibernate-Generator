using DownloadAPP.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadAPP.Mappings
{
    public class TableMap : ClassMapping<TableModel>
    {
        public TableMap()
        {
            Schema("dbo");

            Table("sys.tables");

            Id(x => x.object_id, map => { map.Generator(Generators.Identity); } );

            Property(x => x.name);
        }
    }
}
