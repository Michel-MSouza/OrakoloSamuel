using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadCSV {
    class CSVCompiler {

        //private int DicPage;
        private List<string> _HeaderVariables;

        public List<string> Header {
            get { return _HeaderVariables; }
            set { _HeaderVariables = value; }
        }


        private string _path;

        private List<Person> people;

        public List<Person> People {
            get { return people; }
            set { people = value; }
        }

        public string FilePath {
            get { return _path; }
            set { _path = value; }
        }

        public CSVCompiler() {
            this.People = new List<Person>();
            this.Header = new List<string>();
        }

        public void GetPath(string path) {
            this._path = path;
        }

        public void GetHeader() {
            using (var reader = new StreamReader(this._path)) {
                string currentLine = reader.ReadLine();
                string gettingFormat = "";
                for (int i = 0; i < currentLine.Length; i++) {
                    if (currentLine[i] != ',')
                        gettingFormat += currentLine[i];
                    else {
                        //Console.WriteLine(gettingFormat);
                        if (gettingFormat.Length > 0)
                            Header.Add(gettingFormat);
                        gettingFormat = "";
                    }
                }
                Header.Add(gettingFormat);
            }
        }

        public void CompileCSV() {
            using (var reader = new StreamReader(this._path)) {
                string currentLine = reader.ReadLine();
                string gettingFormat;
                while ((currentLine = reader.ReadLine()) != null) {
                    gettingFormat = "";
                    //Console.WriteLine(currentLine);
                    int DicPage = 0;
                    Person p = new Person();
                    for (int i = 0; i < currentLine.Length; i++) {

                        if (currentLine[i] != ',')
                            gettingFormat += currentLine[i];
                        else {
                            //Console.WriteLine(gettingFormat);
                            if (gettingFormat.Length > 0) {

                                if (!p.Pairs.ContainsKey(this.Header[DicPage % (this.Header.Count)])) {
                                    p.Pairs.Add(this.Header[DicPage % (this.Header.Count)], gettingFormat);
                                    DicPage++;
                                }
                                //dict.Add(VectorType[DicPage % VectorType.Count], gettingFormat);
                                //VectorType.Add(gettingFormat);
                                gettingFormat = "";
                            }
                        }
                    }

                    if (!p.Pairs.ContainsKey(this.Header[DicPage % (this.Header.Count)])) {
                        p.Pairs.Add(this.Header[DicPage % (this.Header.Count)], gettingFormat);
                    }
                    this.People.Add(p);
                }
            }
        }
    }
}
