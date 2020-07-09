import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarRef, SimpleSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

    constructor(private snackBar: MatSnackBar) { }

    toastDurationMs: number = 3000;

    Success(message: string): Observable<void> {
        this.snackBar.open(message, '', { duration: this.toastDurationMs, panelClass: ['snack-bar-success'] });

        return new Observable<void>(observer => {
            setTimeout(() => {
                observer.next();
                observer.complete();
            }, this.toastDurationMs)

        })
    }

    Error(message: string): void {
        this.snackBar.open(message, '', { duration: this.toastDurationMs, panelClass: ['snack-bar-alert'] })        
    }
}
