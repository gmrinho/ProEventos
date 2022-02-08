import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventosFiltrados: any = [];

  public eventos: any = [];
  widthImg = 150;
  marginImg = 2;
  mostrarImg = true;
  private _filtroLista = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
    (evento: { tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }
  alterarImg(){
    this.mostrarImg = !this.mostrarImg;
  }
  public getEventos(): void {
    this.http.get('https://localhost:5001/api/evento').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }

}
