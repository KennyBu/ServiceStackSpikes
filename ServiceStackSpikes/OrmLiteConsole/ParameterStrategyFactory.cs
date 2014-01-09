using System;
using System.Collections.Generic;

namespace OrmLiteConsole
{
    public static class ParameterStrategyFactory
    {
        public static IParameterStrategy Create(Type parameterType, List<string> sql, 
            Dictionary<string, object> values)
        {
            if (parameterType == typeof(Guid))
            {
                return new GuidParameterStrategy(sql, values);
            }

            if (parameterType == typeof(bool))
            {
                return new BooleanParameterStrategy(sql, values);
            }

            if (parameterType == typeof(int))
            {
                return new IntParameterStrategy(sql, values);
            }
            
            return new StringParameterStrategy(sql, values);
        }
    }
}