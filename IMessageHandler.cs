using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_enricher
{
    public interface IMessageHandler
    {
        void PublishMessage(string message);
    }
}
