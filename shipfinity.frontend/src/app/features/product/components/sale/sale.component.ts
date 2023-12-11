import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import Product from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.css'],
})
export class SaleComponent implements OnInit {
  public productsOnSale: Product[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.productService.getProductsOnSale();
    this.productService.saleProducts$.subscribe((products: Product[]) => {
      this.productsOnSale = products;
    });
  }

  onCardClick(productId: number) {
    this.router.navigate(['/product', productId]);
  }
}
