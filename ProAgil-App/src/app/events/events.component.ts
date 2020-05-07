import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  public events: any = [];

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.httpClient.get('http://localhost:5000/api/values').subscribe(response => {
      this.events = response;
    },
    error => {
      console.log(error);
    });
  }
}
