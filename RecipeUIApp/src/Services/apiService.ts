import { API_BASE_URL } from '../api/API';

export async function sendLogin(email: string, password: string) {
	try {
		const response = await fetch(API_BASE_URL+'/account/login', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				email,
				password
			})
		});

		if (!response.ok) {
			throw new Error('Login failed');
		}

		const data = await response.json();
		console.log('Login successful:', data);
		// Здесь вы можете сохранить токен или перенаправить пользователя
	} catch (error) {
		console.error('Error during login:', error);
		// Обработка ошибки (например, показать сообщение пользователю)
	}
}