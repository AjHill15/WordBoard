using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWeight.Nodes
{
    internal class Node
    {
        public List<Node> nodes;

        public Node()
        {
            nodes = new List<Node>();
        }

        public Cnode addNode(char character)
        {
            bool newNode = true;
            Cnode nextStep = null;
            var cnodes = getCnodes();
            {
                foreach(Cnode node in cnodes)
                {
                    if(node.character == character)
                    {
                        newNode = false;
                        node.frequency++;
                        nextStep = node;
                        break;
                    }
                }

                if(newNode)
                {
                    nextStep = new Cnode(character);
                    nodes.Add(nextStep);
                }
            }
            return nextStep;
        }

        private List<Cnode> getCnodes()
        {
            List<Cnode> cnodes = new List<Cnode>();
            foreach(Node node in nodes)
            {
                if(node is Cnode)
                {
                    cnodes.Add((Cnode)node);
                }
            }
            return cnodes;
        }

        internal Cnode GetNextHop(char character)
        {
            Cnode nextHop = null;
            var cNodes = getCnodes();
            foreach(Cnode node in cNodes)
            {
                if(node.character == character)
                {
                    nextHop = node;
                }
            }
            return nextHop;
        }

        internal List<Enode> getAllEnds()
        {
            List<Enode> ends = new List<Enode>();
            foreach(Node node in nodes)
            {
                if (node is Enode)
                {
                    ends.Add((Enode)node);
                }
                else if (node is Cnode)
                {
                    ends.AddRange(node.getAllEnds());
                }
                else
                {
                    throw new NotImplementedException("how the hell?");
                }
            }
            return ends;
        }

    }
}
