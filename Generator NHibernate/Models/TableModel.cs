using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadAPP.Models
{
    public class TableModel
    {
        public virtual int object_id { get; set; }
        public virtual string name { get; set; }
        public virtual int is_identity { get; set; }

    }
}
