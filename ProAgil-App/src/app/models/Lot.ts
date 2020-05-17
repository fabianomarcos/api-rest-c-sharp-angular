import { BaseResourceModel } from './base-resource.model';

export class Lot extends BaseResourceModel {
  constructor(
    id: number,
    name: string,
    price: number,
    initialDate?: Date,
    finalDate?: Date,
    amount?: number,
    eventId?: number
  ) {
    super();
  }
}
