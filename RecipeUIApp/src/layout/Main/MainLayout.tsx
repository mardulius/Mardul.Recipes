import { Outlet } from 'react-router-dom';
import styles from './MainLayout.module.css';
import { Header } from '../../components/Header/Header';

export function MainLayout(){
	return <>
		<Header className={styles['header']}>Рецепты</Header>
		<div className={styles['content']}>
			<Outlet />
		</div>
	</>;
}