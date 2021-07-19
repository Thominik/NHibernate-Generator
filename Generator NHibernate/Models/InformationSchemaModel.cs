using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadAPP.Models
{
    public class InformationSchemaModel
    {
        public virtual int ORDINAL_POSITION { get; set; }

        public virtual string COLUMN_NAME { get; set; }

        public virtual string DATA_TYPE { get; set; }

        public virtual int CHARACTER_MAXIMUM_LENGTH { get; set; }

        public virtual string IS_NULLABLE { get; set; }

        public virtual bool  is_identity { get; set; }
    }
}
