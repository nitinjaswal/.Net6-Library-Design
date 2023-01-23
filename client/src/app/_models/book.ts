export class Book {
  count: number;
  title: string;
  publisher: string;
  authorName: string;
  totalPages: number;
  description: string;
  image: string;
  bookType: string;
  category: string;
  status: string;

  constructor() {
    this.count = 0;
    this.title = '';
    this.publisher = '';
    this.authorName = '';
    this.totalPages = 0;
    this.description = '';
    this.image = '';
    this.bookType = '';
    this.category = '';
    this.status = '';
  }
}
