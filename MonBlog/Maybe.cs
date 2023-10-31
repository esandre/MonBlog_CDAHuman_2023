namespace MonBlog;

public class Maybe<T>
{
    public static Maybe<T> Empty => new ();
    private readonly T? _value;

    private Maybe()
    {
        _value = default;
    }

    public Maybe(T value)
    {
        _value = value;
    }

    public TReturn Map<TReturn>(
        Func<T, TReturn> whatToDoIfPresent,
        Func<TReturn> whatToDoIfAbsent)
    {
        return _value is null ? whatToDoIfAbsent() : whatToDoIfPresent(_value);
    }

    public static implicit operator Maybe<T>(T value)
    {
        return new Maybe<T>(value);
    }
}