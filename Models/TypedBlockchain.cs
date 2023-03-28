using System.Collections;
using System.Text.Json;

class TypedBlockchain<T> : IEnumerable<TypedBlock<T>>
{
    private readonly Blockchain _blockchain;
    private readonly IRule<T>[] _rules;

    public TypedBlockchain(Blockchain blockchain, params IRule<T>[] rules)
    {
        _blockchain = blockchain;
        _rules = rules;
    }

    public void AddBlock(T data)
    {
        var raw = JsonSerializer.Serialize(data);
        var lowBlock = _blockchain.BuildBlock(raw);
        var block = TypedBlock<T>.FromLowLevel(lowBlock);

        foreach (var rule in _rules)
        {
            rule.Execuxe(this, block);
        }

        _blockchain.AddBlock(lowBlock);
    }

    public IEnumerator<TypedBlock<T>> GetEnumerator()
    {
        return _blockchain
            .Select(TypedBlock<T>.FromLowLevel)
            .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}