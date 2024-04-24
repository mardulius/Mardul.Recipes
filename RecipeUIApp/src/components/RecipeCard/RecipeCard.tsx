import { Link } from 'react-router-dom';
import styles from './RecipeCard.module.css';

export interface RecipeCardProps {
    id: number;
    name: string;
    description: string;
}

function RecipeCard(props: RecipeCardProps){


	// return(
	// 	<Link to={`/recipe/${props.id}`}>
	// 		<div className={styles['card']}>
	// 			<div className={styles['head']} style={{ backgroundImage: `url('${'./sharlotka.webp'}')` }}>
	// 			</div>
	// 			<div className={styles['footer']}>
	// 				<div className={styles['title']}>{props.name}</div>
	// 				<div className={styles['description']}>{props.description}</div>
	// 			</div>
	// 		</div>
	// 	</Link>
		
	// );

	return (<Link to={`/recipe/${props.id}`}>
		<div id	= {styles['container']}>
			<div className={styles['product-details']}>
				<h1>{props.name}</h1>
				<p className={styles['information']}>{props.description}</p>
			</div>
			<div className={styles['product-image']}><img src='./sharlotka.webp'/></div>
		</div>
	</Link>
	);
}

export default RecipeCard;