import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './text-input/text-input.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


@NgModule({
  declarations: [
    TextInputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    TextInputComponent,
    HttpClientModule,
    BsDropdownModule,
  ]
})
export class SharedModule { }
