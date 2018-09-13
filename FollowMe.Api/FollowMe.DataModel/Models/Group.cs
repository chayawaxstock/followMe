using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.DataModel.Models
{
    class Group
    {
        [BsonElement("_id")]
 
        //[BsonId]
        //public ObjectId id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Password { get; set; } //סיסמת מנהל לשינוי הגדרות
        public string Kod { get; set; }//קוד קבוצה רנדומלי

        public bool Status { get; set; }//מצב קבוצה פעיל או מכובה
       // public DefinitionGroup definitionGroup { get; set; }//הגדרות קבוצה

        //public List<ManagmentInGroup> listManagment { get; set; }//מנהלי קבוצה
       // public List<UserInGroup> users { get; set; }
       // public List<UserInGroup> OkUsers { get; set; }//מאשרי קבוצה????
        public DateTime DateBeginTrip { get; set; }//date begin
        public DateTime DateEndTrip { get; set; }//date end
      //  public List<MessageGroup> ErrorMessage { get; set; }//error list 
    }
}
