using System;
using System.Collections.Generic;
using System.Text;

namespace ReadCSV {
    class DataCompilator {
        private CSVCompiler cSV;

        public CSVCompiler CSV {
            get { return cSV; }
        }

        private Dictionary<string, List<Data>> FullData = new Dictionary<string, List<Data>>();
        //private Dictionary<string,<List<Data>> FullData = new List<List<Data>>();

        public Dictionary<string, List<Data>> TableData {
            get { return FullData; }
        }


        public DataCompilator() {
            this.cSV = new CSVCompiler();
        }

        public void setPath(string path) {
            this.cSV.SetPath(path);
        }

        public void ExtractCSVData(string filename) {
            this.CSV.Data = new List<Data>();
            this.CSV.Header = new List<string>();
            this.cSV.GetHeader();
            this.cSV.CompileCSV();
            FullData.Add(filename,this.cSV.Data);
        }
        public void ListData() {
            foreach (KeyValuePair<string, List<Data>> kv in this.TableData) {
                Console.WriteLine("____________________________________________");
                Console.WriteLine(kv.Key);
                Console.WriteLine("");
                foreach (Data d in kv.Value) {
                    foreach (KeyValuePair<string, string> keyValuePair in d.Pairs) {
                        Console.WriteLine(" " + keyValuePair.Key + ": " + keyValuePair.Value);
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}
