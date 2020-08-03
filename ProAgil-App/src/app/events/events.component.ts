import { Component, OnInit, ViewChild } from '@angular/core';
import { EventService } from '../services/event.service';
import { EventModel } from '../models/_models/EventModel';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
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
  showImage: boolean;
  showEvents: boolean;
  registerForm: FormGroup;
  bodyDeleteEvent = '';
  @ViewChild('search') search;

  constructor(
    private eventService: EventService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.getEvents();
    this.validation();
  }

  filterEvents() {
    const valueInput = this.search.nativeElement.value.toLowerCase();
    if (!valueInput) {
      return this.getEvents();
    }

    const eventsFiltered = this.events.filter(
      (eventFiltered) => eventFiltered.theme.toLowerCase().includes(valueInput)
    );

    this.showEvents = true;

    return this.events = eventsFiltered;
  }

  setShowImage() {
    this.showImage = !this.showImage;
  }

  getEvents() {
    this.eventService.getAllResources().subscribe(
      (events: EventModel[]) => {
        this.events = events;
        this.showEvents = true;
      },
      (error) => {
        this.toastr.error('Não foi possível carregar os eventos');
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
    template.show();
    this.event = event;
    this.bodyDeleteEvent = `Tem certeza que deseja excluir o Evento: ${event.theme}`;
  }

  createEvent(template: any) {
    this.event = Object.assign({}, this.registerForm.value);
    this.eventService.create(this.event).subscribe(
      () => {
        template.hide();
        this.getEvents();
        this.toastr.success('Evento inserido com sucesso');
      },
      (error) => {
        this.toastr.error('Erro ao tentar inserir evento');
      }
    );
  }

  updateEvent(template: any) {
    this.event = Object.assign({ id: this.event.id }, this.registerForm.value);
    this.eventService.update(this.event).subscribe(
      () => {
        template.hide();
        this.getEvents();
        this.toastr.success('Evento alterado com sucesso');
      },
      (error) => {
        this.toastr.error('Erro ao tentar alterar evento');
      }
    );
  }

  deleteEvent(template: any) {
    this.eventService.delete(this.event.id).subscribe(
      () => {
        template.hide();
        this.getEvents();
        this.toastr.success('Evento deletado com sucesso');
      },
      (error) => {
        this.toastr.error('Não foi possível deletar o evento');
      }
    );
  }

  saveForm(template: any) {
    if (this.registerForm.valid) {
      this.crud === 'post'
        ? this.createEvent(template)
        : this.updateEvent(template);
    }
  }
}
