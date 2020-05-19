import { SocialNetwork } from './Socialnetwork';
import { Speaker } from './Speaker';
import { Lot } from './Lot';
import { BaseResourceModel } from './base-resource.model';

export class Event extends BaseResourceModel {
  constructor(
    id: number,
    locale: string,
    dateEvent: Date,
    theme: string,
    amountPeoples: number,
    imageURL: string,
    phone: string,
    email: string,

    lots: Lot[],
    socialNetworks: SocialNetwork[],
    eventSpeakers: Speaker[]
  ) {
    super();
  }
}
