using ServiceStack.ServiceInterface;

namespace WebApplicationServiceStack
{
    public class HelloService : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello man your name is, " + request.Name };
        }
    }
}