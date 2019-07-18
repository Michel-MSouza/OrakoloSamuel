using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ReadCSV {
    class Program {
        static void Main(string[] args) {
            //string path = "C:/Users/Usuario/source/repos/OrakoloSamuel/ReadCSV/PlanilhaProjetoTeste3.csv";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string fileName = "PlanilhaProjetoTeste3.csv";
            string pathRelative = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Planilhas",fileName);
            Console.WriteLine(pathRelative);
            CSVCompiler planilha = new CSVCompiler();
            List<string> VectorType = new List<string>();
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            planilha.GetPath(pathRelative);
            planilha.GetHeader();
            planilha.CompileCSV();

            /*for(int i = 0; i < planilha.People.Count; ++i) {
                foreach (KeyValuePair<string, string> kv in planilha.People[i].Pairs) {
                    Console.WriteLine(kv.Key + ": " + kv.Value);
                }
                Console.WriteLine("");
            }*/
            //Console.WriteLine(planilha.People.Count.ToString());
            float comp = 0;
            float venda = 0;
            for(int i = 0; i < planilha.People.Count; i++) {
                float compT, vendaT;
                float.TryParse(planilha.People[i].Pairs["Compra"], out compT);
                float.TryParse(planilha.People[i].Pairs["Venda"], out vendaT);
                //Console.WriteLine(planilha.People[i].Pairs["Venda"] + "=" + venda);
                comp += compT;
                venda += vendaT;
            }
            Console.WriteLine((comp-venda)/planilha.People.Count);
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
