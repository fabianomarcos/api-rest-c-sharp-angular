import { Injectable, Injector } from '@angular/core';

import { Event } from './../models/Event';

import { BaseResourceService } from './base-resource.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EventService extends BaseResourceService<Event> {
  constructor(protected injector: Injector) {
    super(`${environment.baseUrl}/event`, injector);
  }
}
