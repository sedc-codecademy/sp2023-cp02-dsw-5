import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SearchService } from 'src/app/shared/services/search.service';
import Product from '../../../../shared/models/product';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  keyword: string = '';
  results: Product[] = [];

  constructor(
    private route: ActivatedRoute,
    private searchService: SearchService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.keyword = params['search'];
      this.searchProducts();
    });
  }

  private searchProducts() {
    this.searchService.searchProducts(this.keyword).subscribe(
      (data) => (this.results = data),
      (error) => console.error(error)
    );
  }
}
