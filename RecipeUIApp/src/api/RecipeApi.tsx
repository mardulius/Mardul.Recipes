import axios from 'axios';
import { Recipe } from './Contracts';
import { API_BASE_URL } from './API';

export const getRecipes = async (): Promise<Recipe[]> => {

	console.log('start');
	const { data } = await axios.get<Recipe[]>(`${API_BASE_URL}/Recipe/All`);
	console.log(data);
	return data;
    
};