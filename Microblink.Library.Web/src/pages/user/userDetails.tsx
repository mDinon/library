import { ContactType, UserInterface } from "interfaces/user/user";
import { useCallback, useEffect, useState } from "react";
import { useParams, useNavigate, Link } from "react-router-dom";
import { HttpRequest } from "services";
import config from "config.json";
import { Card, ListGroup } from "react-bootstrap";
import { toast } from "react-toastify";

export const UserDetails = () => {
  const params = useParams();
  const { apiUrl } = config;
  const apiEndpoint = apiUrl + "/user";
  const [user, setUser] = useState({} as UserInterface);
  const navigate = useNavigate();

  const toUserEdit = () => {
    navigate(`/user/edit/${user.id}`, { state: { user } });
  };

  const getUser = useCallback(() => {
    HttpRequest.GET(`${apiEndpoint}/${params.id}`).subscribe({
      next: (response) => {
        setUser(response);
      },
      error: (error: any) => {
        toast.error("An error has occured!");
        navigate("/user");
      },
    });
  }, [apiEndpoint, params.id, navigate]);

  useEffect(() => {
    getUser();
  }, [getUser]);

  const contactTypes = new Map([
    [
      0,
      {
        text: "choose...",
      },
    ],
    [
      ContactType.EMAIL,
      {
        text: "email:",
      },
    ],
    [
      ContactType.MOBILE,
      {
        text: "mobile:",
      },
    ],
    [
      ContactType.TELEPHONE,
      {
        text: "telephone:",
      },
    ],
  ]);

  return (
    <div className="content">
      <h1>User details</h1>
      <br></br>

      <Card className="w-50">
        <Card.Body>
          <Card.Title className="mb-4">
            <div className="d-flex justify-content-between">
              <span>
                {user.firstName} {user.lastName}
              </span>
              <span className="p-2" role="button" onClick={() => toUserEdit()}>
                <i className="bi bi-pencil"></i>
              </span>
            </div>
          </Card.Title>
          <Card.Subtitle className="mb-2 text-muted">
            {new Date(user.dateOfBirth).toLocaleDateString()}
          </Card.Subtitle>
          <ListGroup variant="flush">
            {user?.userContacts?.map((uc) => (
              <ListGroup.Item key={uc.id}>
                <strong>{contactTypes.get(uc.contactTypeId)?.text}</strong>{" "}
                {uc.value}
              </ListGroup.Item>
            ))}
          </ListGroup>
        </Card.Body>
      </Card>

      <div className="mt-5">
        <Link to={"/user"}>Back to list</Link>
      </div>
    </div>
  );
};
