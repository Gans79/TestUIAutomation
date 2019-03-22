using System;
using System.Collections.Generic;
using System.IO;
using Comparefiles;
using NUnit.Framework;
namespace ComparefilesTests
{
    public class ComparetwofilesTests
    {
        [Test]
        public void Countsmismatch()
        {
            Comparetwofiles x = new Comparetwofiles();

            List<string> differnce = new List<string>();
            StreamReader f1 = new StreamReader(@"C:\Users\Ganesh\source\repos\TestUIAutomation\Comparefiles\File1.csv");
            StreamReader f2 = new StreamReader(@"C:\Users\Ganesh\source\repos\TestUIAutomation\Comparefiles\File2.csv");
            differnce = x.PerformCompare(f1, f2);

            foreach (var differ in differnce)
            {
                Console.WriteLine("differ is {0}", differ);
            }
        }

    }
}
