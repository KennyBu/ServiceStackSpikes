using System;

namespace OrmLiteConsole
{
    public class Assignee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool SendKm { get; set; }
        public int? TestNumber { get; set; }
        public int TestNumber2 { get; set; }
    }
}