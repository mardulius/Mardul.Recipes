import { Recipe } from '../../../api/Contracts';
import RecipeCard from '../../../components/RecipeCard/RecipeCard';

export interface RecipeListProps{
    recipes: Recipe[]
}

export function RecipeList( {recipes} : RecipeListProps){

	return <div>{
		recipes.map( r => <RecipeCard
			key={r.id}
			id={r.id}
			name={r.name}
			description={r.description}
		/>)
	}    
	</div>;
}