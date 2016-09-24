using BattletiteAPI.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace BattletiteAPI.DataContext
{
    public static class DBValidation
    {
        public const string _id = "_id";
        public const string _name = "name";

        public static ObjectId CheckId(string id)
        {
            ObjectId objectId;

            if (!ObjectId.TryParse(id, out objectId))
            {
                throw new ValidationException("Must be a valid object id.");
            }

            return objectId;
        }

        public static FilterDefinition<T> NameOrIdFilter<T>(string id) where T : Named
        {
            ObjectId objectId;

            if (ObjectId.TryParse(id, out objectId))
            {
                return Builders<T>
                    .Filter
                    .Eq(_id, objectId);
            }

            return Builders<T>
                    .Filter
                    .Regex(f => f.Name, new BsonRegularExpression($"/^{id}$/i"));
        }
    }
}
