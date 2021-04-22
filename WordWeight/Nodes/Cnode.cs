using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWeight.Nodes
{
    class Cnode : Node
    {
        public char character;
        public int occurence;

        public Cnode(char character) : base()
        {
            this.character = character;
            this.occurence = 0;
        }

        public void endPath(string word)
        {
            nodes.Add(new Enode(word));
        }
    }
}
