using System.Collections;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

class ArrayQueue<T> : IQueue<T> where T : System.IComparable<T>
{
    //-----------------------------------------------------------------------//

    /*
    [Structure]

        |
        | Internally, we're using a raw array to store our contents.
        |
        | We'll track our head by it's index, as `enqueuePos`.
        |
        | We'll track our tail by it's index, as `dequeuePos`.
        |
        | Our indices will wrap around our inner array until we run out of
        | space. This will need special handling.
        |

    */

    //-----------------------------------------------------------------------//


    private T[] inner = [];

    private int enqueuePos = 0;
    private int dequeuePos = 0;

    //-----------------------------------------------------------------------//

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new Exception("Cannot dequeue from an empty queue!");
        }

        T value = inner[dequeuePos];

        dequeuePos = (dequeuePos + 1) % inner.Length;

        return value;
    }

    public void Enqueue(T value)
    {
        if (IsFull())
        {
            T[] list = new T[(inner.Length + 1) * 2];

            for (int i = 0; i < inner.Length; i++)
            {
                list[i] = inner[i];
            }

            inner = list;

        }

        // Console.WriteLine(enqueuePos);
        // foreach (T? item in inner)
        // {
        //     Console.Write(", ");
        //     Console.Write(item);
        // }

        inner[enqueuePos] = value;
        enqueuePos = (enqueuePos + 1) % inner.Length;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return enqueuePos == dequeuePos;
    }

    public bool IsFull()
    {
        return inner.Length == 0 || enqueuePos == dequeuePos + 1;
    }

    //-----------------------------------------------------------------------//

    public T Peek()
    {
        return (T)inner[dequeuePos];
    }

    //-----------------------------------------------------------------------//
}

///////////////////////////////////////////////////////////////////////////////
