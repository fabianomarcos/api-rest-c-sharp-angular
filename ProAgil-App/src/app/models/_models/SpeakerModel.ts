import { SocialNetworkModel } from './SocialNetworkModel';

export class SpeakerModel {
  id: number;
  name: string;
  miniCurriculum: string;
  imageUrl: string;
  phone: string;
  email: string;
  socialNetwork: SocialNetworkModel[];
  eventSpeakers: Event[];
}
