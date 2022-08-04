import { UserInterface } from "interfaces/user/user";
import { useState, useCallback, useEffect, useContext } from "react";
import { useParams, useNavigate, Link } from "react-router-dom";
import config from "config.json";
import { HttpRequest } from "services";
import { UserCreateOrUpdate } from "components/user/UserCreateOrUpdate";
import { toast } from "react-toastify";
import { AppContext } from "App";

export const UserUpdate = () => {
  const params = useParams();
  const { apiUrl } = config;
  const apiEndpoint = apiUrl + "/user";
  const { setLoading } = useContext(AppContext);
  const emptyUser = (): UserInterface => {
    return {
      id: 0,
      dateOfBirth: new Date(),
      firstName: "",
      lastName: "",
      userContacts: [],
    };
  };
  const [user, setUser] = useState(emptyUser());
  const navigate = useNavigate();

  const getUser = useCallback(() => {
    setLoading(true);
    HttpRequest.GET(`${apiEndpoint}/${params.id}`).subscribe({
      next: (response) => {
        setUser(response);
        setLoading(false);
      },
      error: (error: any) => {
        toast.error("An error has occured!");
        setLoading(false);
        navigate("/user");
      },
    });
  }, [apiEndpoint, params.id, navigate, setLoading]);

  useEffect(() => {
    getUser();
  }, [getUser]);

  function handleConfirm() {
    setLoading(true);
    HttpRequest.PUT(apiEndpoint, user).subscribe({
      next: (response) => {
        toast.success("User successfully updated!");
        setLoading(false);
      },
      error: (error: any) => {
        toast.error("An error has occured!");
        setLoading(false);
      },
    });
  }

  return (
    <div className="content">
      <h1>Edit user</h1>
      <br></br>

      <UserCreateOrUpdate
        user={user}
        onChange={(user) => setUser({ ...user })}
        onConfirm={() => handleConfirm()}
      ></UserCreateOrUpdate>

      <div className="mt-5">
        <Link to={"/user"}>Back to list</Link>
      </div>
    </div>
  );
};
