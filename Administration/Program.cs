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
            Console.WriteLine("\nFarm Name: {0} ", SPFarm.Local.DisplayName);

            //windows services
            foreach (SPService sps in SPFarm.Local.Services)
            {
                Console.WriteLine("\n\tService Type: {0}", sps.TypeName);
                Console.WriteLine("\n\tService Name: {0}", sps.Name);

                if (sps is SPWindowsService)
                {
                    Console.WriteLine("\n\t\tWindows Service Instances:\n");
                    foreach (SPServiceInstance instance in sps.Instances)
                    {
                        Console.WriteLine("\n\t\tInstance Display Name: {0}", instance.DisplayName);
                        Console.WriteLine("\n\t\tInstance Name: {0}", instance.Name);
                        Console.WriteLine("\n\t\tServer: {0}", instance.Server.ToString());
                    }
                }
                else if (sps is SPWebService)
                {
                    SPWebService spws = (SPWebService)sps;
                    Console.WriteLine("\n\t\tWeb Applications in this web service.");
                    foreach (SPWebApplication webapp in spws.WebApplications)
                    {
                        Console.WriteLine("\n\t\tWeb Application Display Name: {0}", webapp.DisplayName);
                        Console.WriteLine("\n\t\tWeb Application Name: {0}\n", webapp.Name);

                        Console.WriteLine("\n\t\t\tContent Databases in this web application:\n");
                        foreach (SPContentDatabase db in webapp.ContentDatabases)
                        {
                            Console.WriteLine("\n\t\t\tContent database name: {0}\n", db.DisplayName);

                            Console.WriteLine("\n\t\t\t\tSite Collection in this content database");
                            foreach (SPSite site in db.Sites)
                            {
                                Console.WriteLine("\n\t\t\t\tSite Collection URL: {0}", site.Url);
                            }
                        }
                    }
                }
            }

            //end of app
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
