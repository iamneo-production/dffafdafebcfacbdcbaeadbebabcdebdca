import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Player } from "../player";
import { Position } from "../position";
import { PlayersService } from "../players.service";
import { PositionsService } from "../positions.service";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id!: number;
  player!: Player;
  positions: Position[] = [];
  editForm;

  constructor(
    public playersService: PlayersService,
    public positionsService: PositionsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      id: [''],
      shirtno: ['', Validators.required],
      name: ['', Validators.required],
      positionid: [''],
      appearances: [''],
      goals: [''],
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['playerId'];

    this.positionsService.getPositions().subscribe((data: Position[]) => {
      this.positions = data;
    });

    this.playersService.getPlayer(this.id).subscribe((data: Player) => {
      this.player = data;
      this.editForm.patchValue({
        id: String(data.id), // Cast to string
        shirtno: String(data.shirtno),
        name: data.name,
        positionid: String(data.positionid),
        appearances: String(data.appearances),
        goals: String(data.goals),

      });

    });
  }

  onSubmit(formData: FormGroup) {
    const playerDatas = formData.value;
    const selectedPositionId = playerDatas.positionid;

    const playerData: Player = {
      id: formData.value.id,
      shirtno: formData.value.shirtno,
      name: formData.value.name,
      positionid: formData.value.positionid,
      appearances: formData.value.appearances,
      goals: formData.value.goals,
      position: {
        id: selectedPositionId,
        name: '', // You can populate the name as needed
        displayOrder: 1 // You can set the displayOrder as needed
      }
    };

    this.playersService.updatePlayer(this.id, playerData).subscribe(res => {
      this.router.navigateByUrl('players/list');
    });

    console.log(formData.value);
  //   this.playersService.updatePlayer(this.id, formData.value).subscribe(res => {
  //     this.router.navigateByUrl('players/list');
  //   });
   }
}