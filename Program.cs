// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using blockchain;
using blockchain.Old;

/*
// First application
var app = new PopulationCensusApp();
app.RegisterPerson(new Person("max", "awe"));
app.RegisterPerson(new Person("asd", "lolol"));
app.RegisterPerson(new Person("asd", "lolol"));
app.PrintAll();
*/

// Coin App
var encryptor = new RSAEncryptor();
var coinApp = new CoinApp(encryptor);

var user1 = encryptor.GenerateKeys();
var user2 = encryptor.GenerateKeys();
var user3 = encryptor.GenerateKeys();

coinApp.PerformTransaction(user1, user2.PublicKey, 50);
coinApp.PerformTransaction(user2, user3.PublicKey, 125);

// иммитация взлома
var tr = new Transaction(user1.PublicKey, user2.PublicKey, 200);
var sign = encryptor.Sign(user1.PrivateKey, JsonSerializer.Serialize(tr));

coinApp.AddTransaction(new TransactionBlock(tr, sign));
