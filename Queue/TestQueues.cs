using System.Collections;
using NUnit.Framework;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

[TestFixture(typeof(LinkedQueue<Int64>))]
[TestFixture(typeof(ArrayQueue<Int64>))]
public class TestQueues<TQueue>
    where TQueue : IQueue<Int64>, new()
{
    [Test]
    public void TestBasics()
    {
        TQueue queue = new();
        Assert.That(queue.IsEmpty());
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Multiple(() =>
        {
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.IsEmpty());
            Assert.That(!queue.IsFull());
        });

        queue.Enqueue(3);
        queue.Enqueue(2);
        queue.Enqueue(1);
        Assert.Multiple(() =>
        {
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
        });
        queue.Enqueue(4);
        Assert.Multiple(() =>
        {
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(2));
        });
        queue.Enqueue(5);
        Assert.Multiple(() =>
        {
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(!queue.IsEmpty());
            Assert.That(queue.Peek(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.IsEmpty());
            Assert.That(!queue.IsFull());
        });
    }
}

///////////////////////////////////////////////////////////////////////////////
