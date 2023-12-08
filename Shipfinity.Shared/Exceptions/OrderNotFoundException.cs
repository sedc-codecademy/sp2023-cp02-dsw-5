namespace Shipfinity.Shared.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int id) : base($"Order with id: {id} not found") { }
    }
}
