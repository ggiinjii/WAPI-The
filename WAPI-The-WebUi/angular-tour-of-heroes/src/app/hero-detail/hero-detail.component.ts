import { Component, OnInit , Input} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HeroService } from '../Services/hero.service';
import { Hero } from '../Models/hero';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {

@Input () myHero?:Hero;


  constructor(private route:ActivatedRoute,
              private heroService: HeroService,
              private location: Location) { }
  ngOnInit(): void {
    this.getHero();
  }

  getHero(): void{
    const id= Number (this.route.snapshot.paramMap.get('id'));

    this.heroService.getHero(id).subscribe(hero=>this.myHero=hero)
  }
  goBack(): void 
  {
    this.location.back();
  }

  save(): void {
    if (this.myHero) {
      this.heroService.updateHero(this.myHero)
        .subscribe(() => this.goBack());
    }
  }

}
