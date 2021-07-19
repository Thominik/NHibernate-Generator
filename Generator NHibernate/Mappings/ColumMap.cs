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
    public class ColumMap : ClassMapping<ColumModel>
    {

        public ColumMap()
        {         
            Schema("dbo");

            Table("sys.columns");

            Id(x => x.object_id, map => map.Generator(Generators.Identity));

            Property(x => x.column_id);

            Property(x => x.name);

            Property(x => x.system_type_id);

            Property(x => x.max_length);

            Property(x => x.precision);

            Property(x => x.scale);
        }
    }
}
