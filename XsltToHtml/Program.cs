using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace XsltToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            var strPath = Directory.GetCurrentDirectory() + @"\Students.xml";
            var strInput = File.ReadAllText(strPath);



            Console.WriteLine(strInput);
            var html = GetHtml(strInput);
            Console.WriteLine(html);

            Console.ReadLine();
            Console.ReadLine();

        }

        public static string GetHtml(string xml)
        {
            XslCompiledTransform objXSLTransform = new XslCompiledTransform();
            StringBuilder htmlOutput = new StringBuilder();
            try
            {
                var strXSLTFile = Directory.GetCurrentDirectory() + @"\Students.xslt";

                var strXMLFile = Directory.GetCurrentDirectory() + @"\Students.xml";
                XmlReader reader = XmlReader.Create(strXMLFile);

              
                objXSLTransform.Load(strXSLTFile);
               
                TextWriter htmlWriter = new StringWriter(htmlOutput);
                objXSLTransform.Transform(reader, null, htmlWriter);

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #region Load dat from xml string
            try
            {
                StringBuilder htmlOutput2 = new StringBuilder();
                TextWriter htmlWriter2 = new StringWriter(htmlOutput2);
                TextReader sr = new StringReader(xml);

                XmlReader reader = XmlReader.Create(sr);


                objXSLTransform.Transform(reader, null, htmlWriter2);

                Console.WriteLine(htmlOutput2.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            return htmlOutput.ToString();
        }
    }
}
