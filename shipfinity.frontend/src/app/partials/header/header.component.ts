import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';
import { CategoryService } from 'src/app/shared/services/category.service';
import { ShoppingCartService } from 'src/app/shared/services/shopping-cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  cartItems:number = 1;
  isLoggedIn = false;
  user$ = this.auth.currentUser$;
  categories$ = this.categoryService.categoryList$;
  constructor(private shoppingCartService: ShoppingCartService, private router: Router, private auth: AuthService, private categoryService: CategoryService){}

  ngOnInit() {
    this.shoppingCartService.getCart().subscribe(res => {
      this.cartItems = res.length;
    });
    this.isLoggedIn = this.auth.isLoggedIn;
    this.categoryService.getCategories();
  }

  searchClickEvent(searchForm:any) {
    let keyword = searchForm.form.controls.search.value;
    searchForm.reset();
    this.router.navigate(['/product', 'search'],
    {queryParams: {
      search: keyword
    }});
  }

  logout(event: any) {
    event.preventDefault();
    this.auth.logout();
    this.router.navigate(['/']);
  }
}
