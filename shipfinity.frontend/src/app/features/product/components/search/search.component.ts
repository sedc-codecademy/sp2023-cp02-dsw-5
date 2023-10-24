import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Product from '../../../../shared/models/product';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  keyword: string = "";
  results: Product[] = [];

  constructor(private route: ActivatedRoute){}

  ngOnInit(){
    this.route.queryParams
      .subscribe(params => {
        this.keyword = params['search'];
      });
  }
}
