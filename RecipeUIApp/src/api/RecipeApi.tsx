import axios from 'axios';
import { Recipe } from './Contracts';
import { PREFIX } from './API';

export const getRecipes = async (): Promise<Recipe[]> => {

	console.log('start');
	const { data } = await axios.get<Recipe[]>(`${PREFIX}/Recipe/All`);
	console.log(data);
	return data;
    
};