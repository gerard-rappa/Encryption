using System;
using System.IO;

namespace EX3A
{
    class Program
    {
        static void Main(string[] args)
        {
            textFile();
            UserPath();
        }
        static void textFile() { 

            string fileName = Directory.GetCurrentDirectory() + "\\hashedAccounts.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (!File.Exists(fileName))
                {
                    FileStream fs = File.Create(fileName);
                    fs.Close();
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Account populateUser = new Account();
                        populateUser.Username = lines[i];
                        populateUser.Password = lines[++i];
                        AccountList.ExistingAccount(populateUser);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        static void UserPath()
        {
            while (true)
            {

                Console.WriteLine(
                    "\nPASSWORD AUTHENTICATION SYSTEM" +
                    "\nPlease select one option:" +
                    "\n\t1.Establish an account" +
                    "\n\t2.Authenticate a user" +
                    "\n\t3.Exit the system\n" +
                    "\nEnter selection: ");
                int input;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        if (input < 1 || input > 4)
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                } while (input < 1 || input > 4);

                switch (input)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Authenticate.Authenticator();
                        break;
                    case 3:
                        Console.WriteLine("Press anything to exit");
                        Console.ReadKey();
                        FileHandler.storeAccounts();
                        Environment.Exit(0);
                        return;
                    case 4:
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static Account CreateAccount()
        {
            Account NewUser = new Account();
            Console.WriteLine("Enter new username:");
            bool exists = false;
            do
            {
                NewUser.Username = Console.ReadLine();
                //UserAccount should be list of accounts
                //Dictionary<string,string> UserAccounts = new Dictionary<string, string>();
                if (Authenticate.Authenticator(NewUser.Username))
                {
                    Console.WriteLine("Account Exists\n Please enter a new username\n");
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            } while (exists == true);
            Console.WriteLine("Enter Password:");
            string firstinput = Console.ReadLine();
            Console.WriteLine($"Enter Password Again");
            string secondinput = "";
            do
            {
                secondinput = Console.ReadLine();
                if (secondinput != firstinput)
                {
                    Console.WriteLine("Passwords do not match.\n");
                }
            } while (secondinput != firstinput);

            NewUser.Password = secondinput;
            AccountList.AddAccount(NewUser);
            return NewUser;
        }
    }
}
