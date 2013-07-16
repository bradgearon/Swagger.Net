using System.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Custom.ApiDescriber
{
    public sealed class DocNavigator
    {
        private readonly XDocument _xdoc;

        static readonly DocNavigator _instance = new DocNavigator();

        public static DocNavigator Instance
        {
            get { return _instance._navigator; }
        }
                           
        private DocNavigator()
        {
            var filename = ConfigurationManager.AppSettings["code_comments_file_name"];
            filename = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.TrimEnd("Swagger.Net.DLL".ToCharArray()) + filename;
            _xdoc = XDocument.Load(filename);
        }
    }
}
