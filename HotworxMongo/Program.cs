using HotworxMongo.Data;
using HotworxMongo.Database;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var db = new MongoDBWraper( "Hotworx" );

        var leaderboard = db.Database.GetCollection<BsonDocument>("Leaderboard_RAW");

        var l2 = leaderboard.Find(new BsonDocument()).ToList();

        foreach ( var leader in l2 )
        {
            var l = BsonSerializer.Deserialize<LeaderboardResults>(leader);
            Console.WriteLine(l.Message);
        }


    }
}