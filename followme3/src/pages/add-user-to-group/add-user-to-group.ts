import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController, AlertController } from 'ionic-angular';
import { MapPage } from '../map/map';
import { group, UsersServiceProvider, User, userInGroup, DefinitionUser } from '../../providers/users-service/users-service';
import { HomePage } from '../home/home';


/**
 * Generated class for the AddUserToGroupPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-add-user-to-group',
  templateUrl: 'add-user-to-group.html',
})
export class AddUserToGroupPage {
  loading: any;
  group:group;
  users:User[];
  allUsers:User[];
  selectUser:userInGroup;
  selectedUser:User;
  constructor(public navCtrl: NavController, public navParams: NavParams,public alert:AlertController
  ,public userServise:UsersServiceProvider,public loadingCtrl:LoadingController) {
    
  }
  showLoader(){
    this.loading = this.loadingCtrl.create({
        content: '...המתן'
    });
    this.loading.present();
  }
addToGroup(user:User)
{
  this.selectUser=new userInGroup();
  this.selectUser.UserPhoneGroup=user.phone;
  this.selectUser.definition=new DefinitionUser();
  this.selectUser.definition.seeMeALL=true; 
  this.users.push(user);
  let i:number;
  for(i = 0; i < this.group.users.length; i++) {
    if(this.allUsers[i] == user){
      this.allUsers.splice(i, 1);
      
    }
  }
}
removeItem(item){
 
 let i:number;
  for(i = 0; i < this.group.users.length; i++) {
    if(this.group.users[i] == item){
      this.group.users.splice(i, 1);
    }
  } 
}

saveUser()
  {
    let userIn:userInGroup[]=[];
    this.users.forEach(e => {
      let inin:userInGroup=new userInGroup();
      inin.UserPhoneGroup=e.phone;
      inin.definition=new DefinitionUser();
      inin.definition.seeMeALL=true;
      userIn.push(inin);
    });
    this.userServise.group.users=userIn;
   
    this.userServise.saveGroupUsers().then(p=>{
      this.navCtrl.push(HomePage);
      this.navCtrl.setRoot(HomePage);
    },(error)=>{ 
      let alert = this.alert.create({
      title: 'טעות',
      subTitle: 'תקלה בשמירת הנתונים'+error,
      buttons: [  {
        text: 'אישור',
        role: 'cancel',
        handler: data => {
        }
      }]
    });
    alert.present();});
  }

  ionViewDidLoad() {
    this.group=this.userServise.getGroup();
    this.showLoader();
    this.userServise.getUsersOfGroup(this.group.password).then(data=>{
    this.loading.dismiss();
     this.users=data;
    this.group.users=data;
}).catch(error=>{ 
  this.loading.dismiss();
  let alert = this.alert.create({
  title: 'טעות',
  subTitle: 'תקלה בקבלת המשתמשים לקבוצה זו'+error,
  buttons: [  {
    text: 'אישור',
    role: 'cancel',
    handler: data => {
    }
  }]
});
alert.present();});
 this.userServise.getAllUsers().then(p=>{
this.allUsers=p;
 }).catch(error=>{ let alert = this.alert.create({
  title: 'טעות',
  subTitle: 'תקלה בקבלת כל המשתמשים'+error,
  buttons: [  {
    text: 'אישור',
    role: 'cancel',
    handler: data => {
    }
  }]
});
alert.present();});
    
  }

}
