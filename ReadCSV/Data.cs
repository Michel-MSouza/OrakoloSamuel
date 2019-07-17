using System;
using System.Collections.Generic;
using System.Text;

namespace ReadCSV {
    class Data {

        private Dictionary<string,string> dict;

        public Dictionary<string,string> Pairs {
            get { return dict; }
            set { dict = value; }
        }

        public Data() {
            this.Pairs = new Dictionary<string, string>();
        }


        private int _idPass;

        public int IDPass {
            get { return _idPass; }
            set { _idPass = value; }
        }

        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        //public Person(int i, string s) {
        //    this.IDPass = i;
        //    this.Name = s;
        //}

    }
}
