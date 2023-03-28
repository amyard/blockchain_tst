interface IRule<T>
{
    void Execuxe(IEnumerable<TypedBlock<T>> previousBlocks, TypedBlock<T> nextBlock);
}