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

    }
}
