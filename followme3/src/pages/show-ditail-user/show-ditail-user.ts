import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { UsersServiceProvider } from '../../providers/users-service/users-service';

/**
 * Generated class for the ShowDitailUserPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-show-ditail-user',
  templateUrl: 'show-ditail-user.html',
})
export class ShowDitailUserPage {
  nameUser:string
  constructor(public navCtrl: NavController, public navParams: NavParams,private userService:UsersServiceProvider) {
  }

  ionViewDidLoad() {
    this.userService.getAllUsers().then(p=>{
      let r=p;
      console.log(r);
      this.nameUser=r.find(p=>p.phone==this.userService.getPhoneUser()).firstName;
    });
    console.log('ionViewDidLoad ShowDitailUserPage');
  }

}
