using DAL;
using DAL.Models;
using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QualiAPI.Controllers
{
    public class UserController : ApiController
  { 
    public class help {
      public string  phone;
      public double   lat;
     public double lng;
    }
        /// <summary>
        /// עדכון מקום למשתמש
        /// </summary>
        /// <param name="mar">טלפון+מקום בנקודות</param>
        /// <returns></returns>
    [HttpPost]
    [EnableCors("*","*","*")]
    [Route("api/updateMarker")]
        public async Task< IHttpActionResult> UpdateMarker([FromBody] help mar)
        {
            try
            {
               bool b=await BL.User.updateMarker(mar.phone, mar.lat, mar.lng);
                return Ok(b);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// קבלת כל המשתמשים של קבוצה מסוימת
        /// </summary>
        /// <param name="pass">סיסמת קבוצה</param>
        /// <returns></returns>
    [HttpGet]
    [EnableCors("*", "*", "*")]
    [Route("api/getAllUsersNotInGroup/{pass}")]
    public async Task< IHttpActionResult> getAllUsersNotInGroup([FromUri]string pass)
    {
      try
      {
      var users= await BL.User.getAllUsersNotInGroup(pass);
        return Ok(users);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.BadRequest, ex.Message);
      }
    }

        [HttpGet]
        [EnableCors("*", "*", "*")]
        [Route("api/getUserInf/{phone}")]
        public async Task<IHttpActionResult> getUserInf([FromUri]string phone)
        {
            try
            {
                var user = await conectDB.getUser(phone);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //[HttpGet]
        //[EnableCors("*", "*", "*")]
        //[Route("api/getAllUsersInGroup/{pass}")]
        //public async Task<IHttpActionResult> getAllUsersInGroup([FromUri]string pass)
        //{
        //    try
        //    {
        //        var users = await BL.User.getAllUsersInGroup(pass);
        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
        /// <summary>
        /// בדיקת קבוצה
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
    [EnableCors("*", "*", "*")]
    [Route("api/checkOpenGroupAndConfirm/{phone}")]
    public IHttpActionResult checkOpenGroupAndConfirm([FromUri]string phone)
    {
      try
      {
        var groupConfirm = BL.User.checkOpenGroupAndConfirm(phone);
        return Ok(groupConfirm);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.BadRequest, ex.Message);
      }
    }

/// <summary>
/// check if user far from all managment that activity
/// </summary>
/// <param name="phone">פלאפון של המטייל</param>
/// <returns>מחזיר רשימה של כל הקבוצות שהמטייל התרחק מהמנהלים של קבוצה זו</returns>
    [HttpGet]
        [EnableCors("*", "*", "*")]
        [Route("api/CheckDistance/{phone}")]
    public async Task<IHttpActionResult> CheckDistance([FromUri] string phone)
    {
      try
      {

        List<Group> far = await BL.GroupS.getGroupDangerous(phone);
        return Ok(far);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.BadRequest, ex.Message);
      }
    }


        [HttpGet]
        [Route("api/CheckIfHaveMessage/{phone}")]
        public async Task<IHttpActionResult> CheckIfHaveMessage([FromUri] string phone)
        {
            try
            {

                List<MessageUser> messages = await BL.User.getAllMessageUser(phone);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpGet]
    [EnableCors("*","*","*")]
    [Route("api/AgreeToAddGroup/{pass}/{phone}")]
    public async Task<IHttpActionResult> AgreeToAddGroup([FromUri] string pass,[FromUri] string phone)
    {
      try
      {

       bool b= await BL.User.AgreeToAddGroup(pass, phone);
        if (b == false)
          throw new Exception("כשלון בעדכון האישור");
        return Ok(b);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.BadRequest, ex.Message);
      }
    }


        [HttpPost]
        [EnableCors("*", "*", "*")]
        [Route("api/updateStatusUser")]
        public async Task<IHttpActionResult> updateStatusUser([FromUri] string phone)
        {
            try
            {
                bool b = await BL.User.UpdateUserStatus(phone);
                return Ok(b);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}
