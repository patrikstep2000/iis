using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Utils
{
    public static class XmlUtils
    {
        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }

        public static T DeserializeXml<T>(string str)
        {
            var serializer = new XmlSerializer(typeof(T));
            object result;

            using (TextReader reader = new StringReader(str))
            {
                result = serializer.Deserialize(reader);
            }

            return (T)result;
        }
    }
}