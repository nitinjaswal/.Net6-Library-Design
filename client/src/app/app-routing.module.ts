import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BookCreateComponent } from './books/book-create/book-create.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: BooksListComponent, pathMatch: 'full' },
  { path: 'books', component: BooksListComponent, pathMatch: 'full' },
  {
    path: 'books/:id',
    component: BookDetailComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'createbook',
    component: BookCreateComponent,
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
