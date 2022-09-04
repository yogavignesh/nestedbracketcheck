
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

// Check nested brackets

public class nestedBrackets
{
    public class Stack
    {
        public int top = -1;
        public char[] items = new char[100];

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

    //Check matching brackets
    static Boolean isMatchingPair(char char1,
                                  char char2)
    {
        if (char1 == '(' && char2 == ')')
            return true;
        else
            return false;
    }

    // Return true if expression has balanced
    // Brackets
    static Boolean paranBalanced(char[] exp)
    {
        // Declare an empty character stack */
        Stack<char> stackParan = new Stack<char>();

        // Traverse the given expression to
        //   check matching brackets
        for (int i = 0; i < exp.Length; i++)
        {
            // If the exp[i] is a starting
            // bracket then push it
            if ( exp[i] == '(')
                stackParan.Push(exp[i]);

            //  If exp[i] is an ending bracket
            //  then pop from stack and check if the
            //   popped bracket is a matching pair
            if (exp[i] == ')')
            {
                // If we see an ending bracket without
                //   a pair then return false
                if (stackParan.Count == 0)
                {
                    return false;
                }

                // Pop the top element from stack, if
                // it is not a pair brackets 
                else if (!isMatchingPair(stackParan.Pop(),
                                         exp[i]))
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

    // Driver code
    public static void Main(String[] args)
    {
                     
        String fileName = @"E:\StudentAdminPortal\Nested_Bracket_Check\test.lsp";
        string[] lines = File.ReadAllLines(fileName);  
        //Print the input file
        Console.WriteLine(String.Join(Environment.NewLine, lines));
        //Read input string from file
        String exp = new String(String.Join(Environment.NewLine, lines));
        char[] chars = exp.ToCharArray();
        char[] paran= new char[chars.Length];
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i]== '(' || chars[i] == ')')
            {
                paran[i] = chars[i];
                Console.WriteLine(paran[i]);
            }   
        }
        // CheckNested or not
        if (paranBalanced(paran))
            Console.WriteLine("\nNested");
        else
            Console.WriteLine("\nParanthesis not closed properly");
    }
}