using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_enricher
{
    public  class IChatMessage
    {
        public string Text { get; set; }
        public object[] Extractions { get; set; }

    }
}
