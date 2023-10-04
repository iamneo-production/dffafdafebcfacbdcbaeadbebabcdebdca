import { Position } from "./position";

export interface Player {
    id: number;
    shirtno: number;
    name: string;
    positionid?: number;
    appearances?: number;
    goals?: number;
    position?: Position;
  }