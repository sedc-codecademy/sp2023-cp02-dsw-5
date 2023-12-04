import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Category } from '../../../../shared/models/enums';
import Product from '../../../../shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit, OnDestroy {
  id: number = 0;
  category$ = this.categoryService.currentCategory$;
  productList$ = this.productService.productList$;
  routerEventSubscription: Subscription;

  constructor(private route: ActivatedRoute, private router: Router, private productService: ProductService, private categoryService: CategoryService){}
  
  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));
    this.id = idFromRoute;
    this.categoryService.getById(idFromRoute);
    this.productService.GetByCategory(idFromRoute);
    
    this.routerEventSubscription = this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd){
        this.id = Number(this.route.snapshot.paramMap.get('id'));
        this.categoryService.getById(this.id);
        this.productService.GetByCategory(this.id);
      }
    });
  }

  ngOnDestroy(): void {
    if(this.routerEventSubscription)
      this.routerEventSubscription.unsubscribe();
  }
}
