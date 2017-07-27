using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Administration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Farm = ", SPFarm.Local.DisplayName);

            //windows services
            foreach (SPService sps in SPFarm.Local.Services)
            {
                if (sps is SPWindowsService)
                {
                    Console.WriteLine("\n\t\t\tService Type: {0}", sps.TypeName);
                    Console.WriteLine("\t\t\tService Name: {0}", sps.Name);
                    Console.WriteLine("\t\t\tService Instances:\n");

                    foreach (SPServiceInstance instance in sps.Instances)
                    {
                        Console.WriteLine("\t\tInstance Name: {0}", instance.DisplayName);
                        Console.WriteLine("\t\tInstance Name: {0}", instance.Name);
                        Console.WriteLine("\t\tServer: {0}", instance.Server.ToString());
                    }
                }
            }

            //end of app
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
