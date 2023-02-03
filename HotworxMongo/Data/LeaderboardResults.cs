
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotworxMongo.Data
{
	public class DatedDocument
	{
        public DateTime Date { get; set; }
    }

    public class BaseDocument : DatedDocument
	{

        [BsonId]
        public ObjectId Id { get; set; }

        [JsonPropertyName("message")]
        [BsonElement("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        [BsonElement("status")]
        public bool Status { get;set;}

        [JsonPropertyName("message1")]
        [BsonElement("message1")]
        public string Message1 { get; set; }
	}

    internal class LeaderboardResults : BaseDocument
    {
		public LeaderboardResults() {  Leaderboard = new List<Leaderboard>(); }

        [BsonElement("leaderboard")]
        [JsonPropertyName("leaderboard")]
        List<Leaderboard> Leaderboard { get; set; }
    }

	public class Leaderboard : DatedDocument
	{
        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserID { get; set; }

        public string TotalCaloriesBurnt { get; set; }

        [BsonElement("reward")]
        [JsonPropertyName("reward")]
        public string Reward { get; set; }

        [BsonElement("username")]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [BsonElement("selft_entry")]
        [JsonPropertyName("selft_entry")]
        public string SelfEntry { get; set; }

    }


    public class DailyResults : BaseDocument
    {
        [BsonElement("summary")]
        [JsonPropertyName("summary")]
        public List<Summary> Summaries { get;set;}

        [BsonElement("classes_completed")]
        [JsonPropertyName("classes_completed")]
        public List<Classes> Classes { get; set; }
    }

    public class Summary
    {
        [BsonElement("isometric_calories")]
        [JsonPropertyName("isometric_calories")]
        public string IsometricCalories { get; set; }

        [BsonElement("hiit_calories")]
        [JsonPropertyName("hiit_calories")]
        public string HIITCalories { get; set; }

        [BsonElement("after_burn")]
        [JsonPropertyName("after_burn")]
        public string AfterBurn { get; set; }

        public Classes GetAfterburn( )
        {
            return new Classes { Type = "Afterburn", Calories = AfterBurn };
        }

    }

    public class Classes
    {
        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [BsonElement("burn_calories")]
        [JsonPropertyName("burn_calories")]
        public string Calories { get; set; }
    }


}
