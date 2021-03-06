import * as Raven from 'raven-js';
import { ErrorHandler, Inject, NgZone, isDevMode } from "@angular/core";
import { ToastyService } from "ng2-toasty";

export class AppErrorHandler implements ErrorHandler {
    constructor(
        @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService){}

    handleError(error: any): void {
        if (!isDevMode())
            Raven.captureException(error.originalError || error);
        else
            throw error;

        this.ngZone.run(() => {
            if (typeof(window) !== 'undefined') {
                this.toastyService.error({
                    title: 'Error',
                    msg: 'An unexpected error happened',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }
        });
    }
    
}