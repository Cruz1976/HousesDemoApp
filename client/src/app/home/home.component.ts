import { Component, OnInit } from '@angular/core';
import { Agreement } from '../shared/Models/agreement';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

 agreements: Agreement[]= [];
 agreement: Agreement | undefined;
  constructor(private homeservices: HomeService) { }

  ngOnInit(): void {
   this.homeservices.getAgreements().subscribe(results => {
    this.agreements = results;
    if(this.agreements.length > 0) {
      this.agreement = this.agreements[0];
    }
    console.log(this.agreements);
   })
  }
  selectedAgreement(agreement: Agreement) {
    this.agreement =  agreement;
  }

}
