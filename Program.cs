
// See https://aka.ms/new-console-template for more information

using XmlParser;
using Newtonsoft.Json;
using IronXL;

XmlParserService xmlParserService = new XmlParserService();
List<NFeModel> nfes = new List<NFeModel>();

//We read from xls file when the time comes

//Tratar possíveis exceções quando lendo xlsx
WorkBook workBook = WorkBook.Load("D:\\Programação\\XmlParser\\nfes.xlsx");
WorkSheet sheet = workBook.WorkSheets.First();
foreach(var nf in sheet.Columns.First())
{
    nfes.Add(xmlParserService.ParseXml(nf.Text));
}

var json = JsonConvert.SerializeObject(nfes, Formatting.Indented);
Console.WriteLine(json);
Console.ReadLine();
