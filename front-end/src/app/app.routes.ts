import { Routes } from '@angular/router';
import { SalesDatePredictionViewComponent } from './Pages/sales-date-prediction-view/sales-date-prediction-view.component';
import { OrdersViewComponent } from './Pages/orders-view/orders-view.component';

export const routes: Routes = [
    { path: '', component: SalesDatePredictionViewComponent },
    { path: 'order/:client_id/:client_name', component: OrdersViewComponent }
];
