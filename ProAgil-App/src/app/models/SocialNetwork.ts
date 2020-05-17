import { BaseResourceModel } from './base-resource.model';

export class SocialNetwork extends BaseResourceModel {
  constructor(
    id: number,
    name: string,
    url: string,
    eventId?: number,
    speakerId?: number
  ) {
    super();
  }
}
