import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-show-recipe',
  templateUrl: './show-recipe.component.html',
  styleUrls: ['./show-recipe.component.css']
})
export class ShowRecipeComponent implements OnInit {

  constructor( private service: ApiService) {}
  RecipeList: any = [];

  ngOnInit(): void {
    this.refreshRecipeList();
  }

  
  refreshRecipeList() {
    this.service.getRecipeList().subscribe(data => {
      this.RecipeList = data;
    });
  }
}
