import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Category } from '../../../../shared/models/enums';
import Product from '../../../../shared/models/product';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent {
  id: number = 0;
  categoryName: string = '';
  productList: Product[] = [
    new Product(1, "Smart light", "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Vel recusandae ullam quae ex. Consectetur, molestias officia. Incidunt, possimus aspernatur. Impedit?", 25, 1, 20, 4),
    new Product(2, "Smart light2", "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Vel recusandae ullam quae ex. Consectetur, molestias officia. Incidunt, possimus aspernatur. Impedit?", 22, 1)
  ];

  constructor(private route: ActivatedRoute, private router: Router){}

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));
    this.id = idFromRoute;
    this.categoryName = Category[idFromRoute];
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd){
        this.id = Number(this.route.snapshot.paramMap.get('id'));
        this.categoryName = Category[this.id];
      }
    });
  }
}
