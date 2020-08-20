import { modeloUsuarioI } from '../../../models/modeloUsuario.interface';
import { UsuariosService } from '../../../services/usuarios.service';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent {

  // usuario: modeloUsuarioI;

  // constructor(private activatedRoute: ActivatedRoute, private usuarioSvc: UsuariosService) { 
  //   this.activatedRoute.params.subscribe( params => { 
  //     this.MostrarInformacionUsuario(params['id']);
  //    })
  //  }

  //  async MostrarInformacionUsuario(id: any) {
  //   await this.usuarioSvc.LeerUsuario(id).subscribe(usuario => {
  //     this.usuario = usuario;
  //   });
  // }

}
