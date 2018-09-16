import { Component, ViewChild, ElementRef, NgZone } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController, AlertController } from 'ionic-angular';
import { Geolocation } from '@ionic-native/geolocation';
import { marker, UsersServiceProvider, group, User, MessageUser, MessageGroup } from '../../providers/users-service/users-service';
import { Observable } from 'Rxjs/rx';
import { Subscription } from "rxjs/Subscription";
import { google } from "google-maps";
import 'rxjs/add/operator/map';
import { LoginGroupPage } from '../login-group/login-group';
import { GroupPage } from '../group/group';
import { HomePage } from '../home/home';
import { ShowDitailUserPage } from '../show-ditail-user/show-ditail-user';
import { Message } from '../../../node_modules/@angular/compiler/src/i18n/i18n_ast';
declare var google;
/**
 * Generated class for the MapPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-map',
  templateUrl: 'map.html',
})

export class MapPage {



  public latitude: number;
  public longitude: number;
  mar: marker[];

  public zoom: number;
  @ViewChild('map') mapElement: ElementRef;
  map: any;
  markers = [];
  timeUpload:number=0;
  group: group;
  loading: any;
  constructor(public navCtrl: NavController,
              public navParams: NavParams, 
              private geolocation: Geolocation,
              private userService: UsersServiceProvider, 
              public loadingCtrl: LoadingController,
              private _ngZone: NgZone,
              private alertCtrl: AlertController) {
      this.group = this.userService.getGroup();
      if (this.group == null || this.group == undefined)
      {
        alert("לא נבחרה קבוצה") ;
        //TODO:לעשות רשימת הקבוצות ובחירה חוזר למפה של הקבוצה בדיקת מנהל או מטייל
              this.navCtrl.push(HomePage);
      }
      
  }

  showLoader() {

    this.loading = this.loadingCtrl.create({
      content: '...המתן'
    });

    this.loading.present();

  }

  myAddMarker=()=> {



    var iconUser = '../../assets/imgs/trip1.png';
    var iconManagment= "../../assets/imgs/managmentIcon.png";
   
     
    this.userService.getMarkerManagments(this.group).then(res => {
      this.deleteMarkers();
     let markers = res;
     markers.forEach(element => {
      var icon = {
    url: iconManagment, // url
    scaledSize: new google.maps.Size(30, 30), // scaled size
    origin: new google.maps.Point(0,0), // origin
    anchor: new google.maps.Point(0, 0) // anchor
};
         var myCenter: any = new google.maps.LatLng(element.lat, element.lng);
         var marker = new google.maps.Marker({ position: myCenter ,icon:icon});
         marker.setMap(this.map);
         this.markers.push(marker);
         google.maps.event.addListener(marker, 'click',  () => {
          let infor=element.name.substring(0, element.name.length - 11) +'מנהל טיול'+ '<input id="open" type="button" value="פרטי מטייל מורחבים:" onclick="javascript:dbeuger"/> <button id="sendMessage" onclick="javascript:dbeuger">שליחת הודעה</button>';
          if (element.name.substring(element.name.length - 10) == this.userService.getPhoneUser()) 
               infor="אני <p id='open'><p/><p id='sendMessage'><p/>";
           var infowindow = new google.maps.InfoWindow({
             content: infor
           });

           infowindow.open(this.map, marker);
           google.maps.event.addListenerOnce(infowindow, 'domready', () => {
             document.getElementById('open').addEventListener('click', () => {
               this.navCtrl.push(ShowDitailUserPage);
             });
             document.getElementById('sendMessage').addEventListener('click', () => {
              this.navCtrl.push(ShowDitailUserPage);
            });
           });

           
         });
       
     });

     this.userService.getMarkerUsers(this.group).then(res => {
      let markers = res;
      markers.forEach(element => {
        var icon = {
          url: iconUser, // url
          scaledSize: new google.maps.Size(30, 30), // scaled size
          origin: new google.maps.Point(0,0), // origin
          anchor: new google.maps.Point(0, 0) // anchor
      };
          var myCenter: any = new google.maps.LatLng(element.lat, element.lng);
          var marker = new google.maps.Marker({ position: myCenter ,icon:icon});
          marker.setMap(this.map);
          this.markers.push(marker);
          google.maps.event.addListener(marker, 'click',  () => {
            let infor=element.name.substring(0, element.name.length - 11) + '<input id="open" type="button" value="פרטי מטייל מורחבים:" onclick="javascript:dbeuger"/> <button id="sendMessage" onclick="javascript:dbeuger">שליחת הודעה</button>';
          if (element.name.substring(element.name.length - 10) == this.userService.getPhoneUser()) 
             infor="אני <p id='open'><p/><p id='sendMessage'><p/>";
           var infowindow = new google.maps.InfoWindow({
             content: infor
           });

            infowindow.open(this.map, marker);
            google.maps.event.addListenerOnce(infowindow, 'domready', () => {
              document.getElementById('open').addEventListener('click', () => {
                this.navCtrl.push(ShowDitailUserPage);
              });

              document.getElementById('sendMessage').addEventListener('click', () => {
                let message:MessageUser;
                this.sendMessage(element.name)
              });
            });
          });
        
      });
    }, err => {
      this.loading.dismiss();
      alert(err);
      console.log(err)
    }
    );




   }, err => {
     this.loading.dismiss();
     alert(err);
     console.log(err)
   }
   );
if(this.timeUpload==0)
{
  this.loading.dismiss();
  this.timeUpload++;
   } 
  }

  mapInterval()
  {
     setInterval(this.myAddMarker, 20000);
  }


  sendMessage(user:string)
  {
    let message:MessageUser=new MessageUser();
    message.Group=this.userService.getGroup();
    message.UserName=user;
    message.Message=new MessageGroup();
    message.Message.KodError=9;
    message.Message.MessageError="";
   
    let alert = this.alertCtrl.create({
      title: ' שליחת הודעה ל'+user.substring(0, user.length - 11),
      inputs: [
        {
          name: 'textMassage',
          placeholder: 'תוכן ההודעה',
          type:'text'
        },
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: data => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'שלח הודעה',
          handler: data => {
            console.log(data);
            message.Message.MessageError=data;
           this.userService.sendMessgeComplex(message).subscribe(p=>{
             console.log("ok");
           },err=>{console.log(err)})
          }
        }
      ]
    });
    alert.present();
  }


  clearAllMarker() {

  }

  

  initMap() {
    this.geolocation.getCurrentPosition({ maximumAge: 3600, timeout: 5000, enableHighAccuracy: true }).then((resp) => {
      let mylocation = new google.maps.LatLng(resp.coords.latitude, resp.coords.longitude);
      this.map = new google.maps.Map(this.mapElement.nativeElement, {
        zoom: 16,
        center: mylocation
      });
      this.mapInterval();
    });
  }



  ionViewDidLoad() {
    this.group = this.userService.getGroup();
    if (this.group == null || this.group == undefined)
      this.group = this.userService.getGroupManagment();
    
    if ((this.userService.getGroup() == null || this.userService.getGroup() == undefined) && (this.userService.getGroupManagment() == null || this.userService.getGroupManagment() == undefined)) {
      this.navCtrl.setRoot(HomePage);
      this.navCtrl.push(GroupPage);
    }
    this.showLoader();
    this.initMap();

  }



  setMapOnAll() {
    for (var i = 0; i < this.markers.length; i++) {
      this.markers[i].setMap(null);
    }
  }


  deleteMarkers() {
    this.setMapOnAll();
    this.markers = [];
  }

  init() {
    this.map = new google.maps.Map(document.getElementById('map'), {
      zoom: 13,
      center: new google.maps.LatLng(41.976816, -87.659916),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new google.maps.InfoWindow({});

    var marker, i = -1;
    this.userService.getMarkerUsers(this.group).then(res => {
      this.loading.dismiss();
      let markers = res;
      markers.forEach(element => {
        i++;
        marker = new google.maps.Marker({
          position: new google.maps.LatLng(element.lat, element.lng),
          map: this.map
        });
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
          return function () {
            infowindow.setContent(element.name);
            infowindow.open(this.map, marker);
          }
        })(marker, i));
        this.markers.push(marker);
      });
    }, err => { console.log(err) }
    );
  }

}



