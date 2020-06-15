import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/_models/EventModel';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css'],
})
export class EventsComponent implements OnInit {
  events: EventModel[];
  event: EventModel;
  crud = 'postEvent';
  eventsFiltered: EventModel[];
  imageHeight = 50;
  imageMargim = 2;
  showImage = false;
  registerForm: FormGroup;
  bodyDeleteEvent = '';
  listFiltrared: string;

  constructor(
    private eventService: EventService,
    private formBuilder: FormBuilder,
    private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.getEvents();
    this.validation();
  }

  get filterList(): string {
    return this.listFiltrared;
  }

  set filterList(value: string) {
    this.listFiltrared = value;
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

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  validation() {
    this.registerForm = this.formBuilder.group({
      theme: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      locale: ['', Validators.required],
      dateEvent: ['', Validators.required],
      imageUrl: ['', Validators.required],
      amountPeople: ['', [Validators.required, Validators.max(1000)]],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  newEvent(template: any) {
    this.crud = 'post';
    this.openModal(template);
  }

  setUpdateEventInModal(event: EventModel, template: any) {
    this.crud = 'update';
    this.openModal(template);
    this.event = event;
    this.registerForm.patchValue(event);
  }

  setDeleteEventInModal(event: EventModel, template: any) {
    this.openModal(template);
    this.event = event;
    this.bodyDeleteEvent = `Tem certeza que deseja excluir o Evento: ${event.theme}`;
  }

  createEvent(template: any) {
    this.event = Object.assign({}, this.registerForm.value);
    this.eventService.create(this.event).subscribe(
      () => {
        template.hide();
        this.getEvents();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateEvent(template: any) {
    this.event = Object.assign({ id: this.event.id }, this.registerForm.value);
    this.eventService.update(this.event).subscribe(
      () => {
        template.hide();
        this.getEvents();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteEvent(template: any) {
    this.eventService.delete(this.event.id).subscribe(
      () => {
        template.hide();
        this.getEvents();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  saveForm(template: any) {
    if (this.registerForm.valid) {
      if (this.crud === 'post') {
        this.createEvent(template);
      } else {
        this.updateEvent(template);
      }
    }
  }
}
