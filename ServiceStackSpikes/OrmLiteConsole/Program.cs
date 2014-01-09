using System;
using System.Configuration;

namespace OrmLiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AssignifyItDatabase"].ToString();
            var manager = new AssigneeManager(connectionString);

            const string name = "Ken****************";
            const string email = "ken.burkhardt@gmail.com";
            var id = Guid.Parse("517B5AFC-B69C-46AA-BE34-E1B3DE80B1E0");
            const bool sendKm = true;
            int? testNumber = 1;
            const int testNumber2 = 2;

            //ar assignees = manager.GetAssignees(id, name, email, sendKm, null, null);
            //var assignees = manager.GetAssignees(id, name, email, sendKm, testNumber, testNumber2);
            var assignees = manager.GetAssignees(null, name, email, sendKm, testNumber, testNumber2);

            foreach (var assignee in assignees)
            {
                Console.WriteLine("Name:{0} email:{1}", assignee.Name, assignee.Email);
            }

            Console.Read();
        }
    }
}
