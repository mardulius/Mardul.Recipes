export interface Recipe {
    id: number
    name: string
    dateCreate: string
    instruction: string
    description: string
    ingredients: Ingredient[]
}

export interface Ingredient {
    id: number
    amount: number
    measureId: number
    measureName: string
    ingredientId: number
    ingredientName: string
  }