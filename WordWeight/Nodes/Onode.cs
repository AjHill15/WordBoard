using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWeight.Nodes
{
    class Onode : Node
    {
        public Onode() : base()
        {

        }

        public void addWord(string word)
        {
            Node currentNode = this;
            foreach(char c in word)
            {
                currentNode = currentNode.addNode(c);
            }
            ((Cnode)currentNode).endPath(word);
        }

        internal List<Result> getNextChars(string input)
        {
            List<Result> results = new List<Result>();
            Node currentNode = this;
            foreach(char character in input)
            {
                if (currentNode != null)
                {
                    currentNode = currentNode.GetNextHop(character);
                }
            }
            if(currentNode != null)
            {
                foreach(Node node in currentNode.nodes)
                {
                    results.Add(new Result(node));
                }
            }
            results = orderResultsByWeight(results);
            return results;
        }

        private List<Result> orderResultsByWeight(List<Result> input)
        {
            List<Result> results = null;
            results = input.OrderByDescending(o => o.weight).ToList();
            return results;
        }

        
    }
}
