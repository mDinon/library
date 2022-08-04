import React from 'react';
import { Spinner } from 'react-bootstrap';

interface LoaderProps {
	show: boolean;
}

export const Loader = ({ show }: LoaderProps) => (
	<>
		{show ?
			<div className="loader">
				<div className="spinner-container">
					<Spinner animation="border" variant="primary" role="status">
						<span className="visually-hidden">Loading...</span>
					</Spinner>
				</div>
			</div>
			: null
		}
	</>
);