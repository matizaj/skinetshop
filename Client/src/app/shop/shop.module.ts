import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { PaginationHeaderComponent } from '../shared/components/pagination-header/pagination-header.component';



@NgModule({
  declarations: [ShopComponent, ProductItemComponent],
  imports: [
    CommonModule, SharedModule
  ],
  exports: [ShopComponent, ProductItemComponent]
})
export class ShopModule { }
