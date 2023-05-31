import { Component, OnInit } from '@angular/core';
import { IRecipe } from 'src/app/models/irecipe';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-show-recipe',
  templateUrl: './show-recipe.component.html',
  styleUrls: ['./show-recipe.component.css']
})
export class ShowRecipeComponent implements OnInit {

  constructor( private service: ApiService) {}
  RecipeList: IRecipe[] = [];

  ngOnInit(): void {
    this.refreshRecipeList();
  }

  
  refreshRecipeList() {
    this.service.getRecipeList().subscribe(data => {
      this.RecipeList = data;
    });
  }
}
