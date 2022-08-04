import { ToastOptions } from 'react-toastify';

export interface AppContext {
	showToast: (value: string, props?: ToastOptions) => void;
	loading: boolean;
	setLoading: (loading: boolean) => void;
}