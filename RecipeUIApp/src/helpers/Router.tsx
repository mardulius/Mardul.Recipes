import { createBrowserRouter } from 'react-router-dom';
import { MainLayout} from '../layout/Main/MainLayout';
import { AuthLayout } from '../layout/Auth/AuthLayout';
import { Recipes } from '../pages/Recipes/Recipes';
import { Login } from '../pages/Login/Login';


export const Router = createBrowserRouter([
	{
		path: '/',
		element: <MainLayout />,
		children:[
			{
				path: '/',
				element: <Recipes/>
			}
		]
	},
	{
		path: '/auth',
		element:<AuthLayout />,
		children: [
			{
				path:'login',
				element: <Login />
			}
		]
	},
	{
		path: '*',
		element: <div>Ошибка</div>
	}
]);
