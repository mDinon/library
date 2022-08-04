import React, { useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { appRoutes } from "routes";
import { NavigationService } from "services";
import { AppContext as AC } from "interfaces";
import { ToastContainer } from "react-toastify";
import { Footer, Header, Loader } from "components";

export const AppContext = React.createContext({} as AC);

export const App = () => {
  const [loading, setLoading] = useState(false);

  console.log(loading);

  return (
    <>
      <Header />
      <main className="container">
        <AppContext.Provider value={{ loading, setLoading }}>
          <BrowserRouter>
            {NavigationService.generateRoutes(appRoutes)}
          </BrowserRouter>
        </AppContext.Provider>
      </main>
      <Footer />
      <ToastContainer />
      <Loader show={loading} />
    </>
  );
};
