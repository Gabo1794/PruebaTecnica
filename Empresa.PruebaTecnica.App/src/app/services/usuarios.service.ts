import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { modeloUsuarioI } from '../models/modeloUsuario.interface';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private url: string  = "https://localhost:44314/api/usuario/";
  constructor(private http: HttpClient) { }

  ObtenerUsuarios():Observable<modeloUsuarioI[]> {
    const url = this.url;
    return this.http.get<modeloUsuarioI[]>(url);
  }

  DesactivarUsuario(id:any):Observable<boolean>{
    const url = `${this.url}${id}`;
    return this.http.delete<boolean>(url);
  }

  CrearUsuario(usuario: modeloUsuarioI):Observable<boolean>{
    return this.http.post<boolean>(this.url, usuario);
  }

  LeerUsuario(id:any):Observable<modeloUsuarioI>{
    return this.http.get<modeloUsuarioI>(`${this.url}${id}`);
  }
}
