import React from "react";
import { RouteInterface } from "interfaces";
import { UserList, UserDetails, UserCreate, UserUpdate } from "pages";
import { NavigationService } from "services";

export const UserRoutes = () => NavigationService.generateRoutes(userRoutes);

export const userRoutes: RouteInterface[] = [
  { path: "/", component: <UserList /> },
  { path: "/:id", component: <UserDetails /> },
  { path: "/create", component: <UserCreate /> },
  { path: "/edit/:id", component: <UserUpdate /> },
];
