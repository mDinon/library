import React, { useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { appRoutes } from "routes";
import { NavigationService } from "services";
import { AppContext as AC } from "interfaces";
import { toast, ToastContainer, ToastOptions } from "react-toastify";
import { Footer, Header, Loader } from "components";

export const AppContext = React.createContext({} as AC);

export const App = () => {
  const [loading, setLoading] = useState(false);

  const showToast = (value: string, props?: ToastOptions) =>
    toast(value, props);

  return (
    <>
      <Header />
      <main className="container">
        <AppContext.Provider value={{ loading, showToast, setLoading }}>
          <BrowserRouter>
            {NavigationService.generateRoutes(appRoutes)}
          </BrowserRouter>
        </AppContext.Provider>
        {/* <Footer /> */}
      </main>
      <Footer />
      <ToastContainer />
      <Loader show={loading} />
    </>
  );
};
