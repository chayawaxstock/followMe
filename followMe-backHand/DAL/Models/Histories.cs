using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Histories
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime DateError { get; set; }
        public Group Group { get; set; }
        public UserProfile User { get; set; }
        public string Message { get; set; }

    }
}
