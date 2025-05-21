import { FormEvent } from 'react';
import Button from '../../components/Button/Button';
import { Link } from 'react-router-dom';
import styles from './Login.module.css';
import Input from '../../components/Input/Input';
import { sendLogin } from '../../Services/apiService';
import { LoginForm } from '../../api/Contracts';


export function Login(){

	const submit = async (e: FormEvent) => {
		e.preventDefault();
	
		const target = e.target as typeof e.target & LoginForm;
		const {email, password} = target;
		await sendLogin(email.value, password.value);
	};
	
	return <div className={styles['login']}>

		<form className={styles['form']} onSubmit={submit}>
			<div className={styles['field']}>
				<label htmlFor="email">Ваш email</label>
				<Input id="email" name='email' placeholder='Email' />
			</div>
			<div className={styles['field']}>
				<label htmlFor="password">Ваш пароль</label>
				<Input id="password" name='password' type="password" placeholder='Пароль' />
			</div>
			<Button>Вход</Button>
		</form>
		<div className={styles['links']}>
			<div>Нет акканута?</div>
			<Link to="/auth/register">Зарегистрироваться</Link>
		</div>
	</div>;


		
}

