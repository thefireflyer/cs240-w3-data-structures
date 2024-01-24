namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

class LinkedQueue<T> : IQueue<T> where T : System.IComparable<T>
{
    //-----------------------------------------------------------------------//

    /*
    [Structure]

        |
        | Internally, we're using a linked list.
        |
        | We don't need indices. Everything will just refer to inner's head
        | and tail.
        |
    
    */

    //-----------------------------------------------------------------------//

    private readonly LinkedList<T> inner = new();

    //-----------------------------------------------------------------------//

    public T Dequeue()
    {
        // return and remove inner's head
        return inner.Delete(0);
    }


    public void Enqueue(T value)
    {
        // stick `value` onto the end of inner's tail
        inner.Push(value);
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return inner.IsEmpty();
    }

    public bool IsFull()
    {
        // Linked lists don't have a sense of capacity, we always have space.
        // (ignoring physical memory limits)
        return false;
    }

    //-----------------------------------------------------------------------//

    public T Peek()
    {
        // return inner's head
        return inner.Read(0);
    }

    //-----------------------------------------------------------------------//
}

///////////////////////////////////////////////////////////////////////////////
