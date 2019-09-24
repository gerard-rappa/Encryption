using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EX3A
{
    class FileHandler
    {
        public static void storeAccounts()
        {

            string path = Directory.GetCurrentDirectory();
            File.WriteAllText(path+"\\hashedAccounts.txt", "");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "hashedAccounts.txt"), true))

                foreach (var item in AccountList.UserAccounts)
                {
                    outputFile.WriteLine(item.Key);
                    outputFile.WriteLine(item.Value);
                }
        }
    }
}

