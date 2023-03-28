using System.Collections;
using blockchain;

class Blockchain : IEnumerable<Block>
{
    private readonly IHashFunction _hashFunction;
    private readonly BlockchainBuilder _builder;
    private readonly List<Block> _blocks = new();

    public Blockchain(IHashFunction hashFunction)
    {
        _builder = new BlockchainBuilder(hashFunction, null);
        _hashFunction = hashFunction;
    }

    public Block BuildBlock(string data)
    {
        var tail = _blocks.LastOrDefault();
        var block = _builder.AddBlock(data);

        return block;
    }
    
    // check the valid block
    public void AddBlock(Block block)
    {
        var tail = _blocks.LastOrDefault();
        
        if (block.ParentHash == tail?.Hash)
        {
            var expectedHash = _hashFunction.GetHash(block.ParentHash + block.Data);

            if (expectedHash == block.Hash)
                _blocks.Add(block);
            else
                throw new ApplicationException("Block hash is invalid.");
        }
        else
        {
            throw new ApplicationException($"{block.Hash} is incorrect. Because of ParentHash. It should be {tail.Hash} but receive {block.ParentHash}");
        }
    }

    public IEnumerator<Block> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}