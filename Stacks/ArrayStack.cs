using System.Collections;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

class ArrayStack<T> : IStack<T> where T : IComparable<T>
{

    //-----------------------------------------------------------------------//

    /*
    [Structure]

        |
        | Internally, we're using a raw array to store our contents.
        |
        | We'll track our "top" element by its index and store it as `cursor`.
        |
        | Since we only ever access the top, `cursor` also serves as a size
        | field (minus 1).
        |
        | An empty array will have size 0 so `cursor` will be -1. This will
        | need special handling.
        |

    [!!] `cursor` is size - 1

    */

    //-----------------------------------------------------------------------//

    private T[] inner = [];

    int cursor = -1; //size = 0

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return cursor == -1; //size == 0
    }

    public bool IsFull()
    {
        return cursor + 1 >= inner.Length; // size >= inner.Length
    }

    //-----------------------------------------------------------------------//

    public void Push(T value)
    {
        // Move our cursor forward so we're pointing to a fresh slot
        cursor++;

        if (IsFull())
        {
            // Create a new inner list with twice the size plus 1 extra slot
            T[] list = new T[inner.Length * 2 + 1];

            // Copy the contents of the old list onto the new list
            for (int i = 0; i < inner.Length; i++)
            {
                list[i] = inner[i];
            }

            // Set our inner field to our new list
            inner = list;
        }

        // Set the slot to `value`
        inner[cursor] = value;
    }

    //-----------------------------------------------------------------------//

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Cannot pop empty stack");
        }

        // Save the value of the current head 
        T value = inner[cursor];

        // Equivalent to popping the head
        cursor--;

        // Return our saved head value
        return value;
    }

    //-----------------------------------------------------------------------//

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("Cannot peek into empty stack");
        }

        // Just return the value of the current head
        return inner[cursor];
    }

    //-----------------------------------------------------------------------//
}

///////////////////////////////////////////////////////////////////////////////
