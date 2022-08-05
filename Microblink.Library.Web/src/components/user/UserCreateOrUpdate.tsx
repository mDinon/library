import dayjs from "dayjs";
import {
  ContactType,
  UserContactInterface,
  UserInterface,
} from "interfaces/user/user";
import React from "react";
import { Form, Button } from "react-bootstrap";
import { toast } from "react-toastify";

interface UserProps {
  user: UserInterface;
  onChange: (user: UserInterface) => void;
  onConfirm: () => void;
}

export const UserCreateOrUpdate = ({
  user,
  onChange,
  onConfirm,
}: UserProps) => {
  const onUserChange = (user: UserInterface) => {
    const newState = { ...user };
    onChange(newState);
  };

  const submit = (e: any) => {
    e.preventDefault();
    if (user.userContacts.length) onConfirm();
    else toast.error("User must have at least one contact information!");
  };

  const addContact = (contactItem: UserContactInterface) => {
    const newState = { ...user };
    newState.userContacts = [...user.userContacts, contactItem];
    onChange(newState);
  };

  const emptyContact = (): UserContactInterface => {
    return {
      id: 0,
      contactTypeId: ContactType.EMAIL,
      value: "",
    };
  };

  const updateUserContactItem = (index: number) => (e: any) => {
    const contacts = user.userContacts.map((item, i) => {
      if (index === i) {
        if (e.target.name === "contactTypeId")
          return {
            ...item,
            [e.target.name]: parseInt(e.target.value),
          };
        else return { ...item, [e.target.name]: e.target.value };
      } else {
        return item;
      }
    });
    const newState = { ...user };
    newState.userContacts = contacts;
    onChange(newState);
  };

  const deleteContact = (index: number) => {
    const newState = { ...user };
    newState.userContacts = user.userContacts.filter((_, i) => i !== index);
    onChange(newState);
  };

  return (
    <Form onSubmit={submit}>
      <h3>Basic information</h3>
      <Form.Group className="mb-3 w-50" controlId="userFirstName">
        <Form.Label>First name</Form.Label>
        <Form.Control
          type="text"
          name="firstName"
          placeholder="Enter first name"
          value={user.firstName}
          onChange={(e) => {
            e.persist();
            onUserChange({ ...user, firstName: e.target.value });
          }}
          required
          maxLength={255}
        />
      </Form.Group>
      <Form.Group className="mb-3 w-50" controlId="userLastName">
        <Form.Label>Last name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter last name"
          name="lastName"
          value={user.lastName}
          onChange={(e) => {
            e.persist();
            onUserChange({ ...user, lastName: e.target.value });
          }}
          required
          maxLength={255}
        />
      </Form.Group>
      <Form.Group className="mb-3 w-25" controlId="userDateOfBirth">
        <Form.Label>Date of birth</Form.Label>
        <Form.Control
          type="date"
          value={dayjs(user.dateOfBirth).format("YYYY-MM-DD")}
          name="dateOfBirth"
          onChange={(e) => {
            e.persist();
            onUserChange({ ...user, dateOfBirth: new Date(e.target.value) });
          }}
          required
        />
      </Form.Group>
      <hr />
      <h3>Contact info</h3>
      <div className="d-flex flex-row-reverse">
        <Button variant="secondary" onClick={() => addContact(emptyContact())}>
          Add contact
        </Button>
      </div>
      {user?.userContacts?.map((uc, index) => (
        <Form.Group key={index} className="mb-3" controlId="userContactType">
          <Form.Label>Contact item</Form.Label>
          <div className="row">
            <Form.Select
              size="sm"
              className="w-25"
              name="contactTypeId"
              value={uc.contactTypeId}
              onChange={updateUserContactItem(index)}
            >
              <option value={ContactType.EMAIL}>Email</option>
              <option value={ContactType.MOBILE}>Mobile</option>
              <option value={ContactType.TELEPHONE}>Telephone</option>
            </Form.Select>
            <Form.Control
              className="w-50 ms-2"
              type={uc.contactTypeId === ContactType.EMAIL ? "email" : "text"}
              placeholder="Enter contact info"
              name="value"
              value={uc.value}
              onChange={updateUserContactItem(index)}
              required
              maxLength={255}
            />
            <span
              className="p-2"
              style={{ width: 30 }}
              role="button"
              onClick={() => deleteContact(index)}
            >
              <i className="bi bi-trash"></i>
            </span>
          </div>
        </Form.Group>
      ))}
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );
};
