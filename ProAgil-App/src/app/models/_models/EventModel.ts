import { SocialNetwork } from '../Socialnetwork';
import { Speaker } from '../Speaker';
import { LotModel } from './LotModel';

export class EventModel {
  id: number;
  locale: string;
  dateEvent: Date;
  theme: string;
  amountPeoples: number;
  imageURL: string;
  phone: string;
  email: string;

  lots: LotModel[];
  socialNetworks: SocialNetwork[];
  eventSpeakers: Speaker[];
}
