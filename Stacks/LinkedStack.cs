namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

class LinkedStack<T> : IStack<T> where T : System.IComparable<T>
{
    //-----------------------------------------------------------------------//

    /*
    [Structure]

        |
        | Internally, we're using a linked list.
        |
        | We don't need indices. Everything will just refer to inner's head.
        |
    
    */

    //-----------------------------------------------------------------------//

    private readonly LinkedList<T> inner = new();

    //-----------------------------------------------------------------------//

    public T Pop()
    {
        // return and remove the head of our internal list
        return inner.Delete(0);
    }

    //-----------------------------------------------------------------------//

    public void Push(T value)
    {
        // insert `value` into our internal list's head,
        // metaphorically pushing everything else back.
        inner.Insert(0, value);
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
        // Return the head of our internal list
        return inner.Read(0);
    }

    //-----------------------------------------------------------------------//
}

///////////////////////////////////////////////////////////////////////////////
