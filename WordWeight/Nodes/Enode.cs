using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWeight.Nodes
{
    class Enode : Node
    {
        public string word;
        public int frequency;

        public Enode() { } //default constructor do not use.

        public Enode(string word)
        {
            this.word = word;
            this.frequency = 0; //this will put it at the end of the list but that's fine for now.
            nodes = null;
        }
    }
}
