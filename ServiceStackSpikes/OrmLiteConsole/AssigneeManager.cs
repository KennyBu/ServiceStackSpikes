using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace OrmLiteConsole
{
    public interface IAssigneeManager
    {
        ICollection<Assignee> GetAssignees();
        ICollection<Assignee> GetAssignees(Guid id, string name, string email);
    }

    public class AssigneeManager : IAssigneeManager
    {
        private readonly OrmLiteConnectionFactory _dbFactory;

        public AssigneeManager(string connectionString)
        {
            _dbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance);
        }
        
        public ICollection<Assignee> GetAssignees()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<Assignee>();
            }
        }

        public ICollection<Assignee> GetAssignees(Guid id, string name, string email)
        {
            var sql = new List<string>();
            var values = new Dictionary<string, object>();

            if(id != Guid.Empty)
            {
                sql.Add("Id = @Id");    
                values.Add("Id", id);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql.Add("Name Like @Name");
                values.Add("Name", name.SearchExpressionToSql());
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                sql.Add("Email Like @Email");
                values.Add("Email", email.SearchExpressionToSql());
            }
            
            var final = string.Join(" AND ", sql);

            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<Assignee>(final, values);
            }

        }
    }
}