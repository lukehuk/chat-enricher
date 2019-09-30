using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_enricher
{
    //Class that represents chat messages that have been enriched.
    //Class used during deserialization from JSON.
    public  class EnrichedChatMessage
    {
        public string Text { get; set; }
        public object[] Extractions { get; set; }

    }
}
