namespace MonBlog;

public class Either<T1, T2>
{
    private readonly Maybe<T1> _t1;
    private readonly Maybe<T2> _t2;

    public Either(T1 value)
    {
        _t1 = new Maybe<T1>(value);
        _t2 = Maybe<T2>.Empty;
    }

    public Either(T2 value)
    {
        _t2 = new Maybe<T2>(value);
        _t1 = Maybe<T1>.Empty;
    }

    public TReturn Map<TReturn>(Func<T1, TReturn> whatToDoIfT1, Func<T2, TReturn> whatToDoIfT2)
    {
        return _t1.Map(whatToDoIfT1, () => _t2.Map(whatToDoIfT2, () => throw new InvalidOperationException()));
    }
}