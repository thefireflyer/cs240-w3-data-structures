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
        | We'll track our back by it's index, as `enqueuePos`.
        |
        | We'll track our front by it's index, as `dequeuePos`.
        |
        | Our indices will wrap around our inner array until we run out of
        | space. This will need special handling.
        |

    [!!] if `enqueuePos == dequeuePos` then the queue is empty

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

        // Save the value of the front slot
        T value = inner[dequeuePos];

        // Increment the front pointer to the next slot and wrap around if
        // needed. This is equivalent to popping the front element.
        dequeuePos = (dequeuePos + 1) % inner.Length;

        // Return our saved front value
        return value;
    }

    public void Enqueue(T value)
    {
        if (IsFull())
        {

            // Create a new list with twice the capacity plus 2 extra slot
            // We need one slot so an empty list will not remain empty
            // We need a second to avoid a weird bug where we *always* wrap
            // and get stuck in a size 1 array
            T[] list = new T[inner.Length * 2 + 2];

            // Copy the contents of the old list onto the new list
            for (int i = 0; i < inner.Length; i++)
            {
                list[i] = inner[i];
            }

            // Update our inner field to the new, larger, list
            inner = list;

        }

        // Set the current enqueue slot to our value
        inner[enqueuePos] = value;

        // Increment our enqueue slot forward in the inner list and wrap
        // around if needed. Equivalent to adding to the back of a list.
        enqueuePos = (enqueuePos + 1) % inner.Length;

    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return enqueuePos == dequeuePos;
    }

    public bool IsFull()
    {
        /*
        There are 3 cases where our queue is full:
        (1) our enqueue slot is the last slot in the array 
                (default case, avoids weird wrapping problems)

        (2) our enqueue slot is out of bounds 
                (this should only happen when inner is empty)

        (3) our enqueue slot is directly before our dequeue slot
                (this can happen after wrapping)

        */
        return enqueuePos >= inner.Length - 1 || enqueuePos == dequeuePos - 1;
    }

    //-----------------------------------------------------------------------//

    public T Peek()
    {
        // Return the front item
        return inner[dequeuePos];
    }

    //-----------------------------------------------------------------------//
}