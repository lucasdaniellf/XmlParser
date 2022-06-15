using System.Xml.Linq;

namespace XmlParser
{
    internal class XmlParserService
    {

        private Repository repository = new Repository();

        internal NFeModel ParseXml(string key)
        {
            string xml = repository.getXmlByKeyAccess(key);
            if (string.IsNullOrEmpty(xml))
            {
                return new NFeModel()
                {
                    nfeAccessKey = key
                };
            }
            //Tratar possíveis exceções quando fazendo o map xml
            XElement element = XElement.Parse(xml);
            IEnumerable<XElement> children = element.Elements();
            return MapXmlToObject(children.First());
        }

        private NFeModel MapXmlToObject(XElement element)
        {
            string xmlNamespace = "{http://www.portalfiscal.inf.br/nfe}";

            NFeModel model = new NFeModel()
            {
                nfeAccessKey = element.Attribute("Id")?.Value ?? string.Empty,
                cUF = element.Element(xmlNamespace+"ide")?.Element(xmlNamespace + "cUF")?.Value ?? string.Empty,
                nNF = element.Element(xmlNamespace + "ide")?.Element(xmlNamespace + "nNF")?.Value ?? string.Empty,
                serie = element.Element(xmlNamespace + "ide")?.Element(xmlNamespace + "serie")?.Value ?? string.Empty,
                emitCNPJ = element.Element(xmlNamespace + "emit")?.Element(xmlNamespace + "CNPJ")?.Value ?? string.Empty,
                emitNome = element.Element(xmlNamespace + "emit")?.Element(xmlNamespace + "xNome")?.Value ?? string.Empty,
                destCNPJ = element.Element(xmlNamespace + "dest")?.Element(xmlNamespace + "CNPJ")?.Value ?? string.Empty,
                destNome = element.Element(xmlNamespace + "dest")?.Element(xmlNamespace + "xNome")?.Value ?? string.Empty,
            };

            foreach (XElement nfes in element.Elements(xmlNamespace + "refNFe"))
            {
                model.nfesReferenced.Add(ParseXml(nfes.Value));
            }

            return model;

        }
    }
}
