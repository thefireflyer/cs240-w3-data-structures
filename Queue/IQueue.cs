namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

/// A common interface for Queue structures
public interface IQueue<T> where T : IComparable<T>
{

    /// Add `value` to the back of the queue (on the right)
    public void Enqueue(T value);

    /// Return and remove the head of the queue (on the left)
    public T Dequeue();

    public bool IsEmpty();

    public bool IsFull();

    /// Return the head of the queue (on the left)
    public T Peek();

}

///////////////////////////////////////////////////////////////////////////////
