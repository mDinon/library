import { UserInterface } from "interfaces/user/user";
import React, { useCallback, useEffect, useState } from "react";
import { HttpRequest } from "services";
import config from "config.json";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export const UserList = () => {
  const { apiUrl } = config;
  const apiEndpoint = apiUrl + "/user";
  const [users, setUsers] = useState([] as UserInterface[]);
  const navigate = useNavigate();

  const toUserCreate = () => {
    navigate("/user/create");
  };

  const toUserEdit = (user: UserInterface) => {
    navigate(`/user/edit/${user.id}`, { state: { user } });
  };

  const getUserList = useCallback(() => {
    HttpRequest.GET(apiEndpoint).subscribe({
      next: (response) => {
        setUsers(response);
      },
      error: (error: any) => {
        console.error(error);
        toast.error("An error has occured!");
      },
    });
  }, [apiEndpoint]);

  useEffect(() => {
    getUserList();
  }, [getUserList]);

  const deleteUser = (user: UserInterface) => {
    HttpRequest.DELETE(`${apiEndpoint}/${user.id}`).subscribe({
      next: (response) => {
        setUsers((users) => users.filter((u) => u.id !== user.id));
        toast.success("User successfully deleted!");
      },
      error: (error: any) => {
        console.error(error);
        toast.error("An error has occured!");
      },
    });
  };

  return (
    <div className="content">
      <h1>Users</h1>
      <br></br>

      <div className="d-flex flex-row-reverse">
        <button className="btn btn-primary" onClick={() => toUserCreate()}>
          Add new
        </button>
      </div>
      <table className="table">
        <thead>
          <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>Date of birth</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {users.map((u) => (
            <tr key={u.id}>
              <td>
                <Link to={`${u.id}`} state={u}>
                  {u.firstName}
                </Link>
              </td>
              <td>{u.lastName}</td>
              <td>{new Date(u.dateOfBirth).toLocaleDateString()}</td>
              <td className="w-25">
                <span
                  className="p-2"
                  role="button"
                  onClick={() => toUserEdit(u)}
                >
                  <i className="bi bi-pencil"></i>
                </span>
                |
                <span
                  className="p-2"
                  role="button"
                  onClick={() => deleteUser(u)}
                >
                  <i className="bi bi-trash"></i>
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
