using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using RestSharp;
using QualiAPI.Properties;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using DAL;
using BL;

namespace QualiAPI.Controllers
{
  public class RegisterController : ApiController
  {
    [HttpGet]
        [Route("api/Register")]
        public async Task<IHttpActionResult> register()
        {


            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("followMe");
            var userCollection = database.GetCollection<UserProfile>("users");


            List<UserProfile> users = new List<UserProfile>()
            {
                new UserProfile(){email="c0556777462@gmail.com",firstName="חיה",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="וקסשטוק",marker=new Marker(){lat=32,lng=34,name="חיה וקסשטוק 0556777462"},phone="0556777462",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="zwakshtok@gmail.com",firstName="זהבה",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="וקסשטוק",marker=new Marker(){lat=36,lng=37,name="זהבה וקסשטוק 0548455899"},phone="0548455899",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="ri775969@gmail.com",firstName="רבקי",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="וקסשטוק",marker=new Marker(){lat=37,lng=37,name="רבקי וקסשטוק 0556775969"},phone="0556775969",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="7680287@gmail.com",firstName="יעקב",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="ישראלי",marker=new Marker(){lat=38,lng=34,name="יעקב ישראלי 0527680287"},phone="0527680287",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="נחמה",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms,lastName="חפץ",marker=new Marker(){lat=32,lng=34.45,name="נחמה חפץ 0527680286"},phone="0527680286",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="אברהם",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.whatsApp,lastName="חן",marker=new Marker(){lat=32.44545,lng=34.2323,name="אברהם חן 0548478785"},phone="0548478785",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="שרה",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="בן חמו",marker=new Marker(){lat=32.44545,lng=34,name="שרה בן חמו 0504187965"},phone="0504187965",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="טובה",Image="",kindMessage=DAL.Models.eKindMessage.email,lastName="כהן",marker=new Marker(){lat=33,lng=35.09,name="טובה כהן 0527851111"},phone="0527851111",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="אנה",Image="",kindMessage=DAL.Models.eKindMessage.email|DAL.Models.eKindMessage.whatsApp,lastName="בן שלום",marker=new Marker(){lat=32.01,lng=34.01,name="אנה בן שלום 0508899245"},phone="0508899245",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){email="c0556777462@gmail.com",firstName="טל",Image="",kindMessage=DAL.Models.eKindMessage.sms|DAL.Models.eKindMessage.whatsApp,lastName="יברוב",marker=new Marker(){lat=32.12,lng=34.12,name="טל יברוב 05578121212"},phone="05578121212",status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},

            };

            List<Group> groups = new List<Group>()
            {
                new Group(){DateBeginTrip=new DateTime(2018,08,10),DateEndTrip=new DateTime(2018,09,02,8,0,0),definitionGroup=new DefinitionGroup(){distance=500,eWhenStatusOpen=DAL.Models.WhenStatusOpen.onOpen,googleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },description="טיול מרום האלה שוויץ",ErrorMessage=conectDB.messagesToGroup,Kod="1212",listManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0504187965" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="05578121212" } },name="מרום האלה",password="As123434",status=true,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0527680287" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0556775969" } },users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0556777462" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0527680287" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0556775969" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,20),DateEndTrip=new DateTime(2018,09,22,0,0,0),definitionGroup=new DefinitionGroup(){distance=500,eWhenStatusOpen=DAL.Models.WhenStatusOpen.onOpen,googleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },description="טיול חיים כיתה א",ErrorMessage=conectDB.messagesToGroup,Kod="2323",listManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="05578121212" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0508899245" } },name="טיול יוסי גרין",password="XZxz1278",status=true,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0527680286" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0527680287" } },users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0508899245" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0527680286" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0527680287" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,26),DateEndTrip=new DateTime(2018,09,12,12,0,0),definitionGroup=new DefinitionGroup(){distance=1000,eWhenStatusOpen=DAL.Models.WhenStatusOpen.onDateBegin,googleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },description="טיול כיתה ט וולף",ErrorMessage=conectDB.messagesToGroup,Kod="3567",listManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0508899245" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0527680286" } },name=" כיתה ט וולף",password="RTrt2585",status=false,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="05578121212" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0527851111" } },users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0527851111" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = false }, UserPhoneGroup = "05578121212" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0548478785" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0504187965" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,24),DateEndTrip=new DateTime(2018,09,09,22,0,0),definitionGroup=new DefinitionGroup(){distance=450,eWhenStatusOpen=DAL.Models.WhenStatusOpen.onDateBegin,googleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },description="טיול כיתה ב זכרון מאיר",ErrorMessage=conectDB.messagesToGroup,Kod="7352",listManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0504187965" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,phoneManagment="0548478785" } },name="זכרון מאיר",password="WQ123456",status=false,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0548455899" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){SeeMeAll=true },UserPhoneGroup="0508899245" } },users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0508899245" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "0527851111" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { SeeMeAll = true }, UserPhoneGroup = "05578121212" } } } };
            foreach (var item in users)
            {

                item.id = ObjectId.GenerateNewId();
                await userCollection.InsertOneAsync(item);
            }
            return Ok();

    }



            //[HttpGet]
            //[Route("api/Register")]
            //public IHttpActionResult Registere()
            //{
            //    try
            //    {
            //        UserProfile registerUser = new UserProfile() { lastName = "fsdfsd", phone = "12121212", firstName = "sdsfdf" };
            //        var client = new MongoClient("mongodb://localhost:27017");

            //        MongoDatabase database = server.GetDatabase("followMe");
            //        MongoCollection userCollection = database.GetCollection("users");
            //        List<UserProfile> query = userCollection.AsQueryable<UserProfile>().ToList();
            //        var x = query.FirstOrDefault(sb => sb.phone.Equals(registerUser.phone));
            //        if (x == null)
            //        {
            //            try
            //            {
            //                userCollection.Insert(registerUser);
            //                return Ok(registerUser.lastName + " " + registerUser.firstName);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Error :" + ex.Message);

            //            }
            //        }
            //        else
            //        {
            //            return Content(HttpStatusCode.OK, "user exists");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Failed to query from collection");
            //        Console.WriteLine("Exception :" + ex.Message);
            //        return Content(HttpStatusCode.NotFound, true);

            //    }
            // return Ok("dsfsdfsd");

            //}

            //public void Options() { }




            /// <summary>
            /// כניסה ראשונית למערכת
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
        [HttpPost]
        [Route("api/register")]
        public async Task<IHttpActionResult> registerUser([FromBody]UserProfile user)
        {
            try
            {
               bool b= await BL.User.RegisterUser(user);
                if(b==true)
                  return Ok("true");
                else return Content(HttpStatusCode.BadRequest, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("נכשל בהוספת המשתמש");
                Console.WriteLine("שגיאה :" + ex.Message);
                return Content(HttpStatusCode.BadRequest, true);

            }
        }

        /// <summary>
        /// כניסת משתמש  
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/login/{phone}")]
        public IHttpActionResult loginUser([FromUri]string phone)
        {
            try
            {
              var req=BL.User.LoginUser(phone);
                if(req!=null)
                {
                    bool b = true;
                  return Ok(b);}
                return Content(HttpStatusCode.NotFound, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("הכניסה נכשלה");
                Console.WriteLine("שגיאה :" + ex.Message);
                return Content(HttpStatusCode.BadRequest, true);

            }
        }
    }
}
