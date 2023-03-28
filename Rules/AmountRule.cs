namespace blockchain;

public class AmountRule : IRule<TransactionBlock>
{
    void IRule<TransactionBlock>.Execuxe(IEnumerable<TypedBlock<TransactionBlock>> previousBlocks, 
        TypedBlock<TransactionBlock> newBlock)
    {
        long balance = 100;
        var currentUser = newBlock.Data.Data.From;
        
        foreach (var block in previousBlocks)
        {
            if (block.Data.Data.From == currentUser)
                balance -= block.Data.Data.Amount;
            else if (block.Data.Data.To == currentUser)
                balance += block.Data.Data.Amount;
        }

        if (balance < newBlock.Data.Data.Amount)
            throw new ApplicationException("User has not enough funds.");
    }
}