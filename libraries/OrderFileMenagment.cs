using System;
using System.Collections.Generic;
using System.IO;

namespace Project33.libraries
{
    internal class OrderFileMenagment
    {
        private static string fileName = @"D:\SACUVANO\RajakKurs\34.cas\store\test.order.txt";

        public static void WriteLine(string orderMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(fileName, true))
            {
                fileHandle.WriteLine("{0}", orderMessage);
            }
        }

        public static void Write(string orderMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(fileName, true))
            {
                fileHandle.WriteLine("{0}", orderMessage);
            }
        }
    }
}
