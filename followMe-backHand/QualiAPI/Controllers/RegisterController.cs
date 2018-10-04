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

            //  var client = new MongoClient("mongodb://chayawaxstock:chaya207322868!@cluster0-shard-00-00-ptwok.mongodb.net:27017,cluster0-shard-00-01-ptwok.mongodb.net:27017,cluster0-shard-00-02-ptwok.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
            var database = client.GetDatabase("followMe");
            var userCollection = database.GetCollection<UserProfile>("users");


            List<UserProfile> users = new List<UserProfile>()
            {
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="חיה",Image="",LastName="וקסשטוק",Marker=new Marker(){Lat=32,Lng=34,NameAndPhone="חיה וקסשטוק 0556777462"},Phone="0556777462",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="zwakshtok@gmail.com",FirstName="זהבה",Image="",LastName="וקסשטוק",Marker=new Marker(){Lat=36,Lng=37,NameAndPhone="זהבה וקסשטוק 0548455899"},Phone="0548455899",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="ri775969@gmail.com",FirstName="רבקי",Image="",LastName="וקסשטוק",Marker=new Marker(){Lat=37,Lng=37,NameAndPhone="רבקי וקסשטוק 0556775969"},Phone="0556775969",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="7680287@gmail.com",FirstName="יעקב",Image="",LastName="ישראלי",Marker=new Marker(){Lat=38,Lng=34,NameAndPhone="יעקב ישראלי 0527680287"},Phone="0527680287",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="נחמה",Image="",LastName="חפץ",Marker=new Marker(){Lat=32,Lng=34.45,NameAndPhone="נחמה חפץ 0527680286"},Phone="0527680286",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="אברהם",Image="",LastName="חן",Marker=new Marker(){Lat=32.44545,Lng=34.2323,NameAndPhone="אברהם חן 0548478785"},Phone="0548478785",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="שרה",Image="",LastName="בן חמו",Marker=new Marker(){Lat=32.44545,Lng=34,NameAndPhone="שרה בן חמו 0504187965"},Phone="0504187965",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="טובה",Image="",LastName="כהן",Marker=new Marker(){Lat=33,Lng=35.09,NameAndPhone="טובה כהן 0527851111"},Phone="0527851111",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="אנה",Image="",LastName="בן שלום",Marker=new Marker(){Lat=32.01,Lng=34.01,NameAndPhone="אנה בן שלום 0508899245"},Phone="0508899245",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},
                new UserProfile(){Email="c0556777462@gmail.com",FirstName="טל",Image="",LastName="יברוב",Marker=new Marker(){Lat=32.12,Lng=34.12,NameAndPhone="טל יברוב 05578121212"},Phone="05578121212",Status=true,UserMessageNeedGet=new List<DAL.Models.MessageUser>()},

            };

            List<Group> groups = new List<Group>()
            {
                new Group(){DateBeginTrip=new DateTime(2018,08,10),DateEndTrip=new DateTime(2018,09,02,8,0,0),DefinitionGroup=new DefinitionGroup(){Distance=500,eWhenStatusOpen=DAL.Models.WhenStatusOpen.ONOPEN,GoogleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },Description="טיול מרום האלה שוויץ",ErrorMessage=conectDB.messagesToGroup,Code="1212",ListManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0504187965" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="05578121212" } },Name="מרום האלה",Password="As123434",Status=true,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0527680287" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0556775969" } },Users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0556777462" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0527680287" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0556775969" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,20),DateEndTrip=new DateTime(2018,09,22,0,0,0),DefinitionGroup=new DefinitionGroup(){Distance=500,eWhenStatusOpen=DAL.Models.WhenStatusOpen.ONOPEN,GoogleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },Description="טיול חיים כיתה א",ErrorMessage=conectDB.messagesToGroup,Code="2323",ListManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="05578121212" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0508899245" } },Name="טיול יוסי גרין",Password="XZxz1278",Status=true,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0527680286" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0527680287" } },Users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0508899245" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0527680286" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0527680287" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,26),DateEndTrip=new DateTime(2018,09,12,12,0,0),DefinitionGroup=new DefinitionGroup(){Distance=1000,eWhenStatusOpen=DAL.Models.WhenStatusOpen.ONDATEBEGIN,GoogleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },Description="טיול כיתה ט וולף",ErrorMessage=conectDB.messagesToGroup,Code="3567",ListManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0508899245" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0527680286" } },Name=" כיתה ט וולף",Password="RTrt2585",Status=false,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="05578121212" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0527851111" } },Users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0527851111" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = false }, UserPhoneGroup = "05578121212" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0548478785" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0504187965" } } }
            ,
                new Group(){DateBeginTrip=new DateTime(2018,08,24),DateEndTrip=new DateTime(2018,09,09,22,0,0),DefinitionGroup=new DefinitionGroup(){Distance=450,eWhenStatusOpen=DAL.Models.WhenStatusOpen.ONDATEBEGIN,GoogleStatus=new DAL.Models.GoogleStatus(){ Code=1,Status="walking"} },Description="טיול כיתה ב זכרון מאיר",ErrorMessage=conectDB.messagesToGroup,Code="7352",ListManagment=new List<DAL.Models.ManagmentInGroup>(){
                new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0504187965" },new DAL.Models.ManagmentInGroup(){ComeToTrip=true,PhoneManagment="0548478785" } },Name="זכרון מאיר",Password="WQ123456",Status=false,OkUsers=new List<DAL.Models.UserInGroup>(){
                new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0548455899" },new DAL.Models.UserInGroup(){Definition=new DefinitionUser(){IsSeeMeAll=true },UserPhoneGroup="0508899245" } },Users=new List<DAL.Models.UserInGroup>(){ new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0508899245" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = false }, UserPhoneGroup = "0548455899" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "0527851111" }, new DAL.Models.UserInGroup() { Definition = new DefinitionUser() { IsSeeMeAll = true }, UserPhoneGroup = "05578121212" } } } };
            foreach (var item in users)
            {

                item.Id = ObjectId.GenerateNewId();
                try
                {
                       await userCollection.InsertOneAsync(item);
                }
                catch (Exception e)
                {

                    throw;
                }
                
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
