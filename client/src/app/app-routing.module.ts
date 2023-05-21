import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BookCreateComponent } from './books/book-create/book-create.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { RequestedBooksComponent } from './books/requested-books/requested-books.component';
import { HomeComponent } from './home/home.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { BookIssueComponent } from './books/book-issue/book-issue.component';
import { BookReturnComponent } from './books/book-return/book-return.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'books', component: BooksListComponent, pathMatch: 'full' },
  {
    path: 'books/:id',
    component: BookDetailComponent,
  },
  {
    path: 'createbook',
    component: BookCreateComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  {
    path: 'issuebook',
    component: BookIssueComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  {
    path: 'returnbook',
    component: BookReturnComponent,
    canActivate: [AdminGuard, AuthGuard],
  },
  {
    path: 'requestedbooks',
    component: RequestedBooksComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  // {
  //   path: '',
  //   canActivate: [AuthGuard],
  //   children: [
  //     { path: 'books/:id', component: BookDetailComponent },
  //     {
  //       path: 'createbook',
  //       component: BookCreateComponent,
  //       canActivate: [AdminGuard],
  //     },
  //   ],
  // },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      onSameUrlNavigation: 'reload',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
