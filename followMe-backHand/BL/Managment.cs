using DAL;
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
  }
}
