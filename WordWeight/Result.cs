using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWeight.Nodes;

namespace WordWeight
{
    public class Result
    {
        public string characters;
        public int weight;

        public Result(string characters, int weight)
        {
            this.characters = characters;
            this.weight = weight;
        }

        internal Result(Node node)
        {
            if(node is Cnode)
            {
                this.characters = new string(((Cnode)node).character,1);
                this.weight = ((Cnode)node).frequency;
            }
            else if(node is Enode)
            {
                this.characters = ((Enode)node).word;
                this.weight = ((Enode)node).frequency;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(node));
            }
        }
    }
}
