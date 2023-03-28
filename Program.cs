// See https://aka.ms/new-console-template for more information

using blockchain;

string text = "Hello, World!";
var sha = new SHA256Hash();
var crc = new CRC32Hash();

// Console.WriteLine(sha.GetHash(text));
// Console.WriteLine(crc.GetHash(text));

/*
//  целостность хешей
var data = Enumerable.Range(0, 10).ToArray();
string parentHash = null!;

int? prevData = null;
var blockchain = new List<Block>();

foreach (var item in data)
{
    var block = new Block(parentHash, item.ToString());
    blockchain.Add(block);
    Console.WriteLine(block);
    parentHash = crc.GetHash(block.ParentHash + block.Data);
}


parentHash = null!;
data[2] = 700;

foreach (var item in data)
{
    var block = new Block(parentHash, item.ToString());
    blockchain.Add(block);
    Console.WriteLine(block);
    parentHash = crc.GetHash(block.ParentHash + block.Data);
}
*/

/*
//  целостность хешей 2
var builder = new BlockchainBuilder(crc, null);
var chain = Enumerable.Range(0, 10).Select(x => builder.AddBlock(x.ToString()));
foreach (var block in chain)
{
    Console.WriteLine(block);
}
*/

//  целостность хешей 3
var builder = new BlockchainBuilder(crc, null);
var blockchain = new Blockchain(crc);
foreach (var item in Enumerable.Range(0, 10))
{
    var block = builder.AddBlock(item.ToString());
    // make invalid block
    // if(item == 7)
    //     block = block with { ParentHash = "Ololo" };
    blockchain.AddBlock(block);
}