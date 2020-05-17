import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css'],
})
export class EventsComponent implements OnInit {
  events: any = [];
  eventsFiltered: any = [];
  imageHeight = 50;
  imageMargim = 2;
  showImage = false;

  // tslint:disable-next-line: variable-name
  _filterList: string;

  constructor(private eventService: EventService) {}

  ngOnInit() {
    this.getEvents();
  }

  get filterList(): string {
    return this._filterList;
  }

  set filterList(value: string) {
    this._filterList = value;
    this.eventsFiltered = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  filterEvents(name: string): any {
    name = name.toLowerCase();
    return this.events.filter(
      (event) => event.theme.toLowerCase().indexOf(name) !== -1
    );
  }

  setShowImage() {
    this.showImage = !this.showImage;
  }

  getEvents() {
    this.eventService.getResources().subscribe(
      (response) => {
        this.events = response;
        this.eventsFiltered = this.events;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
