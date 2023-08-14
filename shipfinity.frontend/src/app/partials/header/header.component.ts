import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ShoppingCartService } from 'src/app/shared/services/shopping-cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  cartItems:number = 1;

  constructor(private shoppingCartService: ShoppingCartService, private router: Router){}

  ngOnInit() {
    this.shoppingCartService.getCart().subscribe(res => {
      this.cartItems = res.length;
    });
  }

  searchClickEvent(searchForm:any) {
    let keyword = searchForm.form.controls.search.value;
    searchForm.reset();
    this.router.navigate(['/search'],
    {queryParams: {
      search: keyword
    }});
  }
}
