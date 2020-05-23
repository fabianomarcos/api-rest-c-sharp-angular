import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/_models/EventModel';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal';
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
  eventsFiltered: EventModel[];
  imageHeight = 50;
  imageMargim = 2;
  showImage = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;

  listFiltrared: string;

  constructor(
    private eventService: EventService,
    private formBuilder: FormBuilder,
    private localeService: BsLocaleService,
    private modalService: BsModalService
  ) {
    this.localeService.use('pt-br');
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

  ngOnInit() {
    this.getEvents();
    this.validation();
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

  saveForm() {}

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
      amountPeoples: ['', [Validators.required, Validators.max(1000)]],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
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
