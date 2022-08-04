import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Cat} from "./cats";




@Injectable(
 {providedIn:'root'}
)
 export class Cats {
  
   constructor(private http:HttpClient){
       
   }
   Post(cat:Cat){
    return this.http.post('https://localhost:44371/Cat',cat)
   }
   Get(){
    return this.http.get('https://localhost:44371/Cat')
   }
   Delete(id:any){
    return this.http.delete('https://localhost:44371/Cat'+"/"+id)
   }
   PostBreed(breed:Cat){
    console.log(breed)
    return this.http.post('https://localhost:44371/CatBreed',breed)

   }
   PostSort(sort:Cat){
    return this.http.post('https://localhost:44371/CatSort',sort)
   }
   TakeFirst(sort:Cat){
    return this.http.post('https://localhost:44371/CatTake',sort)
   }
}