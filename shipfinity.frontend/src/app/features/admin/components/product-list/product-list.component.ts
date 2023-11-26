import { Component } from '@angular/core';
import Product from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  public products: Product[] = [ new Product(1, "test", "Test", 12, 1) ];
}
