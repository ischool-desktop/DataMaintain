using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using FISCA.DSA;
using FISCA;

namespace DataMaintain
{
    /// <summary>
    /// DSA 3.0 ���Ѫ��s�u�������A�i�ئ�@��`�Ϊ� Xml �ާ@�C
    /// </summary>
    static class XmlUtilities
    {
        /// <summary>
        /// �榡�� Xml ���e�C
        /// </summary>
        /// <returns></returns>
        public static string Format(string xmlContent)
        {
            string Result = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.UTF8);

                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';

                XmlReader Reader = GetXmlReader(xmlContent);
                writer.WriteNode(Reader, true);
                writer.Flush();
                Reader.Close();

                ms.Position = 0;
                StreamReader sr = new StreamReader(ms, System.Text.Encoding.UTF8);

                Result = sr.ReadToEnd();
            }

            return Result;
        }

        private static XmlReader GetXmlReader(string XmlData)
        {
            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreWhitespace = true;

            XmlReader Reader = XmlReader.Create(new StringReader(XmlData), setting);

            return Reader;
        }

        /// <summary>
        /// �ƻsXmlElement����A�ܧ�䤺�e���|�������Ӫ�XmlElement���C
        /// </summary>
        /// <param name="srcElement">�n�ƻs��XmlElement����C</param>
        /// <returns>�w�ƻs��XmlElement����C</returns>
        public static XmlElement CloneElement(XmlElement srcElement)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = true;
            xmldoc.LoadXml(srcElement.OuterXml);

            return (XmlElement)xmldoc.DocumentElement;
        }

        /// <summary>
        /// �NXml�r��[�J��XmlNode���A�i�B�z���PXmlDocument����XmlNode�C
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static XmlNode AppendChild(XmlNode parent, XmlNode child)
        {
            if (XmlDocument.ReferenceEquals(parent.OwnerDocument, child.OwnerDocument))
                return parent.AppendChild(child);
            else
            {
                XmlNode nChild = parent.OwnerDocument.ImportNode(child, true);
                return parent.AppendChild(nChild);
            }
        }

        /// <summary>
        /// �NXml�r��[�J��XmlNode���C
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childXmlContent">�]�t�u�ڡv��Xml�r��</param>
        public static XmlNode AppendChild(XmlNode parent, string childXmlContent)
        {
            XmlNode nChild = LoadXml(childXmlContent);

            nChild = parent.OwnerDocument.ImportNode(nChild, true);

            return parent.AppendChild(nChild);
        }

        /// <summary>
        /// ���J���w�� Xml �ɮסC
        /// </summary>
        /// <param name="fileName">�ɮצW�١C</param>
        /// <returns><see cref="XmlElement"/>����C</returns>
        public static XmlElement LoadXmlFile(string fileName, bool preserveWhitespace)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = preserveWhitespace;
            xmldoc.Load(fileName);

            return xmldoc.DocumentElement;
        }

        /// <summary>
        /// ���J���w�� Xml �ɮסC
        /// </summary>
        /// <param name="fileName">�ɮצW�١C</param>
        /// <returns><see cref="XmlElement"/>����C</returns>
        public static XmlElement LoadXmlFile(string fileName)
        {
            return LoadXmlFile(fileName, true);
        }

        /// <summary>
        /// ���J���w�� Xml ��ơC
        /// </summary>
        /// <param name="xmlContent">�n���J�� Xml �r���ơC</param>
        /// <returns><see cref="XmlElement"/>����C</returns>
        public static XmlElement LoadXml(string xmlString)
        {
            return LoadXml(xmlString, true);
        }

        /// <summary>
        /// ���J���w�� Xml ��ơC
        /// </summary>
        /// <param name="xmlString">�n���J�� Xml �r���ơC</param>
        /// <param name="preserveWhitespace">�O�_�O�d�r�ꤤ���x�ťզr���C</param>
        /// <returns><see cref="XmlElement"/>����C</returns>
        public static XmlElement LoadXml(string xmlString, bool preserveWhitespace)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = preserveWhitespace;
            xmldoc.LoadXml(xmlString);

            return xmldoc.DocumentElement;
        }

        /// <summary>
        /// �N���w�� Xml ��ƥH UTF-8 ���s�X�覡�x�s���ɮסC
        /// </summary>
        /// <param name="fileName">�ɮצW�١C</param>
        /// <param name="elm">�n�x�s�� Xml ����C</param>
        public static void SaveXml(string fileName, XmlNode node)
        {
            SaveXml(fileName, node, Encoding.UTF8);
        }

        /// <summary>
        /// �N���w�� Xml ����x�s���ɮסC
        /// </summary>
        /// <param name="fileName">�ɮצW�١C</param>
        /// <param name="node">�n�x�s�� Xml ����C</param>
        /// <param name="enc">�x�s���s�X�覡�C</param>
        public static void SaveXml(string fileName, XmlNode node, Encoding enc)
        {
            File.WriteAllText(fileName, node.OuterXml, enc);
        }

        /// <summary>
        /// �N���w�� Xml ��ƥHUTF-8���s�X�覡�g�J���y���C
        /// </summary>
        /// <param name="outStream">���w����y�C</param>
        /// <param name="node">�n��X�� Xml ����C</param>
        public static void SaveXml(Stream outStream, XmlNode node)
        {
            SaveXml(outStream, node, Encoding.UTF8);
        }

        /// <summary>
        /// �N���w�� Xml ��Ƽg�J���y���C
        /// </summary>
        /// <param name="outStream">���w����y�C</param>
        /// <param name="node">�n��X�� Xml ����C</param>
        /// <param name="enc">��X���s�X�覡�C</param>
        public static void SaveXml(Stream outStream, XmlNode node, Encoding enc)
        {
            StreamWriter sw = new StreamWriter(outStream, enc);
            sw.Write(node.OuterXml);
        }

        /// <summary>
        /// �ǰeXml���e��Y�Ӻ��}�C
        /// </summary>
        /// <param name="url">�ت�URL�C</param>
        /// <param name="xmlContent">�n�ǰe��Xml���e�C</param>
        /// <returns>�^�Ǫ�Xml��ơC</returns>
        public static string HttpSendTo(string url, string xmlContent)
        {
            return HttpSendTo(url, "POST", xmlContent);
        }

        /// <summary>
        /// �ǰeXml���e��Y�Ӻ��}�C
        /// </summary>
        /// <param name="url">�ت�URL�C</param>
        /// <param name="method">�ǰe����k(POST�BGET)</param>
        /// <param name="xmlContent">�n�ǰe��Xml���e�C</param>
        /// <returns>�^�Ǫ�Xml��ơC</returns>
        public static string HttpSendTo(string url, string method, string xmlContent)
        {
            //�إ�Http�s�u
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);

            //�򥻳]�w
            httpReq.Method = method;
            httpReq.ContentType = "text/xml";

            if (method == "POST")
            {
                //�g�JRequest�D��
                StreamWriter reqWriter = new StreamWriter(httpReq.GetRequestStream(), Encoding.UTF8);
                reqWriter.Write(xmlContent);
                reqWriter.Close();
            }
            else if (method == "GET")
            {
                httpReq = (HttpWebRequest)WebRequest.Create(url + "?" + xmlContent);
            }
            else
            {
                throw new InvalidOperationException("���䴩���w�� Http Method�G" + method);
            }

            //���oResponse
            WebResponse httpRsp = null;
            httpRsp = httpReq.GetResponse();

            StreamReader rspStream;

            rspStream = new StreamReader(httpRsp.GetResponseStream(), Encoding.UTF8);

            string result = rspStream.ReadToEnd();
            rspStream.Close(); //�o�ӭn�O�o�����C

            return result;
        }

        public static XmlElement ResponseBody(this Envelope rsp)
        {
            return XHelper.ParseAsDOM(rsp.BodyContent.XmlString);
        }

        public static XHelper XResponseBody(this Envelope rsp)
        {
            return XHelper.ParseAsHelper(rsp.BodyContent.XmlString);
        }
    }
}
