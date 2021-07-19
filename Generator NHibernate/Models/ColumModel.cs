using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadAPP.Models
{
    public class ColumModel
    {
        public virtual int object_id { get; set; }

        public virtual int column_id { get; set; }

        public virtual string name { get; set; }

        public virtual long system_type_id { get; set; }

        public virtual int max_length { get; set; }

        public virtual int precision { get; set; }

        public virtual int scale { get; set; }
    }
}


//select object_id, name from sys.tables

//select object_id, column_id, name, system_type_id, max_length, precision, scale from sys.columns where object_id = 565577053