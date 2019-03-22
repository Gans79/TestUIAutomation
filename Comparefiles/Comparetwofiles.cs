using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Comparefiles
{
    public class Comparetwofiles
{
    List<string> differences = new List<string>();
    public static void Main(string[] args)
    {
            Console.WriteLine("Program to compare 2 files !! ");
        }

    public List<string> PerformCompare(StreamReader f1, StreamReader f2)
    {

        differences = new List<string>();
        int lineNumber = 0;
        while (!f1.EndOfStream)
        {
            if (f2.EndOfStream)
            {
                differences.Add("Differing number of lines - f2 has less.");

                break;
            }
            lineNumber++;
            var line1 = f1.ReadLine();
            var line2 = f2.ReadLine();
            if (line1 != line2)
            {
                differences.Add(string.Format("Line {0} differs. File 1: {1}, File 2: {2}", lineNumber, line1, line2));
            }
        }
        if (!f2.EndOfStream)
        {
            differences.Add("Differing number of lines - f1 has less.");
        }
        //Console.ReadLine();
        Console.WriteLine("The difference in the 2 files is {0}", differences.Count);
        //Console.ReadLine();
        return differences;
    }

}
}