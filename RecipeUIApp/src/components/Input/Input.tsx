import styles from './Input.module.css';
import { InputHTMLAttributes, forwardRef } from 'react';
import cn from 'classnames';

export interface InputProps extends InputHTMLAttributes<HTMLInputElement>{

    isValid?: boolean
}

const Input = forwardRef<HTMLInputElement, InputProps>(function Input({className, isValid,  ...props }, ref) {
	return (  
		<input {...props} ref={ref} className={cn(styles['input'], className, {
			[styles['invalid']] : !isValid
		})} />
	);
});

export default Input;
