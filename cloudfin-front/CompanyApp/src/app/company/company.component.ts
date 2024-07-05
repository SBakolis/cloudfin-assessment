import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { CompanyService, Company } from '../company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
  ],
})
export class CompanyComponent {
  companies: Company[] = [];
  newCompany: Company = { code: '', address: '', description: '' };
  displayedColumns: string[] = ['code', 'address', 'description', 'actions'];
  isEditMode = false;

  constructor(private companyService: CompanyService) {
    this.loadCompanies();
  }

  loadCompanies(): void {
    this.companyService.getCompanies().subscribe((companies) => {
      this.companies = companies;
    });
  }

  editCompany(company: Company): void {
    this.newCompany = { ...company };
    this.isEditMode = true;
  }

  addOrUpdateCompany(): void {
    if (this.isEditMode) {
      this.companyService.updateCompany(this.newCompany).subscribe(() => {
        this.loadCompanies();
        this.resetForm();
      });
    } else {
      this.companyService.addCompany(this.newCompany).subscribe(() => {
        this.loadCompanies();
        this.resetForm();
      });
    }
  }

  deleteCompany(code: string): void {
    this.companyService.deleteCompany(code).subscribe(() => {
      this.loadCompanies();
    });
  }

  resetForm(): void {
    this.newCompany = { code: '', address: '', description: '' };
    this.isEditMode = false;
  }
}
