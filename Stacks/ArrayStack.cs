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
        return cursor + 1 == inner.Length; // size == inner.Length
    }

    //-----------------------------------------------------------------------//

    public void Push(T value)
    {
        cursor++;

        if (cursor >= inner.Length)
        {
            T[] list = new T[inner.Length * 2 + 1];

            for (int i = 0; i < inner.Length; i++)
            {
                list[i] = inner[i];
            }

            inner = list;
        }
        // Console.WriteLine(cursor);
        // Console.WriteLine(inner.Capacity);
        // Console.WriteLine("----");
        // foreach (var item in inner)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine("----\n\n");

        inner[cursor] = value;
    }

    //-----------------------------------------------------------------------//

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Cannot pop empty stack");
        }

        T value = inner[cursor];
        cursor--;

        return value;
    }

    //-----------------------------------------------------------------------//

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new Exception("Cannot peek into empty stack");
        }

        return inner[cursor];
    }

    //-----------------------------------------------------------------------//
}

///////////////////////////////////////////////////////////////////////////////
