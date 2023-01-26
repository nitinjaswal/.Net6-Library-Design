import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BookCreateComponent } from './books/book-create/book-create.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { BooksListComponent } from './books/books-list/books-list.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  {
    path: '',
    children: [
      { path: 'books', component: BooksListComponent },
      { path: 'books/:id', component: BookDetailComponent },
    ],
  },
  { path: 'createbook', component: BookCreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
