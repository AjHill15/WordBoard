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
        public int frequency;

        public Cnode() : base() { } //default constructor, do not use.

        public Cnode(char character) : base()
        {
            this.character = character;
            this.frequency = 1;
        }

        public void endPath(string word) //TODO: search to make sure we avoid doubles, unnecessary right now.
        {
            nodes.Add(new Enode(word));
        }
    }
}
