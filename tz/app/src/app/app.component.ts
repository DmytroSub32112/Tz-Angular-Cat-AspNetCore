import { Component } from '@angular/core';
import { FormControl,FormGroup,FormBuilder } from '@angular/forms';
import { Cat} from './cats';
import { Cats } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
  constructor(private serv:Cats,private fb:FormBuilder){}
  myform:any;
  cats:any;
  contactForm:any;
  contactForm2:any;
  contactForm3:any;
  flag:Boolean =true;
  CatArr = [
    { name: "Британец" },
    { name: "Шотландец"},
    { name: "Сфинкс" },
    { name: "Лев" }

  ];
  sortArr = [
    { name: "Age"},
    { name: "Name"}


  ];
  TakeArr = [
    { name: 5},
    { name: 10},
    { name: 15},
    { name: 20}



  ];
  ngOnInit(): void {
    this.myform = new FormGroup({
      name: new FormControl("Имя"),
      age: new FormControl("возраст"),
      info: new FormControl(" Информация"),
      url :new FormControl("ссылка на картинку"),
        bread: new FormControl("Породу")
    })
    this.serv.Get().subscribe((data: any) => this.cats = data);
    this.contactForm = this.fb.group({
      catBreed: [this.CatArr[0]]
  })
  this.contactForm2 = this.fb.group({
    sort: [this.sortArr[0]]
})
this.contactForm3 = this.fb.group({
  value: [this.TakeArr[0]]
})
  }
  Submit(myform:any){
    let cat=new Cat(
     this.myform.value.name,
     this.myform.value.info,
     this.myform.value.url,
     this.myform.value.age,
     this.myform.value.bread,
   );
   console.log(cat)
   this.serv.Post(cat).subscribe()
   this.serv.Get().subscribe((data: any) => this.cats = data);
  }
   Delete(id:any){
    this.serv.Delete(id).subscribe();
    this.serv.Get().subscribe((data: any) => this.cats = data);
   }
   submitBreed(){

    let cat =new Cat("1","2","3",4,this.contactForm.value.catBreed) 
    this.serv.PostBreed(cat).subscribe((data: any) => this.cats = data);
   }
   ChangeFlag(){
    this.flag =!this.flag
   }
   sort(){
    let cat =new Cat("1","2","3",4,this.contactForm2.value.sort) 
    this.serv.PostSort(cat).subscribe((data: any) => this.cats = data);
    console.log(this.contactForm2.value.sort)
   }
   take(){
    let cat =new Cat("1","2","3",this.contactForm3.value.value,"") 
    this.serv.TakeFirst(cat).subscribe((data: any) => this.cats = data);
   }
}
