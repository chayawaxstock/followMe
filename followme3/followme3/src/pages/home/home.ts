import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { group, UsersServiceProvider } from '../../providers/users-service/users-service';
import { LoginGroupPage } from '../login-group/login-group';
import { EnterGroupPage } from '../enter-group/enter-group';
import { ShowDitailUserPage } from '../show-ditail-user/show-ditail-user';


@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  phone:string;
  group:group;
  constructor(public navCtrl: NavController,public userService:UsersServiceProvider) {
  this.group=userService.getGroup();
  
  this.phone=userService.getPhoneUser();
 // setInterval(() => console.log(9), 500);
  }


  
  addMeToKodGroup()
  {
    this.navCtrl.push(EnterGroupPage);
  }

  detailUser()
  {
    this.userService.userDetails=this.userService.getPhoneUser();
    this.navCtrl.push(ShowDitailUserPage);
  }
 
}
