import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Hero } from '../Models/hero';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const heroes = [
      { id: 12, name: 'Froppy', alter: "Grenouille" },
      { id: 13, name: 'Ingenium' , alter: "Engine"},
      { id: 14, name: 'Uravity' , alter: "Gravité Zéro"},
      { id: 15, name: 'Tsukuyomi' , alter: "Dark Shadow"},
      { id: 16, name: 'Shoto', alter: "Glace&Feu" },
      { id: 17, name: 'Dynamight' , alter: "Explosion"},
      { id: 18, name: 'Deku' , alter: "One For All"},
      { id: 19, name: 'Invisible Girl' , alter: "Invisibilité"},
      { id: 20, name: 'Grape Juice' , alter: "Boing Boing"}
    ];
    return {heroes};
  }

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (11).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId(heroes: Hero[]): number {
    return heroes.length > 0 ? Math.max(...heroes.map(hero => hero.id)) + 1 : 11;
  }
}