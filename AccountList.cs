using System;
using System.Collections.Generic;

namespace EX3A
{
    public class AccountList
    {
        public static Dictionary<string, string> UserAccounts = new Dictionary<string, string>();

        public static void AddAccount(Account input)
        {
            UserAccounts.Add(Encrypt.MakeKey(input.Username), Encrypt.MakeKey(input.Password));
        }
        public static void ExistingAccount(Account input)
        {
            UserAccounts.Add(input.Username, input.Password);
        }
    }
}
