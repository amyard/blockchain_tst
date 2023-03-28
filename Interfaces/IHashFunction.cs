namespace blockchain;

public interface IHashFunction
{
    public string GetHash(string data);
}