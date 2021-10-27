import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';

const routes: Routes = [
  {path: "", component: AdminComponent,
    children: [
      {
          path: '',
          component: DashboardComponent
      },
      {
        path: 'profile',
        loadChildren: () =>
            import('./views/profile/profile.module').then(
                (m) => m.ProfileModule
            )
    },
    {
        path: 'users',
        loadChildren: () =>
            import('./views/users/users.module').then(
                (m) => m.UsersModule
            )
    },
    {
      path: 'restaurant',
      loadChildren: () =>
          import('./views/restaurant/restaurant.module').then(
              (m) => m.RestaurantModule
          )
   },
    {
      path: 'deliver',
      loadChildren: () =>
          import('./views/deliver/deliver.module').then(
              (m) => m.DeliverModule
          )
   },
    {
      path: 'information-deliver',
      loadChildren: () =>
          import('./views/information-deliver/information-deliver.module').then(
              (m) => m.InformationDeliverModule
          )
   },
    {
      path: 'products',
      loadChildren: () =>
          import('./views/products/products.module').then(
              (m) => m.ProductsModule
          )
   },
    {
      path: 'add-product',
      loadChildren: () =>
          import('./views/add-product/add-product.module').then(
              (m) => m.AddProductModule
          )
   },
    {
      path: 'information-product',
      loadChildren: () =>
          import('./views/information-product/information-product.module').then(
              (m) => m.InformationProductModule
          )
   },
   {
    path: 'category',
    loadChildren: () =>
        import('./views/category/category.module').then(
            (m) => m.CategoryModule
        )
 },
   {
    path: 'orders',
    loadChildren: () =>
        import('./views/orders/orders.module').then(
            (m) => m.OrdersModule
        )
 },
 
   {
    path: 'order-information',
    loadChildren: () =>
        import('./views/order-information/order-information.module').then(
            (m) => m.OrderInformationModule
        )
 },
 
   {
    path: 'situation',
    loadChildren: () =>
        import('./views/situation/situation.module').then(
            (m) => m.SituationModule
        )
 },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
