using Common;
using ServiceStack.ServiceInterface;

namespace Consumer
{
    public class ShippingAddressService : Service
    {
        public object Any(UpdateShippingAddress request)
        {
            //Update the shipping address in the local db

            //send the response
            var response = new ShippingAddressUpdated
                {
                    OrderIdInt = request.OrderIdInt
                };

            return response;
        }
    }
}