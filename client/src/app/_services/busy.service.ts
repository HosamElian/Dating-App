import { Injectable } from '@angular/core';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequsetCount = 0;
  constructor(private spinnerService: NgxSpinnerService) { }

  busy(){
    this.busyRequsetCount++;
    this.spinnerService.show(undefined, {
      type: 'line-scale-party',
      bdColor: 'rgba(255,255,255,0)',
      color:'#333333'
    })
  }

  idle(){
    this.busyRequsetCount --;
    if(this.busyRequsetCount <= 0){
      this.busyRequsetCount = 0;
      this.spinnerService.hide();
    }
  }
}
