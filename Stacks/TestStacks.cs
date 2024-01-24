using System.Collections;
using NUnit.Framework;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

[TestFixture(typeof(LinkedStack<int>))]
[TestFixture(typeof(ArrayStack<int>))]
public class TestStacks<TStack>
    where TStack : IStack<int>, new()
{
    [Test]
    public void TestBasics()
    {
        TStack stack = new TStack();
        Assert.That(stack.IsEmpty());
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.That(!stack.IsEmpty());
        Assert.Multiple(() =>
        {
            Assert.That(stack.Peek(), Is.EqualTo(3));
            Assert.That(stack.Pop(), Is.EqualTo(3));
            Assert.That(!stack.IsEmpty());
            Assert.That(stack.Peek(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(2));
            Assert.That(!stack.IsEmpty());
            Assert.That(stack.Peek(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.IsEmpty());
            Assert.That(!stack.IsFull());
        });

        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        Assert.Multiple(() =>
        {
            Assert.That(!stack.IsEmpty());
            Assert.That(stack.Peek(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(1));
        });
    }
}

///////////////////////////////////////////////////////////////////////////////
