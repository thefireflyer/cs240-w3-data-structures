namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

class LinkedList<T> where T : IComparable<T>
{

    class Node<U>(U data, LinkedList<T>.Node<U>? next, LinkedList<T>.Node<U>? prev)
    {
        public U data = data;
        public Node<U>? next = next;
        public Node<U>? prev = prev;
    }

    Node<T>? head;

    Node<T>? Get(uint index)
    {
        Node<T>? cursor = head;
        // iterate until we find our cursor or we reach the
        // end of the list.
        for (uint i = 0; i < index && cursor != null; i++)
        {
            cursor = cursor.next;
        }

        return cursor;
    }

    public T Read(uint index)
    {
        Node<T>? node = Get(index);
        // check for out of bounds error
        if (node != null)
        {
            return node.data;
        }
        else
        {
            throw new Exception("index out of bounds");
        }
    }

    public void Insert(uint index, T value)
    {
        if (value == null || index < 0)
        {
            throw new Exception("invalid arguments!");
        }
        // as in the rust impl, we'll handle head
        // inserts seperately.
        if (index == 0)
        {
            this.head = new Node<T>(value, head, null);
        }
        else
        {
            Node<T>? preceding = Get(index - 1) ?? throw new Exception("index out of bounds!");

            // this is very briefly explained in the rust impl
            /*
            - new node with new data
            - new node's next field is the next element
            - new node's prev field is the preceding element
            - set preceding's next field to new node
            */
            preceding.next = new Node<T>(value, preceding.next, preceding);
            // if the next element after the new one isn't null,
            // we also have to update it's previous field
            if (preceding.next.next != null)
            {
                // super messy but i ran out of time to refactor
                preceding.next.next.prev = preceding.next;
            }
        }

    }

    public T Delete(uint index)
    {

        if (index == 0)
        {
            // same head handling as in rust
            if (head != null)
            {
                T oldValue = head.data;
                head = head.next;
                return oldValue;
            }
            else
            {
                throw new Exception("index out of bounds!");
            }
        }
        else
        {
            // same normal case handling as in rust
            // just much nicer, simpler, syntax
            Node<T>? preceding = Get(index - 1);
            if (preceding == null || preceding.next == null)
            {
                throw new Exception("index out of bounds!");
            }
            T oldValue = preceding.next.data;
            preceding.next = preceding.next.next;
            return oldValue;
        }

    }

    public int Search(T value)
    {
        if (value == null)
        {
            throw new Exception("value is not nullable!");
        }

        int index = 0;

        Node<T>? cursor = head;

        // iterate until we found the target or reach the end
        // of the list
        while (cursor != null && !cursor.data.Equals(value))
        {
            cursor = cursor.next;
            index++;
        }

        if (cursor != null)
        {
            return index;
        }
        else
        {
            return -1;
        }
    }

    public void Sort()
    {
        // insertion sort, very similar to rust impl on arrays
        Node<T>? cursor = head;

        // iterate over each element in the list
        while (cursor != null)
        {

            // save our key
            T key = cursor.data;

            // new node for local cursor
            Node<T>? miniCursor = cursor.prev;

            // iterate local cursor until we've found our current element's
            // correct spot
            while (miniCursor != null && key.CompareTo(miniCursor.data) < 0)
            {

                // swap values
                miniCursor.next.data = miniCursor.data;
                miniCursor.data = key;

                // move leftward
                miniCursor = miniCursor.prev;

            }

            // move rightward
            cursor = cursor.next;

        }

        // algorithm more in depth explained in the rust impl for arrays.
    }

    /// Pushes to the end of the list
    public void Push(T value)
    {
        if (value == null)
        {
            throw new Exception("value is not nullable!");
        }

        Node<T>? cursor = head;

        // just iterate until we've found the second to last node
        while (cursor != null && cursor.next != null)
        {
            cursor = cursor.next;
        }

        // double check we have a valid node (we're on an empty list)
        if (cursor != null)
        {
            // update last element to with new node 
            cursor.next = new Node<T>(value, null, cursor);
        }
        else
        {
            // handle empty list case
            head = new Node<T>(value, null, null);
        }

    }

    public override String ToString()
    {
        String result = "[LinkedList]";
        Node<T>? cursor = head;
        int index = 0;

        while (cursor != null)
        {
            result += "\n" + index.ToString() + " | " + cursor.data.ToString();
            cursor = cursor.next;
            index++;
        }

        return result;
    }

    public uint Length()
    {
        Node<T>? cursor = head;
        uint index = 0;

        while (cursor != null)
        {
            cursor = cursor.next;
            index++;
        }

        return index;
    }


    public bool IsEmpty()
    {
        return head == null;
    }
}

///////////////////////////////////////////////////////////////////////////////
