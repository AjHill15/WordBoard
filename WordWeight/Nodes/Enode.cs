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

        public Enode(string word)
        {
            this.word = word;
            nodes = null;
        }
    }
}
