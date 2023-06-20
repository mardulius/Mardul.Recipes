import { Data } from "@angular/router";
import { IRecipeIngredient } from "./irecipeingredients";

export interface IRecipe {
    id: number;
    name: string;
    dateCreate: Date;
    instruction: string;
    description: string;
    ingredients: IRecipeIngredient[];
    
}