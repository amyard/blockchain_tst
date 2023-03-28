using System.Text.Json;

namespace blockchain;

public class SignedRule : IRule<TransactionBlock>
{
    private readonly IEncryptor _encryptor;

    public SignedRule(IEncryptor encryptor)
    {
        _encryptor = encryptor;
    }
    void IRule<TransactionBlock>.Execuxe(IEnumerable<TypedBlock<TransactionBlock>> _, TypedBlock<TransactionBlock> newBlock)
    {
        var transactionString = JsonSerializer.Serialize(newBlock.Data);
        // var transactionString = JsonSerializer.Serialize(newBlock.Data.Data);
        if (_encryptor.VerifySign(newBlock.Data.Data.From, transactionString, newBlock.Data.Sign))
            throw new ApplicationException("Block is signed incorrectly.");
    }
}