import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Player } from "./player";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiURL = "https://localhost:7028/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getPlayers(): Observable<Player[]> {
    return this.httpClient.get<Player[]>(this.apiURL + '/players')
      .pipe(
        catchError(this.errorHandler.bind(this))
      );
  }

  getPlayer(id: number): Observable<Player> {
    return this.httpClient.get<Player>(this.apiURL + '/players/' + id)
      .pipe(
        catchError(this.errorHandler.bind(this))
      );
  }

  createPlayer(player: Player): Observable<Player> {

    // Create the player object with the expected structure
    const newPlayer = {
      id: player.id,
      shirtno: player.shirtno,
      name: player.name,
      positionid: player.positionid,
      appearances: player.appearances,
      goals: player.goals,
      position: {
        id: player.position?.id,
        name: player.position?.name,
        displayOrder: player.position?.displayOrder
      }
    };

    // Log the player object before sending the request
    console.log("Creating Player:", newPlayer);

    return this.httpClient
      .post<Player>(`${this.apiURL}/players/`, newPlayer, this.httpOptions)
      .pipe(catchError(this.errorHandler.bind(this)));
  }

  updatePlayer(id: number, player: Player): Observable<Player> {
    return this.httpClient.put<Player>(this.apiURL + '/players/' + id, JSON.stringify(player), this.httpOptions)
      .pipe(
        catchError(this.errorHandler.bind(this))
      );
  }

  deletePlayer(id: number): Observable<Player> {
    return this.httpClient.delete<Player>(this.apiURL + '/players/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler.bind(this))
      );
  }

  errorHandler(error: HttpErrorResponse): Observable<never> {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}\nError Response: ${JSON.stringify(error.error)}`;
    }
    console.error(errorMessage); // Log the error
    return throwError(errorMessage);
  }
}
