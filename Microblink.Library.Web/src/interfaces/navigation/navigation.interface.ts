export interface RouteInterface {
    path: string;
    component: JSX.Element;
    redirect?: string;
}