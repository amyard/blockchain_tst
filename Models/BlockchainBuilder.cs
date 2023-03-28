using blockchain;

class BlockchainBuilder
{
    private readonly IHashFunction _hashFunction;
    private string _tail;

    public BlockchainBuilder(IHashFunction hashFunction, string tail)
    {
        _hashFunction = hashFunction;
        _tail = tail;
    }

    public Block AddBlock(string data)
    {
        var hash = _hashFunction.GetHash(_tail + data);
        Block block = new(_tail, data, hash);
        _tail = hash;
        
        return block;
    }
}