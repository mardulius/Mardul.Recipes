import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecipeComponent } from './components/recipe/recipe.component';
import { ShowRecipeComponent } from './components/recipe/show-recipe/show-recipe.component';
import {ApiService} from './services/api.service'
import { AddEditRecipeComponent } from './components/recipe/add-edit-recipe/add-edit-recipe.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    RecipeComponent,
    ShowRecipeComponent,
    AddEditRecipeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
