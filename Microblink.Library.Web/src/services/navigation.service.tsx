import React from "react";
import { Route, Navigate, Routes } from "react-router-dom";
import { RouteInterface } from "interfaces";

const generateRoutes = (routes: Array<RouteInterface>) => (
  <Routes>
    {routes.map((route: RouteInterface, index: number) => {
      return <Route key={index} path={route.path} element={route.component} />;
    })}
    <Route path="*" element={<Navigate replace to="/user" />} />
  </Routes>
);

export const NavigationService = {
  generateRoutes,
};
