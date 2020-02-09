using System;

namespace PasswordGenerator
{
    class Program
    {
        static string generatePassword(int length, Random rand)
        {
            /** PARAMS: int length,             desired length of the password given by the user.
                       Random rand,             random object created in the main method.

                 given the length, and the random object.Randomly select a symbol from the alphabet
                      and append it to the password.

                OUTPUT : string password,       string that will hold the final password to be return to caller.     
            */
            string password = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$%^&*()_-";
            int maxRange = alphabet.Length;

            // loop from 0 to length - 1
            for (int i = 0; i < length; i++)
            {
                // append next random symbol.
                password = password + alphabet[rand.Next(0, maxRange)];
            }

            // return final output.
            return password;
        }

        static bool TestPassword(string password)
        {
            bool isValid = true;
            int capsCounter = 0;
            int lowerCounter = 0;
            int specCounter = 0;
            int digitCounter = 0;
            int failCounter = 0;

            char currentSymbol;
            for (int i = 0; i < password.Length; i++)
            {
                currentSymbol = password[i];

                if (Char.IsUpper(currentSymbol))
                {
                    try
                    {
                        if (Char.IsUpper(password[i + 1]))
                        {
                            isValid = false;
                            //Console.WriteLine("{0} Failed the tests from neighboring capitals.", password);
                            
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        capsCounter++;
                        continue;
                    }
                    capsCounter++;
                }
                else if (Char.IsLower(currentSymbol))
                {
                    try
                    {
                        if (Char.IsLower(password[i + 1]))
                        {
                            isValid = false;
                            //Console.WriteLine("{0} Failed the tests from neighboring lowercases.", password);
                          
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        lowerCounter++;
                        continue;
                    }
                    lowerCounter++;
                }
                else if (!Char.IsLetterOrDigit(currentSymbol))
                {
                    try
                    {
                        if (!Char.IsLetterOrDigit(password[i + 1]))
                        {
                            isValid = false;
                            //Console.WriteLine("{0} Failed the tests from neighboring specials.", password);
                           
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        specCounter++;
                        continue;
                    }
                    specCounter++;
                }
                else if (Char.IsDigit(currentSymbol))
                {
                    try
                    {
                        if (Char.IsDigit(password[i + 1]))
                        {
                            isValid = false;
                            //Console.WriteLine("{0} Failed the tests from neighboring digits.", password);
                            
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        digitCounter++;
                        continue;
                    }
                    digitCounter++;
                }
            }
            if (capsCounter < 2 || lowerCounter < 2 || specCounter < 2 || digitCounter < 2)
            {
                //Console.WriteLine("{0} Failed the tests from the password not having enough variety.", password);
                
                isValid = false;
            }
            
            return isValid;
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int pswdLength;
            bool validPassword = false;
            string newPassword = "";
            int attemptCounter = 0;

            Console.WriteLine("Hello. Welcome to the password Generator. \nPlease enter a length between 8-16.");
            pswdLength = Convert.ToInt32(Console.ReadLine());

            while (!validPassword)
            {
                attemptCounter++;
                newPassword = generatePassword(pswdLength, rand);
                if (TestPassword(newPassword) == true)
                {
                    validPassword = true;
                }
            }
            Console.WriteLine("\nPassword creation attempts: {0}", attemptCounter);
            Console.WriteLine("\nThe new SAFE generated password is : {0}", newPassword);
            Console.ReadKey();
        }
    }
}
