import { Role } from "./role";

export class User {
  id: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  roles: Role[];
  role: Role;
  token?: string;
}
