import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RecipeComponent } from './components/recipe/recipe.component';
const routes: Routes = [
  {path: 'recipe', component: RecipeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
