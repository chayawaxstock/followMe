import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { group, UsersServiceProvider, User, GoogleStatus } from '../../providers/users-service/users-service';
import { Geolocation } from '@ionic-native/geolocation';
import { AddUserToGroupPage } from '../add-user-to-group/add-user-to-group';
import { HomePage } from '../home/home';
import { FormGroup, FormBuilder, FormControl, Validators } from '../../../node_modules/@angular/forms';
declare var google: any;
/**
 * Generated class for the ShowDitailGroupPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-show-ditail-group',
  templateUrl: 'show-ditail-group.html',
})
export class ShowDitailGroupPage {

  
  whenOpen:any;
  googleStatus:any;
  status:boolean;
  group:group;
  user:User[];
  open: string[];
  google_statuses: string[];
  nameGroup: string;
  constructor(private toastCtrl: ToastController,
    public formBuilder: FormBuilder,public navCtrl: NavController, public navParams: NavParams,private geolocation: Geolocation,public userService:UsersServiceProvider) {
      this.group=this.userService.getGroup();
    this.open = [
      "אוטמטי",
      "ידני"
    ];

    this.google_statuses = [
      "הליכה",
      "נסיעה ברכב",
      "רכיבה על אופניים"
    ];
  }
  saveChangeDitailsGroup()
  {
     this.group.status=this.status;//open close
     this.group.definitionGroup.eWhenStatusOpen=this.whenOpen;//when open
     this.group.definitionGroup.googleStatus=new GoogleStatus();
     this.group.definitionGroup.googleStatus.code=this.googleStatus;//kind
     this.group.definitionGroup.googleStatus.status=this.google_statuses[this.googleStatus-1]
     this.group.definitionGroup.googleStatus.status=this.google_statuses.values[this.googleStatus-1];

    this.userService.openGroupSendMessage(this.group).then(p=>{
      this.userService.setGroup(p);
       this.presentToast();
       this.navCtrl.push(HomePage);
       this.navCtrl.setRoot(HomePage);
    
    } 
    ).catch(eror=>{console.log(eror+" תקלה בעדכון סטטוס הקבוצה")});
  }
  ionViewDidLoad() {
    
    this.group=this.userService.getGroup();//לשים לב לשנות 
    console.log(this.group);
   
    this.status=this.group.status;
    this.nameGroup=this.group.name;
    
    
  }

  presentToast() {
    let toast = this.toastCtrl.create({
      message: 'עדכון פרטי הקבוצה נשמרו בהצלחה',
      duration: 4000,
      position: 'top'
    });
  
    toast.onDidDismiss(() => {
    
    });
  
    toast.present();
  }
 

}
