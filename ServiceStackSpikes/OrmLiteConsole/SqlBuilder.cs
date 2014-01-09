using System.Collections.Generic;

namespace OrmLiteConsole
{
    public class SqlBuilder
    {
        private readonly List<string> _sql;
        private readonly Dictionary<string, object> _values;

        public SqlBuilder()
        {
            _sql = new List<string>();
            _values = new Dictionary<string, object>();
        }

        public void Initialize()
        {
            _sql.Clear();
            _values.Clear();
        }

        public void AddParameter(string parameterName, object parameterValue)
        {
            if (parameterValue != null)
            {
                var type = parameterValue.GetType();
                var strategy = ParameterStrategyFactory.Create(type, _sql, _values);

                strategy.BuildParameter(parameterName, parameterValue);
            }
        }

        public Dictionary<string, object> BuildParameters
        {
            get { return _values; }
        }
        
        public string Build(string delimeter)
        {
            return string.Join(string.Concat(" ", delimeter," "), _sql);
        }
    }
}