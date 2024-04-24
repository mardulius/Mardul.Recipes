import { HTMLAttributes, ReactNode } from 'react';
import styles from './Header.module.css';
import Button from '../Button/Button';
import { useNavigate } from 'react-router-dom';
export interface HeaderProps extends HTMLAttributes<HTMLHeadingElement>{

    children : ReactNode;
}

export function Header({children}: HeaderProps){

	const navigate = useNavigate();

	return(
		<>
			
			<div className={styles['header']}>
				<Button className={styles['exit']} onClick={() => navigate('/auth/login')}>Войти</Button>
			</div>
		</>
	);
	
   
}