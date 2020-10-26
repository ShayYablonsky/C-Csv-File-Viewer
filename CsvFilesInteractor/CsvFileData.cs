using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace CsvFilesInteractor
{
    public class CsvFileData
    {
        public string[] Fields;
        public Dictionary<string, int> FieldsIndexs = new Dictionary<string, int>();
        public List<Dictionary<string, string>> Data = new List<Dictionary<string, string>>();
        public CsvFileData(string path)
        {
            TextFieldParser parser = new TextFieldParser(path);
            parser.SetDelimiters(",");
            Fields = parser.ReadFields();
            for (int i = 0; i <Fields.Length; i++)
            {
                FieldsIndexs.Add(Fields[i], i);
            }
            while (parser.EndOfData == false)
            {
                Data.Add(new Dictionary<string, string>());
                string[] fields = parser.ReadFields();
                for (int i = 0; i < fields.Length; i++)
                {
                    Data[Data.Count - 1].Add($"{Fields[i]}", $"{fields[i]}");
                }
            }
        }
        public void Print()
        {
            foreach (Dictionary<string,string> item in Data)
            {
                for (int i = 0; i < Fields.Length; i++)
                {
                    Console.Write($"{Fields[i]}: "); Console.WriteLine(item[$"{Fields[i]}"]);
                }
                Console.WriteLine();
            }
             string[] collum = Collum("Sex");
            foreach (var item in collum)
            {
                Console.WriteLine(item);
            }
            
        }
        public string[] Collum(string collum)
        {
            string[] output = new string[Data.Count];
            for (int i = 0; i < Data.Count; i++)
            {
                output[i] = Data[i][$"{Fields[FieldsIndexs[collum]]}"];
            }
            return output;
        }
        public string Collum(string collum, int row)
        {
            return Data[row][collum];
        }
        
        
    }
}
