import { Component, OnInit } from '@angular/core';
import { RequestService } from '../../_services';
import { ActivatedRoute } from '@angular/router';
import { ToastService } from '../../_services/toast.service';

@Component({
  selector: 'app-request-delete',
  templateUrl: './request-delete.component.html',
  styleUrls: ['./request-delete.component.less']
})
export class RequestDeleteComponent implements OnInit {

    requestId: number;
    disableSubmitButton = false;

    constructor(private requestService: RequestService, private route: ActivatedRoute, private toastService: ToastService) { }

    ngOnInit() {
        const param = this.route.snapshot.paramMap.get('id');

        if (param) {
            const id = +param;
            this.requestId = id;
        }
    }

    submit() {
        this.disableSubmitButton = true;

        this.requestService.deleteRequest(this.requestId).subscribe({
            next: r => {
                this.toastService.Success('Usunięto zgłoszenie').subscribe({
                    complete: () => location.href = '/#/requests',
                });
            },
            error: e => {
                this.toastService.Error('Błąd przy usuwaniu zgłoszenia. ' + e);
                this.disableSubmitButton = false;
            }
        });
    }
}
