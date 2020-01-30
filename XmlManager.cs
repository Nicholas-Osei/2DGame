using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
namespace Game9
{
    public class XmlManager<T>
    {
        public Type Type;
        public XmlManager()
        {
            Type = typeof(T); 
        }
        public T Load(string Path) //aanmaken
        {
            T instance;
            using (TextReader reader = new StreamReader(Path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }
           return instance;
        }
        public void Save(string path, object obj)//opslaan
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
