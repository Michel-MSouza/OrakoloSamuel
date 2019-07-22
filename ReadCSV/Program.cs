using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ReadCSV {
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string fileName = "PlanilhaProjetoTeste3.csv";
            string ProjectName = "ReadCSV";  
            string ShortPath = PathMaker(ProjectName,fileName, AppDomain.CurrentDomain.BaseDirectory); 

            DataCompilator dataCompilator = new DataCompilator();
            dataCompilator.CSV.SetPath(ShortPath);
            dataCompilator.ExtractCSVData(fileName);
            fileName = "Planilha1.csv";
            dataCompilator.setPath(PathMaker(ProjectName, fileName, AppDomain.CurrentDomain.BaseDirectory));
            dataCompilator.ExtractCSVData(fileName);
            dataCompilator.ListData();


        }
        public static string PathMaker(string ProjectName, string FileName, string path) {
            string fs = "";
            for (int i = 0; i < path.IndexOf(ProjectName); i++) {
                fs += path[i];
            } 
            return Path.Combine(fs, ProjectName, @"Planilhas", FileName);
        }
    }
}


///Original Code for compileCSV
///
/*while ((currentLine = reader.ReadLine()) != null) {
    gettingFormat = "";
    //Console.WriteLine(currentLine);
    int DicPage = 0;
    Person p = new Person();
    for (int i = 0; i < currentLine.Length; i++) {

        if (currentLine[i] != ',')
            gettingFormat += currentLine[i];
        else {
            //Console.WriteLine(gettingFormat);
            if (gettingFormat.Length > 0 ) {

                if(!p.Pairs.ContainsKey(planilha.Header[DicPage % (planilha.Header.Count)])) {
                    p.Pairs.Add(planilha.Header[DicPage % (planilha.Header.Count)], gettingFormat);
                    DicPage++;
                }
                //dict.Add(VectorType[DicPage % VectorType.Count], gettingFormat);
                //VectorType.Add(gettingFormat);
                gettingFormat = "";
            }
        }
    }

    if (!p.Pairs.ContainsKey(planilha.Header[DicPage % (planilha.Header.Count)])) {
        p.Pairs.Add(planilha.Header[DicPage % (planilha.Header.Count)], gettingFormat);
    }
    planilha.People.Add(p);
}*/
