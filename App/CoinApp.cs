using System.Text.Json;

namespace blockchain.Old;


public class CoinApp
{
    private readonly IEncryptor _encryptor;
    private readonly TypedBlockchain<TransactionBlock> _blockchain;

    public CoinApp(IEncryptor encryptor)
    {
        _encryptor = encryptor;
        _blockchain = new TypedBlockchain<TransactionBlock>(
            new Blockchain(new CRC32Hash()),
            new SignedRule(encryptor), new AmountRule());
    }

    public void AddTransaction(TransactionBlock transactionBlock)
    {
        _blockchain.AddBlock(transactionBlock);
    }
    
    public void PerformTransaction(KeyPair from, string toPublicKey, long amount)
    {
        var transaction = new Transaction(from.PublicKey, toPublicKey, amount);
        var transactionString = JsonSerializer.Serialize(transaction);
        var sign = _encryptor.Sign(transactionString, from.PrivateKey);
        var transactionBlock = new TransactionBlock(transaction, sign);

        AddTransaction(transactionBlock);
    }
}