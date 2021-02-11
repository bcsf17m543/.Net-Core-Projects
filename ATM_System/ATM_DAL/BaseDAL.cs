using System;
using System.Collections.Generic;
using System.Text;
using ATM_BO;
using System.IO;

namespace ATM_DAL
{
    public class BaseDAL
    {
      internal void MakeEmpty(string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory,fileName);
            System.IO.File.WriteAllText(filePath, string.Empty);
        }
        internal void Save(string text, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory,
                fileName);
            StreamWriter sw = new StreamWriter(filePath, append: true);
            sw.WriteLine(text);
            sw.Close();

        }

        internal List<string> Read(string fileName)
        {

            List<string> list = new List<string>();
            string filePath = Path.Combine(Environment.CurrentDirectory,
                fileName);
            StreamReader sr = new StreamReader(filePath);
            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {

                list.Add(line);

            }
            sr.Close();
            return list;
        }
    }
}
