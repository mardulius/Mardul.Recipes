import { useEffect, useState } from 'react';
import { Recipe } from '../../api/Contracts';
import { RecipeList } from './RecipeList/RecipeList';
import { getRecipes } from '../../api/RecipeApi';

export function Recipes(){

	const [recipes, setRecipes] = useState<Recipe[]>([]);


	useEffect(() => {
		getRecipes().then(recipes => setRecipes(recipes));

	}, []);
	return <>
		<RecipeList recipes={recipes}/>
	</>;
}