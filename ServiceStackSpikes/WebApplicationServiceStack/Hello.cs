using ServiceStack.ServiceHost;

namespace WebApplicationServiceStack
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }

}