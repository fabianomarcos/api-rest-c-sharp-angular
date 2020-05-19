import { Pipe, PipeTransform } from '@angular/core';
import { Constats } from '../util/Constats';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'DateTimeFormat'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constats.DATE_TIME_FMT);
  }

}
