import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';

import {
  MatButtonModule,
  MatFormFieldModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatSelectModule,
  MatSidenavModule,
  MatCardModule,
  MatTableModule,
  MatTabsModule,
  MatCheckboxModule,
  MatPaginatorModule,
  MatRadioModule
} from "@angular/material";

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgZorroAntdModule, NZ_I18N, en_US, NzButtonModule, NzFormModule,NzAlertModule, NzLayoutModule, NzMessageModule  } from 'ng-zorro-antd';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { UsuariosComponent } from './components/admin/usuarios/usuarios.component';

import { APP_ROUTING } from './app.routes';
import { UsuarioComponent } from './components/admin/usuario/usuario.component';


registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsuariosComponent,
    UsuarioComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MatInputModule,
    MatCardModule,
    MatTabsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatTableModule,
    MatListModule,
    MatSelectModule,
    MatSidenavModule,
    NgZorroAntdModule,
    HttpClientModule,
    NzButtonModule,
    MatPaginatorModule,
    APP_ROUTING,
    NzAlertModule,
    NzLayoutModule,
    NzIconModule ,
    NzMessageModule,
    MatRadioModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
