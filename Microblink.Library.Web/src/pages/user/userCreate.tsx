import { UserCreateOrUpdate } from "components/user/UserCreateOrUpdate";
import { UserInterface } from "interfaces/user/user";
import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { HttpRequest } from "services";
import config from "config.json";
import { toast } from "react-toastify";

export const UserCreate = () => {
  const { apiUrl } = config;
  const apiEndpoint = apiUrl + "/user";
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

  function handleChange(user: UserInterface) {
    setUser(user);
  }

  function handleConfirm() {
    HttpRequest.POST(apiEndpoint, user).subscribe({
      next: (response) => {
        toast.success("User successfully created!");
        navigate("/user");
      },
      error: (error: any) => {
        toast.error("An error has occured!");
      },
    });
  }

  return (
    <div className="content">
      <h1>Create user</h1>
      <br></br>

      <UserCreateOrUpdate
        user={user}
        onChange={(user) => handleChange({ ...user })}
        onConfirm={() => handleConfirm()}
      ></UserCreateOrUpdate>

      <div className="mt-5">
        <Link to={"/user"}>Back to list</Link>
      </div>
    </div>
  );
};
