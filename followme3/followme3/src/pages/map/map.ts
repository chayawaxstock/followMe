import { Component, ViewChild, ElementRef, NgZone } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { Geolocation } from '@ionic-native/geolocation';
import { marker, UsersServiceProvider, group } from '../../providers/users-service/users-service';
import { Observable } from 'Rxjs/rx';
import { Subscription } from "rxjs/Subscription";
import { google } from "google-maps";
import 'rxjs/add/operator/map';
import { LoginGroupPage } from '../login-group/login-group';
import { GroupPage } from '../group/group';
import { HomePage } from '../home/home';
import { ShowDitailUserPage } from '../show-ditail-user/show-ditail-user';
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

  group: group;
  loading: any;
  constructor(public navCtrl: NavController,
              public navParams: NavParams, 
              private geolocation: Geolocation,
              private userService: UsersServiceProvider, 
              public loadingCtrl: LoadingController,
              private _ngZone: NgZone) {
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

    var iconBase = '../../assets/imgs/trip1.png';
    this.userService.getMarkerManagments(this.group).then(res => {
      
      this.deleteMarkers();
      
     let markers = res;
     markers.forEach(element => {
       if (element.name.substring(element.name.length - 10) != this.userService.getPhoneUser()) {
         var myCenter: any = new google.maps.LatLng(element.lat, element.lng);
         var marker = new google.maps.Marker({ position: myCenter,icon:iconBase });
         marker.setMap(this.map);
         this.markers.push(marker);
         google.maps.event.addListener(marker, 'click',  () => {
           var infowindow = new google.maps.InfoWindow({
             content: element.name.substring(0, element.name.length - 11) +'מנהל טיול'+ '<input id="aaasss" type="button" value="פרטי מטייל מורחבים:" onclick="javascript:dbeuger"/>'
           });

           infowindow.open(this.map, marker);
           google.maps.event.addListenerOnce(infowindow, 'domready', () => {
             document.getElementById('aaasss').addEventListener('click', () => {

        
               this.navCtrl.push(ShowDitailUserPage);
             });
           });
         });
       }
     });

     this.userService.getMarkerUsers(this.group).then(res => {
      let markers = res;
      markers.forEach(element => {
        if (element.name.substring(element.name.length - 10) != this.userService.getPhoneUser()) {
          var myCenter: any = new google.maps.LatLng(element.lat, element.lng);
          var marker = new google.maps.Marker({ position: myCenter });
          marker.setMap(this.map);
          this.markers.push(marker);
          google.maps.event.addListener(marker, 'click',  () => {
            var infowindow = new google.maps.InfoWindow({
              content: element.name.substring(0, element.name.length - 11) + '<input id="aaasss" type="button" value="פרטי מטייל מורחבים:" onclick="javascript:dbeuger"/>'
            });

            infowindow.open(this.map, marker);
            google.maps.event.addListenerOnce(infowindow, 'domready', () => {
              document.getElementById('aaasss').addEventListener('click', () => {

         
                this.navCtrl.push(ShowDitailUserPage);
              });
            });
          });
        }
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


    
  }

  mapmap()
  {
     setInterval(this.myAddMarker, 5000);
  }


  clearAllMarker() {

  }

  

  initMap() {
    this.geolocation.getCurrentPosition({ maximumAge: 3600, timeout: 5000, enableHighAccuracy: true }).then((resp) => {
      let mylocation = new google.maps.LatLng(resp.coords.latitude, resp.coords.longitude);
      this.map = new google.maps.Map(this.mapElement.nativeElement, {
        zoom: 14,
        center: mylocation
      });
      this.addMarker(mylocation);

      this.mapmap();
    });


    let watch = this.geolocation.watchPosition();
    watch.subscribe((data) => {
      let updatelocation = new google.maps.LatLng(data.coords.latitude, data.coords.longitude);
      this.addMarker(updatelocation);
    }, err => console.log(err));

  }



  ionViewDidLoad() {
    this.group = this.userService.getGroup();
    if (this.group == null || this.group == undefined)
      this.group = this.userService.getGroupManagment();
    
    if ((this.userService.getGroup() == null || this.userService.getGroup() == undefined) && (this.userService.getGroupManagment() == null || this.userService.getGroupManagment() == undefined)) {
      this.navCtrl.setRoot(HomePage);
      this.navCtrl.push(GroupPage);
    }
   // this.showLoader();
    this.initMap();

  }

  addMarker(location) {

    var myCenter: any = location;
    var marker = new google.maps.Marker({ animation: google.maps.Animation.DROP, position: location });
    marker.setMap(this.map);
    google.maps.event.addListener(marker, 'click', function () {
      var infowindow = new google.maps.InfoWindow({
        content: "אני"
      });
      infowindow.open(this.map, marker);
    });
    this.markers.push(marker);
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


