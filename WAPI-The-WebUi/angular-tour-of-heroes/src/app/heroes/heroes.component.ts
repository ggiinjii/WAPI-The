import { Component, OnInit } from '@angular/core';
import { Hero } from '../Models/hero';
import { HeroService } from '../Services/hero.service';
import { MessageService } from '../Services/messages.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {

  selectedHero?: Hero;

  heroes:Hero[]=[];

  constructor(private heroService: HeroService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getHeroes();
  }
  
  getHeroes():void{
    this.heroService.getHeroes().subscribe(heroes=>this.heroes=heroes);
  }

  add(name: string, alter: string): void {
    name = name.trim();
    alter= alter.trim();
    if (!name) { return; }
    this.heroService.addHero({ name,alter } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }
  
  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id).subscribe();
  }
  

}
