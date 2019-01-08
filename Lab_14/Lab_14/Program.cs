using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Boing plane = new Boing();
            Boing plane2 = new Boing();
            Boing[] planes = new Boing[] { plane, plane2 };

            plane.addInfo();
            plane2.addInfo();

            BinarySerialize(plane);
            BinaryDesirialaize();
            SOAPSerialize(plane);
            SOAPDeserialize();
            XMLSerialize(plane);
            XMLDeserialize();
            JSONSerialize(plane);
            JSONDeserialize();
            JSONArraySerialize(planes);
            JSONArrayDeserialize();
            XMLArraySerialize(planes);
            XMLArrayDeserialize();
            XPath();
            XmlLinq();
        }

        static public void BinarySerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("plane.dat", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, obj);

                Console.WriteLine("Сериализаци binary завершена");

            }
        }

        static public void BinaryDesirialaize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("plane.dat", FileMode.OpenOrCreate))
            {
                Boing plane = (Boing)formatter.Deserialize(fs);

                Console.Write("Объект Десериализован ");
                plane.Type();
            }
        }

        static public void SOAPSerialize(object obj)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("plane.soap", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, obj);

                Console.WriteLine("Сериализаци SOAP завершена");

            }
        }

        static public void SOAPDeserialize()
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("plane.soap", FileMode.OpenOrCreate))
            {
                Boing plane = (Boing)formatter.Deserialize(fs);

                Console.Write("Объект Десериализован ");
                plane.Type();
            }
        }

        static public void XMLSerialize(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Boing));

            using (FileStream fs = new FileStream("plane.xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);

                Console.WriteLine("Сериализация XML завершена");
            }
        }

        static public void XMLDeserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Boing));

            using (FileStream fs = new FileStream("plane.xml", FileMode.OpenOrCreate))
            {
                Boing plane = (Boing)serializer.Deserialize(fs);
                Console.Write("Объект Десериализован ");
                plane.Type();
            }
        }

        static public void XMLArraySerialize(object[] obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Boing[]));

            using (FileStream fs = new FileStream("planeArray.xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);

                Console.WriteLine("Сериализация XML завершена");
            }
        }

        static public void XMLArrayDeserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Boing[]));

            using (FileStream fs = new FileStream("planeArray.xml", FileMode.OpenOrCreate))
            {
                Boing[] plane = (Boing[])serializer.Deserialize(fs);
                Console.WriteLine("Объект Десериализован ");
                foreach (Boing c in plane)
                {
                    c.Type();
                }
            }
        }

        static public void JSONSerialize(object obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Boing));

            using (FileStream fs = new FileStream("plane.json", FileMode.Create))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Сериализация Json завершена");
            }
        }

        static public void JSONDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Boing));

            using (FileStream fs = new FileStream("plane.json", FileMode.OpenOrCreate))
            {
                Boing plane = (Boing)json.ReadObject(fs);
                Console.Write("Объект Десериализован ");
                plane.Type();
            }
        }
        static public void JSONArraySerialize(object[] obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Boing[]));

            using (FileStream fs = new FileStream("candyArray.json", FileMode.Create))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Сериализация Json завершена");
            }
        }

        static public void JSONArrayDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Boing[]));

            using (FileStream fs = new FileStream("candyArray.json", FileMode.OpenOrCreate))
            {
                Boing[] candy = (Boing[])json.ReadObject(fs);
                Console.WriteLine("Объект Десериализован ");

                foreach (Boing c in candy)
                {
                    c.Type();
                }
            }
        }

        static public void XPath()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Xpath.xml");
            XmlElement Root = Doc.DocumentElement;

            XmlNode childnode = Root.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
                Console.WriteLine(childnode.SelectSingleNode("@name").Value);

        }

        static public void XmlLinq()
        {
            XDocument xDoc = new XDocument(new XElement("OOP", new XElement("Labs", new XElement("Lab1", "github"), new XElement("Lab2", "Classes"))));
            xDoc.Save("oop.xml");
        }
    }


}