using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadCSV {
    class Program {
        static void Main(string[] args) {
            string path = "C:/Users/Usuario/source/repos/ReadCSV/ReadCSV/PlanilhaProjetoTeste2.csv";
            CSVCompiler planilha = new CSVCompiler();
            List<string> VectorType = new List<string>();
            //Dictionary<string, string> dict = new Dictionary<string, string>();
                planilha.GetPath(path);
                planilha.GetHeader();
                planilha.CompileCSV();

                for(int i = 0; i < planilha.People.Count; ++i) {
                    foreach (KeyValuePair<string, string> kv in planilha.People[i].Pairs) {
                        Console.WriteLine(kv.Key + ": " + kv.Value);
                    }
                    Console.WriteLine("");
                }
            
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
