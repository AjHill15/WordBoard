using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WordWeight.Nodes;

namespace WordWeight
{
    public class WordTrie
    {
        Onode origin;
        public WordTrie()
        {
            initialize();
        }

        public void initialize()
        {
            origin = new Onode();
            string[] lines = getLinesFromFile();
            foreach(string line in lines)
            {
                origin.addWord(line);
            }
        }

        private string[] getLinesFromFile()
        {
            string[] array = null;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\words.txt");
            array = File.ReadAllLines(path);
            return array;
        }

        public List<Result> getSuggestedLetters(string input)
        {
            return origin.getNextChars(input);
        }

        public List<Result> getSuggestedWords(string input)
        {
            List<Result> results = new List<Result>();
            Node currentNode = origin;
            foreach(char c in input)
            {
                if(currentNode.GetNextHop(c) != null)
                {
                    currentNode = currentNode.GetNextHop(c);
                }
                else
                { 
                    break; 
                }
            }
            if(currentNode != origin && currentNode != null)
            {
                foreach(Enode end in currentNode.getAllEnds())
                {
                    results.Add(new Result(end));
                }
            }
            return results;
        }

        public List<string> getAllWords()
        {
            List<string> words = new List<string>();
            var ends = origin.getAllEnds();

            foreach(var end in ends)
            {
                words.Add(end.word);
            }

            return words;
        }

    }
}
