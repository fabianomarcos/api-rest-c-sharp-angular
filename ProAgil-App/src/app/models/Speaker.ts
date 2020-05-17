import { SocialNetwork } from './Socialnetwork';
import { Event } from './Event';
import { BaseResourceModel } from './base-resource.model';

export class Speaker extends BaseResourceModel {
  constructor(
    id: number,
    name: string,
    miniCurriculum: string,
    imageUrl: string,
    phone: string,
    email: string,

    socialNetwork: SocialNetwork[],
    eventSpeakers: Event[]
  ) {
    super();
  }
}
