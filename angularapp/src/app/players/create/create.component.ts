import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Position } from "../position";
import { PlayersService } from "../players.service";
import { PositionsService } from "../positions.service";
import { Player } from '../player';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  positions: Position[] = [];
  createForm;

  constructor(
    public playersService: PlayersService,
    public positionsService: PositionsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      shirtno: ['', Validators.required],
      name: ['', Validators.required],
      positionid: [''],
      appearances: [''],
      goals: [''],
    });
  }

  ngOnInit(): void {
    this.positionsService.getPositions().subscribe((data: Position[]) => {
      this.positions = data;
    });
  }

  onSubmit(formData: FormGroup) {

    const playerData = formData.value;
  // Get the selected positionId from the form value
  const selectedPositionId = playerData.positionid;

  // Create a player object with the selected positionId
  const newPlayer: Player = {
    id: playerData.id,
    shirtno: playerData.shirtno,
    name: playerData.name,
    positionid: selectedPositionId, // Assign the selected positionId
    appearances: playerData.appearances,
    goals: playerData.goals,
    position: {
      id: selectedPositionId, // Assign the selected positionId
      name: '', // You can populate the name and displayOrder as needed
      displayOrder: 1
    }
  };

  this.playersService.createPlayer(newPlayer).subscribe(res => {
    this.router.navigateByUrl('players/list');
  });
    // this.playersService.createPlayer(formData.value).subscribe(res => {
    //   this.router.navigateByUrl('players/list');
    // });
  }
}