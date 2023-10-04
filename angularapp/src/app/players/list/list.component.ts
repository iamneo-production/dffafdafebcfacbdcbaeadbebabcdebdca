import { Component, OnInit } from '@angular/core';
import { Player } from "../player";
import { PlayersService } from "../players.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{
  players: Player[] = [];

  constructor(public playersService: PlayersService) { }

  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    this.playersService.getPlayers().subscribe((data: Player[]) => {
      this.players = data;
       // Log shirtNo values to the console
       this.players.forEach(player => {
        console.log('Shirt No:', player.shirtno);
        console.log('Goals No:', player.goals);
        console.log('Position No:', player.positionid);
        console.log('ID Position No:', player.position?.id);
      });
    });
  }
  deletePlayer(id: number ) {
    this.playersService.deletePlayer(id).subscribe(res => {
      this.players = this.players.filter(item => item.id !== id);
    });
  }

}
