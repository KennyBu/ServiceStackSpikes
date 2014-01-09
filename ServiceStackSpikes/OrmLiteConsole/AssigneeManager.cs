using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace OrmLiteConsole
{
    public interface IAssigneeManager
    {
        ICollection<Assignee> GetAssignees();
        ICollection<Assignee> GetAssignees(Guid? id, string name, string email, bool? sendKm,
            int? testNumber, int? testNumber2);
    }

    public class AssigneeManager : IAssigneeManager
    {
        private readonly OrmLiteConnectionFactory _dbFactory;
        private readonly SqlBuilder _sqlBuilder;

        public AssigneeManager(string connectionString)
        {
            _dbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance);
            _sqlBuilder = new SqlBuilder();
        }
        
        public ICollection<Assignee> GetAssignees()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<Assignee>();
            }
        }

        public ICollection<Assignee> GetAssignees(Guid? id, string name, string email, bool? sendKm,
            int? testNumber, int? testNumber2)
        {
            _sqlBuilder.Initialize();

            _sqlBuilder.AddParameter("Id", id);
            _sqlBuilder.AddParameter("Name", name);
            _sqlBuilder.AddParameter("Email", email);
            _sqlBuilder.AddParameter("SendKm", sendKm);
            _sqlBuilder.AddParameter("TestNumber", testNumber);
            _sqlBuilder.AddParameter("TestNumber2", testNumber2);

            var final = _sqlBuilder.Build("AND");

            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<Assignee>(final, _sqlBuilder.BuildParameters);
            }
        }
    }
}