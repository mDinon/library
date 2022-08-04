import React from "react";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";

export const Header = () => {
  return (
    <Navbar bg="light" expand="lg" className="mb-5">
      <Container>
        <Navbar.Brand href="/">Library</Navbar.Brand>
        <Navbar.Toggle aria-controls="nav" />
        <Navbar.Collapse id="nav">
          <Nav className="me-auto">
            <Nav.Link href="/">Users</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
