import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ScoreListComponent } from './score.component';

const routes: Routes = [
  {
    path: '',
    component: ScoreListComponent
  },
];

export const components = [
  ScoreListComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class ScoreRoutes {};
