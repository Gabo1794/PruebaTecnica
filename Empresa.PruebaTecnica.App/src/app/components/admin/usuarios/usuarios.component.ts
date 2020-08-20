import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { Router } from '@angular/router';
import { UsuariosService } from '../../../services/usuarios.service';
import { modeloUsuarioI } from '../../../models/modeloUsuario.interface';
import { NzMessageService } from 'ng-zorro-antd/message';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuariosModel: modeloUsuarioI[] = [];
  displayedColumns: string[] = [];
  dataSource: any;
  isLoadingOne = false;
  isLoadingTwo = false;

  
  constructor( private usuarioSvc: UsuariosService, private _router:Router, private message: NzMessageService) {}
  
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;  

  async ngOnInit() {
    await this.usuarioSvc.ObtenerUsuarios().subscribe(usuarios => {
      this.displayedColumns = ['Id', 'Usuario', 'Correo', 'Sexo', 'Estatus', 'Acciones'];
      this.dataSource = new MatTableDataSource<modeloUsuarioI>(usuarios);
      this.dataSource.paginator = this.paginator;
    });
  }

  async DesactivarUsuario(id:any): void{
    await this.usuarioSvc.DesactivarUsuario(id).subscribe(estatus => {
      if(estatus){
        this.usuarioSvc.ObtenerUsuarios().subscribe(usuarios => {
          this.displayedColumns = ['Id', 'Usuario', 'Correo', 'Sexo', 'Estatus', 'Acciones'];
          this.dataSource = new MatTableDataSource<modeloUsuarioI>(usuarios);
          this.dataSource.paginator = this.paginator;
        });
      }else{
        this.message.create('error', 'Error al tratar de desactivar.');
      }
    });
  }

  Salir(): void {
    this.isLoadingTwo = true;
    setTimeout(() => {
      this._router.navigate(['./']);
      this.isLoadingTwo = false;
    }, 5000);
  }
  
  async LeerUsuario(id: any) {
    this._router.navigate(['/usuario',id]);
  }

  
}