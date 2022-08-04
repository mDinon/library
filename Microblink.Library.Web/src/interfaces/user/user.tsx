export interface UserInterface {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  userContacts: UserContactInterface[];
}

export interface UserContactInterface {
  id: number;
  contactTypeId: ContactType;
  value: string;
}

export enum ContactType {
  EMAIL = 1,
  MOBILE = 2,
  TELEPHONE = 3,
}
