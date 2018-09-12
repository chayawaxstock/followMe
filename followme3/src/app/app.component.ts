import { Component, ViewChild, NgZone } from '@angular/core';
import { Nav, Platform, LoadingController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';
import { LoginPage } from '../pages/login/login';
import { RegisterPage } from '../pages/register/register';
import { MapPage } from '../pages/map/map';
import { GroupPage } from '../pages/group/group';
import { GooglePlus } from '@ionic-native/google-plus';
import { ShowDitailGroupPage } from '../pages/show-ditail-group/show-ditail-group';
import { UsersServiceProvider, group, marker } from '../providers/users-service/users-service';
import { NativeStorage } from '@ionic-native/native-storage';
import { AddUserToGroupPage } from '../pages/add-user-to-group/add-user-to-group';
import { OpenPage } from '../pages/open/open';
import { ShowDitailUserPage } from '../pages/show-ditail-user/show-ditail-user';
import { LoginGroupPage } from '../pages/login-group/login-group';
import { EnterPage } from '../pages/enter/enter';
import { Storage } from '@ionic/storage';
import { EnterGroupPage } from '../pages/enter-group/enter-group';
import { AddNewGroupsPage } from '../pages/add-new-groups/add-new-groups';
import { Geolocation } from '@ionic-native/geolocation';
import { User } from '../../node_modules/firebase';
import { Keyboard } from '@ionic-native/keyboard';

export interface MenuItem {
  title: string;
  component: any;
  icon: string;
}


@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  loading: any;
  cart: any;

  @ViewChild(Nav) nav: Nav;

  user: User;
  rootPage: any = HomePage;
  groupNow: group;
  pages: Array<MenuItem>;
  allGroup: group[];

  constructor(public platform: Platform,
    public statusBar: StatusBar,
    private geolocation: Geolocation,
    public splashScreen: SplashScreen,
    public googlePlus: GooglePlus,
    public zone: NgZone,
    private storage: Storage,
    private userService: UsersServiceProvider,
    private nativeStorage: NativeStorage,
    private loader: LoadingController,
    public keyboard: Keyboard) {
    this.showLoader();
    this.checkStorage();
    this.initializeApp();

    
    // used for  ngFor and navigation

    this.pages = [
      { title: 'דף הבית', component: HomePage, icon: 'home'},
      { title: 'קבוצות', component: GroupPage ,icon: 'person'},
      { title: 'הוסף קבוצה חדשה', component: AddNewGroupsPage ,icon: 'person-add'},
      { title: 'הוספת מטיילים לקבוצה', component: AddUserToGroupPage,icon: 'add-circle' },
      { title: 'מפה', component: MapPage,icon: 'map' },
      { title: 'הגדרות קבוצה', component: ShowDitailGroupPage,icon: 'settings' },
      { title: 'הגדרות משתמש', component: ShowDitailUserPage,icon: 'settings' }

    ];

  }
  ngOnInit() {
   
  }

  showLoader() {
    this.loading = this.loader.create({
      content: '...המתן'
    });
    this.loading.present();
  }

  initializeApp() {
   

    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      // this.platform.setDir();
      this.statusBar.styleDefault();
      this.statusBar.overlaysWebView(true);
      //this.splashScreen.hide();
      this.zone.run(() => {
      }); 
      this.keyboard.show();
      this.keyboard.disableScroll(false);
    });
  }

  openPage(page) {
    this.nav.setRoot(page.component);
  }

  // addToGroup() {
  //   this.nav.push(EnterGroupPage);
  //   this.nav.setRoot(EnterGroupPage);
  // }
  marker: marker;
  getCurrectLocation() {
    setInterval(() => {
      this.geolocation.getCurrentPosition().then((resp) => {
        this.marker = new marker();
        this.marker.lat = resp.coords.latitude;
        this.marker.lng = resp.coords.longitude;
        this.userService.updateMarker(this.userService.getPhoneUser(), this.marker).then(p => {
          console.log("ok");

        }).catch(error =>
          console.log(error));
      },err=>{console.log("error update location" )}).catch((error) => {
        console.log('Error getting location', error);
      });
      this.userService.CheckDistance().then(p => { console.log(p+" CheckDistance") },err=>{console.log(err)}).catch(error=>{console.log(error)});
      this.userService.getMyMessage().then(mes=>{
          console.log(mes+" getMyMessage");
      },err=>console.log(err)).catch(err=>{"לא היתה אפשרות לקבלת ההדעות שנשלחו למשתמש"})
    }, 60000);
  
    // let watch = this.geolocation.watchPosition();
    // watch.subscribe((data) => {
    //   this.marker = new marker();
    //   this.marker.lat = data.coords.latitude;
    //   this.marker.lng = data.coords.longitude;
    //   this.userService.updateMarker(this.userService.getPhoneUser(), this.marker).then(p=>{},err=>{}).catch(err=>{});
    // },err=>{console.log(err)});

  }


  checkStorage() {

    if (this.platform.is("cordova")) {
      this.nativeStorage.getItem('myPhone')
        .then(
          data => {
            this.userService.setPhoneUser(data);
            this.getCurrectLocation();
            this.checkCountGroup();
          },
          error => {
            this.loading.dismiss();
            this.nav.push(EnterPage);
            this.nav.setRoot(EnterPage);
          }
        );
    }
    else {
     
      this.storage.get("myPhone").then(p => {
       
        this.cart = p
        if (this.cart != undefined) {
          this.userService.setPhoneUser(this.cart);
          this.getCurrectLocation();
          this.checkCountGroup();
        }
        else {
          this.loading.dismiss();
          this.nav.push(EnterPage);
          this.nav.setRoot(EnterPage)
        }
      });
    }

  }

  checkCountGroup() {

    this.userService.getGroups(this.userService.getPhoneUser()).then(data => {
      this.loading.dismiss();
      this.allGroup = data;

      if (this.allGroup.length > 1) {
        this.nav.setRoot(HomePage);
        this.nav.push(GroupPage);

      }
      else if (this.allGroup.length == 1) {
        this.userService.setGroup(this.allGroup[0]);
        this.nav.push(HomePage, { gr: this.allGroup[0] });
        this.nav.setRoot(HomePage, { gr: this.allGroup[0] })
      }
      else {
        this.loading.dismiss();
        this.nav.push(HomePage);
        this.nav.setRoot(HomePage);
      }
    }, (eror) => {alert("שגיאה בקבלת הקבוצות שהמשתמש רשום עליהם");
      this.loading.dismiss();})
  }
}
