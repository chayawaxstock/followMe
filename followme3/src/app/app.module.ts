import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule, IonicPageModule } from 'ionic-angular';
import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';
import { Geolocation } from '@ionic-native/geolocation';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { LoginPage } from '../pages/login/login';
import { RegisterPage } from '../pages/register/register';
import { UsersServiceProvider } from '../providers/users-service/users-service';
import { MapPage } from '../pages/map/map';
import { GroupPage } from '../pages/group/group';
import { HttpModule } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Camera } from '@ionic-native/camera';
import { GooglePlus } from '@ionic-native/google-plus';
import { IonicStorageModule } from '@ionic/storage';
import { Keyboard } from '@ionic-native/keyboard';
import { NativeStorage } from '@ionic-native/native-storage';
import { AddUserToGroupPage } from '../pages/add-user-to-group/add-user-to-group';
import { RadioButtonModule } from 'primeng/primeng';
import { ShowDitailGroupPage } from '../pages/show-ditail-group/show-ditail-group';
import { AngularFireAuthModule } from 'angularfire2/auth';
import { ComponentsModule } from '../components/components.module'
import { EnterPage } from '../pages/enter/enter';
import { MbscModule } from '@mobiscroll/angular-lite';
import { LoginGroupPage } from '../pages/login-group/login-group';
import { ShowDitailUserPage } from '../pages/show-ditail-user/show-ditail-user';
import { OpenPage } from '../pages/open/open';
import { AngularFireModule } from "angularfire2";
import { AngularFireDatabaseModule } from "angularfire2/database";

import { EnterGroupPage } from '../pages/enter-group/enter-group';
import {Sim} from '@ionic-native/sim'
import { LocalNotifications } from '@ionic-native/local-notifications';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HomeManagmentPage } from '../pages/home-managment/home-managment';
import{ AnimateItemSlidingDirective} from '../directives/animate-item-sliding/animate-item-sliding';
import { AddNewGroupsPage } from '../pages/add-new-groups/add-new-groups';
import { AddNewGroupsPageModule } from '../pages/add-new-groups/add-new-groups.module';


const firebaseConfig = {
  apiKey: "AIzaSyDjyxiKCMOWYfvhctnSDKjZUAMgvYDIZoY",
  authDomain: "myproject-be30d.firebaseapp.com",
  databaseURL: "https://myproject-be30d.firebaseio.com",
  projectId: "myproject-be30d",
  storageBucket: "myproject-be30d.appspot.com",
  messagingSenderId: "537848810771"
};

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    ListPage,RegisterPage,MapPage,GroupPage,AddUserToGroupPage,AddNewGroupsPage, AnimateItemSlidingDirective,
    ShowDitailGroupPage,EnterPage,LoginGroupPage,ShowDitailUserPage,OpenPage,EnterGroupPage,HomeManagmentPage
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    IonicModule.forRoot(MyApp),
    IonicStorageModule.forRoot(),
    HttpModule,
  //AccordionModule,
   // PanelModule,
    //ButtonModule,
    RadioButtonModule,
    AngularFireModule.initializeApp(firebaseConfig), // <-- firebase here
    AngularFireAuthModule,
    ComponentsModule, 
    MbscModule
    ,BrowserModule
    
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    ListPage,RegisterPage,MapPage,GroupPage,AddUserToGroupPage,LoginGroupPage,AddNewGroupsPage,
    ShowDitailGroupPage,EnterPage,ShowDitailUserPage,OpenPage,EnterGroupPage,HomeManagmentPage,

  ],
  providers: [
    StatusBar,
    LocalNotifications ,
    NativeStorage,
    SplashScreen,
    Camera,
    GooglePlus,
    IonicStorageModule,
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    UsersServiceProvider, Geolocation, HttpClient, Keyboard,Sim
  ]
})
export class AppModule { }
