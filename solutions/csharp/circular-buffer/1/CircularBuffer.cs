
public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _head;
    private int _tail;

    public CircularBuffer(int capacity)
        => _buffer = new T[capacity];

    public T Read()
    {
        if (_buffer.All(i => EqualityComparer<T>.Default.Equals(i, default)))
            throw new InvalidOperationException("Buffer is empty.");
        var value = _buffer[_tail];
        TargetedClear(ClearMode.Tail);
        _tail = (_tail + 1) % _buffer.Length;
        return value!;
    }

    public void Write(T value)
    {
        if (_buffer.All(i => !EqualityComparer<T>.Default.Equals(i, default)))
            throw new InvalidOperationException("Buffer is full.");
        _buffer[_head] = value;
        _head = (_head + 1) % _buffer.Length;
    }

    public void Overwrite(T value)
    {
        if (_buffer.All(i => !EqualityComparer<T>.Default.Equals(i, default)))
        {
            TargetedClear(ClearMode.Tail);
            _buffer[_tail] = value;
            _tail = (_tail + 1) % _buffer.Length;
        }
        else
            Write(value);
    }

    public void Clear()
    {
        _buffer.AsSpan().Clear();
        _head = 0;
        _tail = 0;
    }

    private enum ClearMode
    {
        Head,
        Tail,
    }

    private void TargetedClear(ClearMode head)
    {
        if (head == ClearMode.Head)
            _buffer.AsSpan(_head, 1).Clear();
        else
            _buffer.AsSpan(_tail, 1).Clear();
    }
}
