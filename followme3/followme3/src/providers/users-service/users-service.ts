
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { DateTime } from 'ionic-angular/umd';
import { Http } from '@angular/http';
import { Observable, Subject } from 'rxjs';

export interface Message {
  KodError: number;
  MessageError: string;
}

export interface MessObject {
  Message: Message;
  Group: group;
  UserName: string;
}

export interface ErrorMessage {
  KodError: number;
  MessageError: string;
}

export class User {
  id?: number;
  email?: string;
  firstName?: string;
  lastName?: string;
  phone?: string;
  image?: string;
  marker?: marker;
  status?: boolean;
 

  constructor() {
  }
}
export class marker {
  lng?: number;
  lat?: number;
  name?: string;
  constructor() {


  }
}
export class GoogleStatus {
  code?: number;
  status?: string;
  constructor() {
  }

}

export class DefinitionGroup {
  distance?: number;
  googleStatus?: GoogleStatus;
  eWhenStatusOpen: number;
  constructor() {
  }
}
export class DefinitionUser {
  seeMeALL?: boolean;
  constructor() {
  }

}
export class userInGroup {
  UserPhoneGroup?: string;
  definition?: DefinitionUser;
  constructor() { }
}

export class managmentInGroup {
  phoneManagment?: string;
  comeToTrip?: boolean;
  constructor() { }
}

export class group {
  id?: number;
  name?: string;
  Kod?: string;
  description?: string;
  password?: string;
  users?: userInGroup[];
  userOk?: userInGroup[];
  status?: boolean;
  DateBegin?: Date;
  DateEnd?: Date;
  listManagment?: managmentInGroup[];
  definitionGroup?: DefinitionGroup;

  constructor() {


  }
}


/*
  Generated class for the UsersServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class UsersServiceProvider {
 

  isManagment: boolean;
  groupMangment: group;
  baseUrl: string = "http://localhost:54599/api/";
  managment: Array<string>;
  answer: string;
  phoneUser: string;
  subject=new Subject();
  getMarkerUsers(gr: group): Promise<marker[]> {
    
    return this.http.post('http://localhost:54599/api/getUsersMarker', gr).map(p => p.json()).toPromise();
    //return this.users.map(p => p.marker);
  }
  getMarkerManagments(gr: group): Promise<marker[]> {
   
    return this.http.post('http://localhost:54599/api/getManagmentsMarker', gr).map(p => p.json()).toPromise();
    //return this.users.map(p => p.marker);
  }
  checkKod(kod: string): Promise<any> {
    return this.http.get(this.baseUrl + "checkKodGroup/" + kod + '/' + this.getPhoneUser()).toPromise();
  }

  getManagmentGroup(phone: string): Promise<group[]> {
    return this.http.get(this.baseUrl + "getManagmentGroup/" + phone).map(p => p.json()).toPromise();
  }
  setGroupManagment(group1: group) {
    this.groupMangment = group1;
  }
  getGroupManagment(): group {
    return this.groupMangment;
  }

  groups: group[];

  currentUser: User;
  users: User[];
  group: group;
  constructor(private http: Http) {
    this.users = [];
    this.managment = [];
  };
  setPhoneManagment(phone: string) {
    this.managment.push(phone);
  }

  getPhonesManagment() {
    return this.managment;
  }
  setPhoneUser(string: string) {
    this.phoneUser = string;
  }

  getPhoneUser() {
    return this.phoneUser;
  }

  setGroup(gr: group) {
    this.group = gr;
  }

  getGroup() {
    return this.group;
  }


  getGroups(phone: string): Promise<any> {
    return this.http.get(this.baseUrl + "groupOfUser/" + phone).map(pp => pp.json()).toPromise();
  }


  login(phone: string): Promise<any> {

    return this.http.get('http://localhost:54599/api/login/' + phone).toPromise();

  }
  addUser(user: User): Promise<any> {
    console.log("addUser")
    return this.http.post('http://localhost:54599/api/register', user).toPromise();
    // this.users.push(user);
  }
  addNewGroup(group: group): Promise<any> {
    // this.groups.push(group);
    return this.http.post('http://localhost:54599/api/addGroup', group).map(p => p.json()).toPromise();
  }

  getUsersOfGroup(pass: string): Promise<any> {
    return this.http.get("http://localhost:54599/api/UsersOfGroup/" + pass).map(p => p.json()).toPromise();
  }

  openGroupSendMessage(group: group): Promise<any> {
    return this.http.post("http://localhost:54599/api/updateGroup", group).toPromise();
  }


  updateMarker(phone: string, marker: marker): Promise<any> {
    let help = { phone: phone, lat: marker.lat, lng: marker.lng };
    return this.http.post("http://localhost:54599/api/updateMarker", help).toPromise();
  }

  getAllUsers(): Promise<User[]> {
    return this.http.get("http://localhost:54599/api/getAllUsers/" + this.getGroup().password).map(p => p.json()).toPromise();
  }

  checkPassGroup(pass: string) {
    if (this.getGroup().password == pass) {
      let userManagment = { group: this.getGroup(), phoneUser: this.getPhoneUser() }
      var group = this.getGroup();
      return this.http.get('http://localhost:54599/api/AddManagment/' + group.password + '/' + this.getPhoneUser()).toPromise();
    }

    return false;
  }

  CheckDistance(): Promise<group[]> {
    let phone:string = this.getPhoneUser();
    return this.http.get("http://localhost:54599/api/CheckDistance/"+ phone).map(p => p.json()).toPromise();
  }

  checkOpenGroupAndConfirm(): Promise<group[]> {
    let phone = this.getPhoneUser();
    return this.http.get('http://localhost:54599/api/checkOpenGroupAndConfirm/' + phone).map(p => p.json()).toPromise();
  }

  agreeToAddGroup(pass: string): Promise<any> {
    let phone = this.getPhoneUser();
    return this.http.get('http://localhost:54599/api/AgreeToAddGroup/' + pass + '/' + phone).toPromise().then(p => {
      console.log(p);
    });
  }
  saveGroupUsers(): Promise<any> {
    console.log(this.getGroup());
    console.log("saveeeeeeeeee");
    return this.http.post("http://localhost:54599/api/updateUsersGroup", this.getGroup()).toPromise();
  }
  getAllGroup(): Promise<any> {
    return this.http.get(this.baseUrl + "getAllGroups").map(p => p.json()).toPromise();
  }

  getUserInf():Promise<User> {
      return this.http.get(this.baseUrl+"getUserInf").map(p=>p.json()).toPromise();
  }

  getMyMessage():Promise<any>
  {
    if(this.getPhoneUser())
      return this.http.get(this.baseUrl+"CheckIfHaveMessage/"+this.getPhoneUser()).map(data=>data.json()).toPromise();
    return null;
  }

  groupOfUserStatusFalse():Observable<any>
  {
    return this.http.get(this.baseUrl+'groupOfUserStatusFalse/'+this.getPhoneUser()).map(p=>p.json());
  }

  getManagmentGroupFalse():Observable<any>
  {
    return this.http.get(this.baseUrl+'getManagmentGroupFalse/'+this.getPhoneUser()).map(p=>p.json());
  }

  deleteGroup(password: string): Observable<any> {
    return this.http.delete(this.baseUrl+'deleteGroup/'+password);
  }

}
