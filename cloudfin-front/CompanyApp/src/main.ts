import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { CompanyService } from './app/company.service';

bootstrapApplication(AppComponent, {
  providers: [provideHttpClient(), CompanyService],
}).catch((err) => console.error(err));
