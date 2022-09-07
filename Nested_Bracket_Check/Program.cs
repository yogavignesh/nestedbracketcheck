
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Check nested brackets
/// </summary>
public class nestedBrackets
{
    /// <summary>
    /// Checks if an input lsp file has balanced paranthesis or not
    /// </summary>
    /// <param name="args"></param>
    public static void Main(String[] args)
    {

        // String fileName = @"E:\StudentAdminPortal\Nested_Bracket_Check\test.lsp";
        string fileName = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "test.lsp");
        string[] lines = File.ReadAllLines(fileName);
        //Print the input file
        Console.WriteLine(String.Join(Environment.NewLine, lines));
        //Read input string from file
        String exp = new String(String.Join(Environment.NewLine, lines));
        //Filter out only the paranthesis to avoid memory leakage.
        char[] chars = exp.ToCharArray().Where(x => x.Equals('(') || x.Equals(')')).ToArray();
        // CheckNested or not
        if (paranBalanced(chars))
            Console.WriteLine("\nParanthesis closed properly");
        else
            Console.WriteLine("\nParanthesis not closed properly");
    }
    /// <summary>
    /// Class that defines the Stack for pushing and popping paranthesis and
    /// Check if they are balanced.
    /// </summary>
    public class Stack
    {
        //Declare stack variables
        public int top = -1;
        public char[] items = new char[100];//assumption that 100 brackets will be max

        public void push(char x)
        {
            if (top == 99)
            {
                Console.WriteLine("full stack");
            }
            else
            {
                items[++top] = x;
            }
        }

        char pop()
        {
            if (top == -1)
            {
                Console.WriteLine("negative index");
                return '\0';
            }
            else
            {
                char element = items[top];
                top--;
                return element;
            }
        }

        Boolean isEmpty()
        {
            return (top == -1) ? true : false;
        }
    }

    /// <summary>
    /// Checks if the 2 brackets are a matching pair
    /// </summary>
    /// <param name="char1"></param>
    /// <param name="char2"></param>
    /// <returns> true if matches and false if doesn't match</returns>
    static Boolean isMatchingPair(char paran1,
                                  char paran2)
    {
        if (paran1 == '(' && paran2 == ')')
            return true;
        else
            return false;
    }

    /// <summary>
    /// Return true if expression has balanced
    //  Brackets
    /// </summary>
    /// <param name="exp"></param>
    /// <returns>true if paranthetis are balanced</returns>
    static Boolean paranBalanced(char[] brackets)
    {
        // Declare an empty stack
        Stack<char> stackParan = new Stack<char>();

        // Traverse the given expression to
        //   check matching brackets
        for (int i = 0; i < brackets.Length; i++)
        {
            // If the exp[i] is a starting
            // bracket then push it
            if (brackets[i] == '(')
                stackParan.Push(brackets[i]);

            //  If exp[i] is an ending bracket
            //  then pop from stack and check if the
            //   popped bracket is a matching pair
            if (brackets[i] == ')')
            {
                // If we see an ending bracket without
                //   a pair then return false
                //also checks if the first bracket is closed
                //and returns false
                if (stackParan.Count == 0)
                {
                    return false;
                }

                // Pop the top element from stack, if
                // it is not a pair brackets 
                else if (!isMatchingPair(stackParan.Pop(),
                                         brackets[i]))
                {
                    return false;
                }
            }
        }

        // If there is something left in expression
        // then there is a starting bracket without
        // a closing bracket

        if (stackParan.Count == 0)
            return true; // balanced
        else
        {
            // not balanced
            return false;
        }
    }

}