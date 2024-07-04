import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CompanyService, Company } from '../company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule], // Import necessary modules
})
export class CompanyComponent {
  companies: Company[] = [];
  newCompany: Company = { code: '', address: '', description: '' };

  constructor(private companyService: CompanyService) {
    this.loadCompanies();
  }

  loadCompanies(): void {
    this.companyService.getCompanies().subscribe((companies) => {
      this.companies = companies;
    });
  }

  addCompany(): void {
    this.companyService.addCompany(this.newCompany).subscribe(() => {
      this.loadCompanies();
      this.newCompany = { code: '', address: '', description: '' };
    });
  }

  deleteCompany(code: string): void {
    this.companyService.deleteCompany(code).subscribe(() => {
      this.loadCompanies();
    });
  }
}
