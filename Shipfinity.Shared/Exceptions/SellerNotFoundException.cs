namespace Shipfinity.Shared.Exceptions
{
    public class SellerNotFoundException : Exception
    {
        public SellerNotFoundException(int id) :base($"Seller with id: {id} not found")
        {}
    }
}
