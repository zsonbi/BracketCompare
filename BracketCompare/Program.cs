using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketCompare
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bracketChecker checker = new bracketChecker();
            string input = Console.ReadLine();
            Console.WriteLine(checker.CorrectBracketOrder(input) ? "correct" : "invalid");
        }
    }

    //******************************************************************
    internal class bracketChecker
    {
        //Varriables
        private char[] bracketchars = new char[] { '(', ')', '<', '>', '[', ']', '{', '}' };

        private Dictionary<char, char> pairs = new Dictionary<char, char>();
        private Stack<char> brackets = new Stack<char>();

        //Constructor
        public bracketChecker()
        {
            for (int i = 0; i < bracketchars.Length / 2; i += 2)
            {
                pairs.Add(bracketchars[i + 1], bracketchars[i]);
            }//for
        }

        //Checks if the brackets in the input are correct in order (if it is not closed it's incorrect same with clasing nothing)
        public bool CorrectBracketOrder(string input)
        {
            //Go through the input string
            for (int i = 0; i < input.Length; i++)
            {
                //Checks if the current character from the string is a bracket
                if (bracketchars.Contains(input[i]))
                {
                    //Checks if the bracket is a closing one and the stack is not empty
                    if (pairs.ContainsKey(input[i]) && brackets.Count != 0)
                    {
                        //If the bracket is closed remove the opening one from the stack
                        if (pairs[input[i]] == brackets.Peek())
                        {
                            brackets.Pop();
                        }//if
                        else
                        {
                            brackets.Push(input[i]);
                        }//else
                    }//if
                    //Adds the bracket to the stack
                    else
                        brackets.Push(input[i]);
                }//if
            }//for
            //if the stack is not empty that's a problem then the bracket order is bad
            return brackets.Count == 0;
        }
    }
}