import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//application
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Products } from './views/product/products';
import { Customers } from './views/customer/customers';
import { Orders } from './views/order/orders';
import { ServiceLocationService } from './services/service-location-service';
import { ProductServiceService } from './services/product-service.service';
import { ErrorHandler } from './helpers/error-handler';
import { CustomerServiceService } from './services/customer-service.service';
import { ProductComponent } from './components/product/product.component';
import { CustomerComponent } from './components/customer/customer.component';

//Third party imports
import { InputTextModule } from 'primeng/inputtext';
import { AutoCompleteModule } from "primeng/autocomplete";

import { TabViewModule } from 'primeng/tabview';
import { DropdownModule } from 'primeng/dropdown';
import { FieldsetModule } from 'primeng/fieldset';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { PasswordModule } from 'primeng/password';
import { ToastModule } from 'primeng/toast';
import { PickListModule } from 'primeng/picklist';
import { InputMaskModule } from 'primeng/inputmask';
import { ListboxModule } from 'primeng/listbox';
import { MenuModule } from 'primeng/menu';
import { CalendarModule } from 'primeng/calendar';
import { SpinnerModule } from 'primeng/spinner';
import { RippleModule } from 'primeng/ripple';
import {MessageService} from 'primeng/api';


@NgModule({
  declarations: [
    AppComponent,
    Customers,
    Products,
    Orders,
    ProductComponent,
    CustomerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    InputTextModule,
    AutoCompleteModule,
    TabViewModule,
    DropdownModule,
    FieldsetModule,
    ButtonModule,
    CheckboxModule,
    TableModule,
    DialogModule,
    PasswordModule,
    ToastModule,
    PickListModule,
    InputMaskModule,
    ListboxModule,
    MenuModule,
    CalendarModule,
    SpinnerModule,
    RippleModule,
    AppRoutingModule
  ],
  providers: [
    MessageService,
    ServiceLocationService,
    ProductServiceService,
    CustomerServiceService,
    ErrorHandler
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
