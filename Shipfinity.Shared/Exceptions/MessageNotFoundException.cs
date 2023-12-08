namespace Shipfinity.Shared.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException(int id) : base($"Message with id:[{id}] was not found") { }
    }
}
