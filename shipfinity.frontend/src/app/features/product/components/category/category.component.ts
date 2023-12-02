import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Category } from '../../../../shared/models/enums';
import Product from '../../../../shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit, OnDestroy {
  id: number = 0;
  categoryName: string = '';
  productList$ = this.productService.productList$;
  routerEventSubscription: Subscription;

  constructor(private route: ActivatedRoute, private router: Router, private productService: ProductService){}
  
  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));
    this.id = idFromRoute;
    this.categoryName = Category[idFromRoute];
    this.productService.GetByCategory(idFromRoute);
    
    this.routerEventSubscription = this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd){
        this.id = Number(this.route.snapshot.paramMap.get('id'));
        this.categoryName = Category[this.id];
        this.productService.GetByCategory(this.id);
      }
    });
  }

  ngOnDestroy(): void {
    if(this.routerEventSubscription)
      this.routerEventSubscription.unsubscribe();
  }
}
