export class BookMaster {
  title: string;
  publisher: string;
  authorName: string;
  totalPages: number;
  description: string;
  imagePath: string;
  bookType: string;
  category: string;

  constructor() {
    this.title = '';
    this.publisher = '';
    this.authorName = '';
    this.totalPages = 0;
    this.description = '';
    this.imagePath = '';
    this.bookType = '';
    this.category = '';
  }
}
