using System;
using System.Collections.Generic;
using System.IO;


namespace Project33.libraries
{
    internal class FileManagement
    {
        private static string fileName = @"D:\SACUVANO\RajakKurs\34.cas\store\test.log";

        public static void WriteLine(string logMessage)
        {
            using(StreamWriter fileHandle =new StreamWriter(fileName, true))
            {
                fileHandle.WriteLine("{0}",logMessage);
            }
        }

        public static void Write(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(fileName, true))
            {
                fileHandle.WriteLine("{0}", logMessage);
            }
        }
    }
}
