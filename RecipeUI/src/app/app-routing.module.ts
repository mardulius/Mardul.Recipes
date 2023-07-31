import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RecipeComponent } from './components/recipe/recipe.component';
import { AddEditRecipeComponent } from './components/recipe/add-edit-recipe/add-edit-recipe.component';
const routes: Routes = [
  {path: 'recipe', component: RecipeComponent},
  { path: 'recipe/add', component: AddEditRecipeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
