using DataLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace DataLayer
{
    //Попытался создать свой DbSet но для работы с Xml
    public class XmlSet<T> : List<T> where T:class
    {
        private List<T> arr;
        public List<T> Data { get { return arr; } }
        private string _connection { get; set; }
        public new bool Exists { get; set; }

        private readonly XmlDocument xDoc;


        //Проверяем наличие файла и сразу заполняем массив из него
        public XmlSet() 
        {
            xDoc = new XmlDocument();

            _connection = $"{typeof(T).Name}Data.xml";      //Задаём название файлу  

            if (File.Exists(_connection))
            {
                Exists = true;
                arr = Read();
            }
            else 
            {
                arr = new List<T>();
                
            }
                  
        }

        public new void Add(T item) 
        {

            if (arr.Count > 1)
            {
                Append(item);                                    //Добавляем элемент в уже существующий файл         

                arr=Read();                                     
            }
            else 
            {
                arr.Add(item);
                Initialize(arr);                                //Передаём элемент в инициализатор

                arr=Read();                                     //Считываем из файла в массив
            }
        }

        //Добавление элемента в файл
        private void Append (T item)
        {

            xDoc.Load(_connection);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlSerializer x = new XmlSerializer(item.GetType());

            XPathNavigator nav = xRoot.CreateNavigator();

            using (XmlWriter writer = nav.AppendChild())
            {

                writer.WriteWhitespace("");

                x.Serialize(writer, item);

                writer.Close();

            }

            xDoc.Save(_connection);

        }

        //Инициализатор создаёт XML файла
        private void Initialize(List<T> item)
        {
            XmlSerializer x = new XmlSerializer(new List<T>().GetType());

            
            using (Stream fs = new FileStream(_connection, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            { 
                x.Serialize(XmlWriter.Create(fs), item); 
            }
            

        }

        //Читаем из массива
        private List<T> Read()
        {

            XmlSerializer x = new XmlSerializer(new List<T>().GetType());

            List<T> res;

            using (Stream fs = new FileStream(_connection, FileMode.Open, FileAccess.Read, FileShare.None))
            {

                res = (List<T>)x.Deserialize(fs);

            }
  
            return res;
        }

        //Удаление по индексу
        public void Remove(int id)
        {

            xDoc.Load(_connection);

            XmlElement xRoot = xDoc.DocumentElement;

            var list = xRoot.ChildNodes;
            foreach (XmlNode child in list)
            {
                if (child.FirstChild.InnerText.Equals(id.ToString()))
                {
                    xRoot.RemoveChild(child);
                }
            }

            xDoc.Save(_connection);

        }
        public void EditNode(string[] info) 
        {
            xDoc.Load(_connection);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlNodeList nodes = xRoot.ChildNodes;

            foreach (XmlNode child in nodes)
            {

                if (child.FirstChild.InnerText.Equals(info[0]))
                {

                    var ch = child.ChildNodes;
                    for (int i = 0; i<info.Length; ++i) 
                    {
                        ch[i].InnerText = info[i];
                    }

                }

            }

            xDoc.Save(_connection);
        }

    }
}
