using System;

namespace Project_BlueLock.Utilities
{
    /// <summary>
    /// This class is used to create custom event arguments that can hold a value of a specific type T
    /// </summary>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
    }
}
