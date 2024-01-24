namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

/// A common interface for Stack strucutes
public interface IStack<T> where T : IComparable<T>
{
    /// Return and remove the top of the stack
    public T Pop();

    /// Place `value` on the top of the stack
    public void Push(T value);

    public bool IsEmpty();

    public bool IsFull();

    /// Return the top of the stack
    public T Peek();

}

///////////////////////////////////////////////////////////////////////////////
