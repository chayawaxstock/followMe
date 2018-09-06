using DAL.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace QualiAPI.Models
{
    public class UserProfile
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string Image { get; set; }
        public bool status { get; set; }//האם הוא פעיל
       
        public List<MessageUser> UserMessageNeedGet { get; set; }//התראות שהלקוח צריך לקבל
        public Marker marker { get; set; }

        public eKindMessage kindMessage { get; set; }

    }
}
