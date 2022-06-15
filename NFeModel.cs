using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    internal class NFeModel
    {
        public string nfeAccessKey { get; set; } = String.Empty;
        public string cUF { get; set; } = String.Empty;
        public string nNF { get; set; } = String.Empty;
        public string serie { get; set; } = String.Empty;
        public string emitCNPJ { get; set; } = String.Empty;
        public string emitNome { get; set; } = String.Empty;
        public string destCNPJ { get; set; } = String.Empty;
        public string destNome { get; set; } = String.Empty;
        public List<NFeModel> nfesReferenced { get; set; } = new List<NFeModel>();
        
    }
}
