namespace blockchain;

public class DuplicateRules: IRule<Person>
{
    void IRule<Person>.Execuxe(IEnumerable<TypedBlock<Person>> previousBlocks, TypedBlock<Person> nextBlock)
    {
        if (previousBlocks.Any(x => x.Data.Equals(nextBlock.Data)))
            throw new ApplicationException($"{nextBlock.Data} is already registered.");
    }
}