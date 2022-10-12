import { Component, OnInit } from '@angular/core';
import { MessageService } from '../Services/messages.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  constructor(protected messageService: MessageService) { }

  ngOnInit(): void {
    
  }

}
