import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { InstitutionalComponent } from './institutional/institutional.component';
import { ActivitiesComponent } from './activities/activities.component';
import { ContributeComponent } from './contribute/contribute.component';
import { ContactComponent } from './contact/contact.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'institutional', component: InstitutionalComponent },
  { path: 'activities', component: ActivitiesComponent },
  { path: 'contribute', component: ContributeComponent },
  { path: 'contact', component: ContactComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
