using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        var enumerable = values.ToList();
        if (enumerable.Count == 0)
            return;

        bool first = true;
        foreach (var value in enumerable)
        {
            if (first)
            {
                Value = value;
                first = false;
                continue;
            }
            Add(value);
        }
    }

    public int Value { get; }

    public BinarySearchTree? Left { get; private set; }

    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left != null)
            {
                return Left.Add(value);
            }

            Left = new BinarySearchTree(value);
            return Left;
        }

        if (Right != null)
        {
            return Right.Add(value);
        }

        Right = new BinarySearchTree(value);
        return Right;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
        {
            foreach (var v in Left)
                yield return v;
        }

        yield return Value;

        if (Right == null)
        {
            yield break;
        }

        {
            foreach (var v in Right)
                yield return v;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
