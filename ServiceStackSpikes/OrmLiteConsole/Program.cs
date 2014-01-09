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
            
            var assignees = manager.GetAssignees(Guid.Empty, name, email);

            foreach (var assignee in assignees)
            {
                Console.WriteLine("Name:{0} email:{1}", assignee.Name, assignee.Email);
            }

            Console.Read();
        }
    }
}
