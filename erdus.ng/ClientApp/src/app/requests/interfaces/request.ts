export interface Request {
  id: number;
  topic: string;
  address: string;
  creationDate: Date;
  responsiblePerson: string;
  hasResponsiblePerson: boolean;
  status: string;
  categoryId: number;
  categoryName: string;
}
