using System;

namespace LogicLayer.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public string Property { get; private set; }

        public RecordNotFoundException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
