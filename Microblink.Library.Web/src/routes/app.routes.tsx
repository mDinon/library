import React from "react";
import { RouteInterface } from "interfaces";
import { UserRoutes } from "./user/user.routes";

export const appRoutes: RouteInterface[] = [
  { path: "user/*", component: <UserRoutes /> },
];
