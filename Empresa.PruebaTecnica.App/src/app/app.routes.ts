import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { UsuariosComponent } from './components/admin/usuarios/usuarios.component';
import { UsuarioComponent } from './components/admin/usuario/usuario.component';
import { UsuariosService } from './services/usuarios.service';


const APP_ROUTES: Routes = [
    { path: './', component: LoginComponent },
    { path: 'usuarios', component: UsuariosComponent },
    { path: 'usuario/:id', component: UsuarioComponent },
    { path: '**', pathMatch: 'full', redirectTo: './' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);