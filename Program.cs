using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffersonCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[,] randomArray=new char[26,26];
            randomArray = RandomTable(alphabet,10);
            Console.WriteLine("Introduceti textul pe care doriti sa il criptati:");
            string plainText=Console.ReadLine();
            int[] n = new int[10] {0,1,2 ,3,4,5,6,7,8,9};
            n = RandomizeArray(n);
            Console.WriteLine($"Cheia de criptare este:");
            Write(n);
            Console.WriteLine();
            foreach(int c in n)
            {
                Console.Write($"{c}:");
                for(int j=0;j<26;j++)
                {
                    Console.Write(randomArray[c,j]);
                }
                Console.WriteLine();
            }
            string cipherText = JeffersonEncrypt(plainText, n,randomArray);
            Console.WriteLine($"Encrypted:{cipherText}");
            string decryptedText =JeffersonDecrypt(cipherText, n,randomArray);
            Console.WriteLine($"Decrypted:{decryptedText}");
            Console.ReadKey();
        }
        private static string JeffersonDecrypt(string cipherText, int[] n, char[,] randomArray)
        {
            char[] x = new char[26];
            string decryptedText = "";
            int y = 0;
            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    for (int z = 0; z < 26; z++)
                    {
                        x[z] = randomArray[n[y], z];
                    }
                    string t = "";
                    for (int i = 0; i < 26; i++)
                    {
                        t += x[i];
                    }
                    char upperC = char.ToUpper(c);
                    foreach (char p in x)
                    {
                        if (upperC == p)
                        {
                            int indx = t.IndexOf(upperC);
                            if (indx >= 6)
                            {
                                upperC = x[t.IndexOf(upperC) - 6];
                            }
                            else if (indx == 0)
                            {
                                upperC = x[20];
                            }
                            else if (indx == 1)
                            {
                                upperC = x[21];
                            }
                            else if (indx == 2)
                            {
                                upperC = x[22];
                            }
                            else if (indx == 3)
                            {
                                upperC = x[23];
                            }
                            else if (indx == 4)
                            {
                                upperC = x[24];
                            }
                            else if (indx == 5)
                            {
                                upperC = x[25];
                            }
                            break;
                        }
                    }
                    decryptedText += upperC;
                }
                else
                {
                    decryptedText += c;
                }
                y++;
                if (y == 10)
                {
                    y = 0;
                }
            }
            return decryptedText;
        }
        private static string JeffersonEncrypt(string plainText, int[] n, char[,] randomArray)
        {
            char[]x= new char[26];    
            string cipherText = "";
            int y = 0;
            foreach (char c in plainText)
            {
                if(char.IsLetter(c))
                {
                    for(int z=0;z<26;z++)
                    {
                        x[z] = randomArray[n[y],z];
                    }
                    string t="";
                    for(int i=0;i<26;i++)
                    {
                        t += x[i];
                    }
                    char upperC=char.ToUpper(c);
                    foreach(char p in x)
                    {
                        if(upperC == p)
                        {
                            int indx=t.IndexOf(upperC);
                            if (indx <= 19)
                            {
                                upperC = x[t.IndexOf(upperC) + 6];
                            }
                            else if(indx==20)
                            {
                                upperC = x[0];
                            }
                            else if(indx==21)
                            {
                                upperC = x[1];
                            }
                            else if (indx==22)
                            {
                                upperC= x[2];
                            }
                            else if(indx == 23)
                            {
                                upperC = x[3];
                            }
                            else if(indx == 24)
                            {
                                upperC = x[4];
                            }
                            else if(upperC ==25)
                            {
                                upperC = x[5];
                            }
                            break;
                        }
                    }
                    cipherText += upperC;
                }
                else
                {
                    cipherText += c;
                }
                y++;
                if(y==10)
                {
                    y = 0;
                }
            }
            return cipherText;
        }
        
        private static char[,] RandomTable(string alphabet, int n)
        {
            char[] rnd = new char[26];
            rnd = alphabet.ToCharArray();
            char[,] x = new char[alphabet.Length, alphabet.Length];
            for (int i = 0; i < n; i++)
            {
                rnd = RandomizeArray(rnd);
                for (int j = 0; j < 26; j++)
                {
                    x[i, j] = rnd[j];
                }
            }
            return x;
        }


        private static void Write(int[] n)
        {
            for(int i=0;i<n.Length; i++)
                Console.Write(n[i]+" ");
        }
        private static void Write(char[] n)
        {
            for (int i = 0; i < n.Length; i++)
                Console.Write(n[i] + " ");
        }

        private static int[] RandomizeArray(int[] rnd_alphabet)
        {
            //shuffling the array using "Fisher–Yates shuffle Algorithm"
            int[] array = rnd_alphabet;
            Random rnd = new Random();
            for (int i = rnd_alphabet.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }
        private static char[] RandomizeArray(char[] rnd_alphabet)
        {
            //shuffling the array using "Fisher–Yates shuffle Algorithm"
            char[] array = rnd_alphabet;
            Random rnd = new Random();
            for (int i = rnd_alphabet.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }
    }

}
