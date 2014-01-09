namespace OrmLiteConsole
{
    public interface IParameterStrategy
    {
        void BuildParameter(string parameterName, object parameterValue);
    }
}