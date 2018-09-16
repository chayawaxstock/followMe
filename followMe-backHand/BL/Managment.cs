using DAL;
using DAL.Models;
using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  static public class  Managment
  {
    public async static Task<bool> AddManagment1(string group,string user )
    {
      return await conectDB.AddManagment(group, user);
    }

        public async static Task<bool> sendMessageComplex(MessageUser messageUser )
        {
          var allUsers=  await conectDB.getAllUsers();
          var correctUser = allUsers.FirstOrDefault(p => p.marker.name.Equals(messageUser.UserName));
          return await conectDB.setNewErrorToUser(correctUser, messageUser.Message, messageUser.Group);
        }
    }
}
