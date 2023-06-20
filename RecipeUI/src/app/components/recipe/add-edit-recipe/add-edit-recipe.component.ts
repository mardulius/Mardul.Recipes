import { Component } from '@angular/core';
import { IRecipe } from 'src/app/models/irecipe';

import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-add-edit-recipe',
  templateUrl: './add-edit-recipe.component.html',
  styleUrls: ['./add-edit-recipe.component.css']
})
export class AddEditRecipeComponent {
  constructor( private service: ApiService) {}


  recipe: IRecipe = {
    id: 0,
    name: '',
    dateCreate: new Date(),
    instruction: '',
    description: '',
    ingredients: []
  };

  add(recipe: IRecipe){
    this.service.addRecipe(this.recipe);
    console.log("нажато");
  }
}
