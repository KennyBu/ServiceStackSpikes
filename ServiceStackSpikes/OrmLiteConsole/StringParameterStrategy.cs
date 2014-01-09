using System.Collections.Generic;

namespace OrmLiteConsole
{
    public class StringParameterStrategy : IParameterStrategy
    {
        private readonly List<string> _sql;
        private readonly Dictionary<string, object> _values;

        public StringParameterStrategy(List<string> sql, Dictionary<string, object> values)
        {
            _sql = sql;
            _values = values;
        }

        public void BuildParameter(string parameterName, object parameterValue)
        {
            var variable = parameterValue.ToString().SearchExpressionToSql();
            if (!string.IsNullOrWhiteSpace(variable))
            {
                _sql.Add(string.Format("{0} Like @{1}", parameterName, parameterName));
                _values.Add(parameterName, variable);
            }
        }
    }
}