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
 public class UserInGroup
  {
    public string UserPhoneGroup { get; set; }
    public DefinitionUser Definition { get; set; }
  }
}
