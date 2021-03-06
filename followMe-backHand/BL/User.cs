using DAL;
using DAL.Models;
using MongoDB.Bson;
using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class User
    {

        public async static Task<UserProfile> LoginUser(string phone)
        {
            var response = await conectDB.getUser(phone);
            return response;
        }


        public async static Task<bool> RegisterUser(UserProfile user)
        {
            var insertUser = await conectDB.addNewUser(user);
            return insertUser;
        }

        public async static Task<bool> updateMarker(string phone, double lat, double lng)
        {
            return await conectDB.UpdateMarker(phone, lat, lng);
        }

        public async static Task<List<UserProfile>> getAllUsersNotInGroup(string pass)
        {
            var group = await conectDB.getUserOfGroup(pass);
            var all = await conectDB.getAllUsers();
            var managment = await conectDB.getManagmentOfGroup(pass);
            List<UserProfile> notInGroup = new List<UserProfile>();
            foreach (var item in all)
            {
                UserProfile user = await conectDB.getUser(item.Phone);
                if (group.Where(p => p.UserPhoneGroup == user.Phone).FirstOrDefault() == null && managment.Where(p => p.PhoneManagment == user.Phone).FirstOrDefault() == null)
                    notInGroup.Add(item);
            }
            return notInGroup;
        }

        public async static Task<List<Group>> checkOpenGroupAndConfirm(string phone)
        {
            var d = 0;
            List<Group> groups = await GroupS.getAllGroupUseUsewr(phone);//כל הקבוצות שהמשתמש רשום עליהם
            List<Group> send = new List<Group>();
            foreach (var item in groups)
            {
                if (item.Status == true && item.DateBeginTrip <= DateTime.Now && item.DateEndTrip >= DateTime.Now)
                {
                    foreach (var item1 in item.OkUsers)
                    {
                        UserProfile user = await conectDB.getUser(item1.UserPhoneGroup);
                        if (user.Phone == phone)
                        {
                            d = 1;
                        }
                    }

                    if (d == 0)
                        send.Add(item);

                }
            }
            return send;
        }

        //public async static Task<List<Group>> getAllUsersInGroup(string pass)
        //{
        //    var userInGroup = await conectDB.getUserOfGroup(pass);
        //    return ;
        //}

        public async static Task<bool> AgreeToAddGroup(string pass, string phone)
        {

            try
            {
                UserProfile user = await conectDB.getUser(phone);
                Group g = await conectDB.getGroup(pass);
                if (g != null)
                {
                    UserInGroup users = new UserInGroup();
                    users.UserPhoneGroup = user.Phone;
                    g.Users.Add(users);
                    g.OkUsers.Add(users);
                    await conectDB.UpdateGroup(g);
                    //TODO:שמירה בדטה בייס
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async static Task<List<MessageUser>> getAllMessageUser(string phone)
        {
            try
            {
                UserProfile user = await conectDB.getUser(phone);
                var allMessage = new List<MessageUser>();
                foreach (var item in user.UserMessageNeedGet)
                {
                    allMessage.Add(item);
                } 
               bool b= await conectDB.RemoveMessage(user);
                if(b)
                return allMessage;
                return null;
            }
            catch (Exception)
            {

                throw new Exception("תקלה בקבלת האזהרות למטייל " + phone);
            }
        }


        public async static Task<bool> UpdateUserStatus(string phone)
        {
            var user = await conectDB.getUser(phone);
            return await conectDB.UpdateUser(user);
        }
    }
}
