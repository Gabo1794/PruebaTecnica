import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { UsuariosService } from '../../../services/usuarios.service';
import { LoginI } from '../../../models/login.interface';
import { modeloUsuarioI } from '../../../models/modeloUsuario.interface';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authSvc: AuthService, private _router: Router, private usuarioSvc: UsuariosService) { }
  mostarModalError: boolean = false;
  mensajeError: string = "";

  generos = [
    {value: '1', viewValue: 'Masculino'},
    {value: '2', viewValue: 'Femenino'},
  ]

  ngOnInit() {  }

  ValidarLogin(usuario: LoginI) {
    console.log(usuario);
    this.authSvc.validateLogin(usuario).subscribe(loginExitoso => {
      if(loginExitoso){
        this._router.navigate(['/usuarios']);
        this.mostarModalError = false;
        this.mensajeError = "";
      }
      else
      {
        this.mensajeError = 'El usuario no es valido.';
        this.mostarModalError = true;
      }
    });
  }

  CrearUsuario(usuario: modeloUsuarioI){
    console.log("===>",usuario);

    if(usuario.Contrasena !== usuario.ValidateContrasena){
        this.mensajeError = 'La contraseña no coincide.';
        this.mostarModalError = true;
        return;
    }

    usuario.Estatus = 1;

    this.usuarioSvc.CrearUsuario(usuario).subscribe(creacionExitosa => {
      if(creacionExitosa){
        this._router.navigate(['/usuarios']);
        this.mostarModalError = false;
        this.mensajeError = "";
      }
      else{
        this.mensajeError = 'No fue posible registrar el usuario, es posible que ya se encuentre registrado';
        this.mostarModalError = true;
      }

    });
  }

}
