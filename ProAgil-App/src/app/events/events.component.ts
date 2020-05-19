import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/_models/EventModel';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal';

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
  modalRef: BsModalRef;

  // tslint:disable-next-line: variable-name
  _filterList: string;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService
  ) {}

  get filterList(): string {
    return this._filterList;
  }

  set filterList(value: string) {
    this._filterList = value;
    this.eventsFiltered = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }


  ngOnInit() {
    this.getEvents();
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
