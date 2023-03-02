using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALGO__3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] poem = File.ReadAllLines("D:\\poem.tx");
            //assigning first line to a array
            string[] F_line = new string[poem[0].Length];
            F_line = poem[0].Split(' ');
            //assigning last word to a array
            string Last_W = F_line[F_line.GetLength(0) - 1];
            string a;
            string[] c = new string[Last_W.Length];
            bool word = true, phrase = false, additional = false;
            string[] z = new string[F_line.GetLength(0)];
            int[] cou1 = new int[poem.Length - 1];
            int countR;
            
            for (int i = 1; i < poem.Length; i++)
            {
                //assigning other lines to the array
                string[] lineA = poem[i].Split(' ');
                int j = 1;
                while (F_line[F_line.Length - j] == lineA[lineA.Length - j])
                {
                    //determining the number of the same words
                    j++;
                    if (j > F_line.GetLength(0) || j > lineA.GetLength(0))
                    {
                        break;
                    }
                }
                cou1[i - 1] = j;
            }
            //checking status for phrase rhyme
            int cou2 = cou1[0];
            for (int i = 0; i < poem.Length - 1; i++)
            {
                if (cou1[i] < cou2)
                {
                    cou2 = cou1[i];
                }
            }
            countR = (cou2 - 1);
            if (countR > 1)
            {
                //printing phrase rhyme status
                Console.WriteLine("Type: Phrase Rhyme");
                Console.WriteLine("Type: Straight Rhyme");
                Console.Write("Repetition : ");
                for (int i = (F_line.Length - countR); i < F_line.Length; i++)
                {
                    Console.Write(F_line[i] + " ");
                }
              
            }
         
            for (int j = 1; j < poem.GetLength(0); j++)
            {
                //checking last word of the all lines 
                if (poem[j].Substring(poem[j].Length - Last_W.Length, Last_W.Length) != Last_W)
                {
                    word = false;

                }
                //if theres any inequalities between last words code will break loop
                if (word == false)
                {
                    break;
                }
            }
            //printing word rhyme status
            if (word == true && countR == 1)
            {      
                Console.WriteLine("Type: Word rhyme");
                Console.WriteLine("Type: Straight Rhyme");
                Console.Write("Repetition: ");
                Console.Write(F_line[F_line.GetLength(0) - 1]);
            }
            //checking requried status for additional rhyme
            if (word == false && phrase == false)
            {
                for (int i = 1; i <= 20; i++)
                {
                    //checking last digits of last words 
                    if (poem[0][poem[0].Length - i] == poem[1][poem[1].Length - i] && poem[2][poem[2].Length - i] == poem[3][poem[3].Length - i] && poem[0][poem[0].Length - i] == poem[3][poem[3].Length - i])
                    {
                        a = Convert.ToString(poem[0][poem[0].Length - i]);
                        additional = true;

                    }
                    else
                    {
                        break;
                    }
                    c[i] += a;
                }
                //printing additional rhyme status

                if (additional == true)
                {
                    Console.WriteLine("Type: Additional Rhyme");
                    Console.WriteLine("Type: Straight Rhyme");
                    Console.Write("Repititon: ");
                    Array.Reverse(c);
                    for (int i = 0; i < c.GetLength(0); i++)
                    {
                        Console.Write(c[i]);
                    }

                }

            }
           
            Console.ReadLine();
        }
    }
}


