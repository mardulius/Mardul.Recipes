import { ButtonHTMLAttributes, ReactNode } from 'react';
import styles from './Button.module.css';
import cn from 'classnames';


export interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement>{
    children: ReactNode;
    //appearence?: 'big' | 'small';

}

export function Button({ children, className, ...props}: ButtonProps) {

	return (  
		<button className={cn(styles['button'], styles['accent'], className)} {...props}>{children}
		</button>
	);

}
export default Button;