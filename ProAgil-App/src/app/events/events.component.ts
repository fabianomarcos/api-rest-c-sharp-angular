import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/_models/EventModel';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css'],
})
export class EventsComponent implements OnInit {
  events: EventModel[];
  eventsFiltered: EventModel[];
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

  filterEvents(name: string): EventModel[] {
    name = name.toLowerCase();
    return this.events.filter(
      (event) => event.theme.toLowerCase().indexOf(name) !== -1
    );
  }

  setShowImage() {
    this.showImage = !this.showImage;
  }

  getEvents() {
    this.eventService.getAllResources().subscribe(
      (events: EventModel[]) => {
        this.events = events;
        this.eventsFiltered = this.events;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
