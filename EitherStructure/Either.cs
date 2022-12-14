namespace EitherStructure;

/// <summary>
/// Implements Either data structure. This structure handles the returns of two possible values, either left or right but never both.
/// </summary>
/// <typeparam name="TL">Define left value</typeparam>
/// <typeparam name="TR">Define right value</typeparam>
public class Either<TL, TR>
{
    private readonly TL _left;
    private readonly TR _right;
    private readonly bool _isLeft;
    
    public Either(TL left)
    {
        _left = left;
        _isLeft = true;
    }

    public Either(TR right)
    {
        _right = right;
        _isLeft = false;
    }

    /// <summary>
    /// Match value in order to return left or right.
    /// </summary>
    /// <param name="leftFunction">Define left function</param>
    /// <param name="rightFunction">Define right function</param>
    /// <typeparam name="T">Return value type</typeparam>
    /// <returns>Returns value from either left or right function</returns>
    /// <exception cref="ArgumentNullException">Both functions can not be null</exception>
    /// <remarks>Even left and right function handle different types the return must be same, T</remarks>
    public T Match<T>(Func<TL, T> leftFunction, Func<TR, T> rightFunction)
    {
        if (leftFunction == null)
        {
            throw new ArgumentNullException(nameof(leftFunction));
        }

        if (rightFunction == null)
        {
            throw new ArgumentNullException(nameof(rightFunction));
        }
        
        return _isLeft ? leftFunction(_left) : rightFunction(_right);
    }

    public static implicit operator Either<TL, TR>(TL left)
    {
        return new Either<TL, TR>(left);
    }

    public static implicit operator Either<TL, TR>(TR right)
    {
        return new Either<TL, TR>(right);
    }
}