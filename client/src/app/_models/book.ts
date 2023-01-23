export class Book {
  id:number;
  count: number;
  title: string;
  publisher: string;
  authorName: string;
  totalPages: number;
  description: string;
  imagePath: string;
  bookType: string;
  category: string;
  status: string;

  constructor() {
    this.id=0;
    this.count = 0;
    this.title = '';
    this.publisher = '';
    this.authorName = '';
    this.totalPages = 0;
    this.description = '';
    this.imagePath = '';
    this.bookType = '';
    this.category = '';
    this.status = '';
  }
}
