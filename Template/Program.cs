using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite sc = new SPSite("http://dev-jl364/eval/vs2013"))
            {
                foreach (SPWeb site in sc.AllWebs)
                {
                    Console.WriteLine(site.Title);
                }
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

    }
}
