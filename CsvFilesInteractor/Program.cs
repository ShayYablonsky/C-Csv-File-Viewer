using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CsvFilesInteractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Shaik/Documents/titanic/train.csv";
            StreamReader reader = new StreamReader(path);
            TextFieldParser parser = new TextFieldParser(path);
            parser.SetDelimiters(",");
            CsvFileData csvFile = new CsvFileData(path);
            csvFile.Print();
            
            
        }
        public int CheckCharCount(string text, char target)
        {
            int output = 0;
            foreach  (char character in text)
            {
                if (character == target)
                {
                    output++;
                }
            }
            return output;
        }
    }
}
