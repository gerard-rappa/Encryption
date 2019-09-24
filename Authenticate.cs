using System;
using System.Collections.Generic;
using System.Text;

namespace EX3A
{
    class Authenticate
    {
        public static void Authenticator()
        {
            //AccountList.UserAccounts
            Console.WriteLine("Enter Username: ");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            if (AccountList.UserAccounts.ContainsKey(Encrypt.MakeKey(user)))//user exists
            {
                //pass matches
                if (AccountList.UserAccounts[Encrypt.MakeKey(user)].Equals(Encrypt.MakeKey(password)))
                {
                    Console.WriteLine("You got it, bud\n");
                }
                //does not match
                else
                {
                    Console.WriteLine("Password does not match\n");
                }
            }
            else//user does not exist
            {
                Console.WriteLine("User does not exist\n");
            }
        }

        public static bool Authenticator(string username)
        {
            if (AccountList.UserAccounts.ContainsKey(Encrypt.MakeKey(username))) return true;
            else return false;
        }

    }
}
