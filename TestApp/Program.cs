using System;
using WordWeight;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WordTrie trie = new WordTrie();
            Menu(trie);
        }

        static void Menu(WordTrie trie)
        {
            Console.WriteLine("What Would you like to test?");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1.-|Word Suggestion");
            Console.WriteLine("2.-|Test List Length");
            Console.WriteLine("x.-|Exit");
            var option = Console.ReadKey();
            switch (option.KeyChar)
            {
                case '1':
                    Console.Clear();
                    testSuggestion(trie);
                    Console.WriteLine("");
                    Menu(trie);
                    break;
                case '2':
                    Console.Clear();
                    testList(trie);
                    Console.WriteLine("");
                    Menu(trie);
                    break;
                case 'x':
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        static void testSuggestion(WordTrie trie)
        {
            Console.WriteLine("Enter string:");
            var input = Console.ReadLine();
            var results = trie.getSuggestedLetters(input);
            if(results != null)
            {
                results.AddRange(trie.getSuggestedWords(input));
            }
            else
            {
                results = trie.getSuggestedWords(input);
            }
            if (results.Count < 1)
            {
                Console.WriteLine("No Results!");
            }
            else
            {
                Console.WriteLine("Results found: ");
                foreach (Result result in results)
                {
                    Console.WriteLine(result.characters + " " + result.weight);
                }
            }
        }

        static void testList(WordTrie trie)
        {
            var words = trie.getAllWords();
            Console.WriteLine(words.Count);
        }
    }
}
