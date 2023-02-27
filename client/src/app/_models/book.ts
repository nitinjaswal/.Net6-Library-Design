export class Book {
  id: number;
  bookCount: number;
  title: string;
  publisher: string;
  authorName: string;
  totalPages: number;
  description: string;
  imagePath: string;
  bookType: string;
  category: string;
  status: string;
  isbn: string;

  constructor() {
    this.id = 0;
    this.bookCount = 0;
    this.title = '';
    this.publisher = '';
    this.authorName = '';
    this.totalPages = 0;
    this.description = '';
    this.imagePath = '';
    this.bookType = '';
    this.category = '';
    this.status = '';
    this.isbn = '';
  }
}
