using NUnit.Framework;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class Tests
{
    private LinkedList<Int64> list = new();

    [SetUp]
    public void Setup()
    {
        // Console.WriteLine("setup");
        // Console.WriteLine(list.ToString());
        list.Push(1);//0
        list.Push(2);//1
        list.Push(3);//2
        list.Push(4);//3
        list.Push(5);//4
        Assert.That(list.Length(), Is.EqualTo(5));
        // Console.WriteLine(list.ToString());
        // Console.WriteLine("ending setup\n\n");

    }

    [TearDown]
    public void TearDown()
    {
        list = new();
    }

    [Test]
    public void TestRead()
    {

        // Console.WriteLine("testing read!");
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
            Assert.That(list.Read(4), Is.EqualTo(5));
        });
    }

    [Test]
    public void TestInsert()
    {
        // Console.WriteLine("testing insert!");
        // Console.WriteLine(list.ToString());
        list.Insert(5, 10);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
            Assert.That(list.Read(4), Is.EqualTo(5));
            Assert.That(list.Read(5), Is.EqualTo(10));
        });

        // Console.WriteLine(list.ToString());
        list.Insert(2, 50);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(50));
            Assert.That(list.Read(3), Is.EqualTo(3));
            Assert.That(list.Read(4), Is.EqualTo(4));
            Assert.That(list.Read(5), Is.EqualTo(5));
            Assert.That(list.Read(6), Is.EqualTo(10));
        });

        // Console.WriteLine(list.ToString());
        list.Insert(0, -20);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(-20));
            Assert.That(list.Read(1), Is.EqualTo(1));
            Assert.That(list.Read(2), Is.EqualTo(2));
            Assert.That(list.Read(3), Is.EqualTo(50));
            Assert.That(list.Read(4), Is.EqualTo(3));
            Assert.That(list.Read(5), Is.EqualTo(4));
            Assert.That(list.Read(6), Is.EqualTo(5));
            Assert.That(list.Read(7), Is.EqualTo(10));
        });

    }

    [Test]
    public void TestDelete()
    {
        // Console.WriteLine("testing delete!");
        // Console.WriteLine(list.ToString());
        // Console.WriteLine("deleting @4");
        list.Delete(4);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
        });

        // Console.WriteLine("deleting @0");
        list.Delete(0);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(2));
            Assert.That(list.Read(1), Is.EqualTo(3));
            Assert.That(list.Read(2), Is.EqualTo(4));
        });

        // Console.WriteLine("deleting @1");
        list.Delete(1);
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(2));
            Assert.That(list.Read(1), Is.EqualTo(4));
        });
    }

    [Test]
    public void TestSearch()
    {

        // Console.WriteLine("testing search!");
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Search(3), Is.EqualTo(2));
            Assert.That(list.Search(0), Is.EqualTo(-1));
            Assert.That(list.Search(1), Is.EqualTo(0));
            Assert.That(list.Search(5), Is.EqualTo(4));
        });

        list = new();


        Assert.That(list.Search(3), Is.EqualTo(-1));

    }

    [Test]
    public void TestSort_1()
    {
        // Console.WriteLine("testing sort!");
        // Console.WriteLine(list.ToString());

        list.Sort();
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
            Assert.That(list.Read(4), Is.EqualTo(5));
        });
    }

    [Test]
    public void TestSort_2()
    {
        // Console.WriteLine("testing sort! (2)");

        list = new();
        list.Push(5);
        list.Push(4);
        list.Push(3);
        list.Push(2);
        list.Push(1);

        list.Sort();
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
            Assert.That(list.Read(4), Is.EqualTo(5));
        });
    }

    [Test]
    public void TestSort_3()
    {
        // Console.WriteLine("testing sort! (3)");

        list = new();
        list.Push(5);
        list.Push(1);
        list.Push(2);
        list.Push(4);
        list.Push(3);

        list.Sort();
        // Console.WriteLine(list.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(list.Read(0), Is.EqualTo(1));
            Assert.That(list.Read(1), Is.EqualTo(2));
            Assert.That(list.Read(2), Is.EqualTo(3));
            Assert.That(list.Read(3), Is.EqualTo(4));
            Assert.That(list.Read(4), Is.EqualTo(5));
        });
    }

    [Test]
    public void TestSort_4()
    {
        // Console.WriteLine("testing sort! (4)");

        list = new();

        list.Sort();
        // Console.WriteLine(list.ToString());

        Assert.That(list.Length(), Is.EqualTo(0));

    }
}

///////////////////////////////////////////////////////////////////////////////
