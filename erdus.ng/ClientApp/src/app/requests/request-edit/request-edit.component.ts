import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RequestService } from '../../_services';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastService } from '../../_services/toast.service';
import { RequestDetails } from '../interfaces/request-details';
import { CategoryService } from '../../_services/category.service';
import { Category } from '../interfaces/Category';

@Component({
  selector: 'app-request-edit',
  templateUrl: './request-edit.component.html',
  styleUrls: ['./request-edit.component.less']
})
export class RequestEditComponent implements OnInit {

    requestForm: FormGroup;
    fileData: File = null;
    submitted = false;
    disableSubmitButton = false;
    coordinatesList: Coordinates[] = [];
    request: RequestDetails;
    errorMessage = 'Błąd ładowania szczegółów';
    requestId;
    categories: Category[];

    constructor(private formBuilder: FormBuilder, private requestService: RequestService, private router: Router, private toastService: ToastService, private route: ActivatedRoute, private categoryService: CategoryService) { }

    ngOnInit() {

        const param = this.route.snapshot.paramMap.get('id');

        if (param) {
            const id = +param;
            this.requestId = id;
        }
    }

    get requestF() { return this.requestForm.controls; }

    newCoorinatesSelected(coordinates: Coordinates) {
        this.requestForm.controls['location'].setValue(coordinates.longitude.toPrecision(8) + ', ' + coordinates.latitude.toPrecision(8));
    }

    fileProgress(fileInput: any) {
        this.fileData = <File>fileInput.target.files[0];
    }

    mapInitialized() {
        this.getRequest(this.requestId);
        this.getCategoryList();
    }

    getCategoryList() {
        this.categoryService.getAllCategories().subscribe({
            next: categories => {
                this.categories = categories;
            },
            error: err => {
                this.errorMessage = err;
            }
        })
    }

    getRequest(id: number) {
        this.requestService.getRequestById(id).subscribe({
            next: request => {
                
                this.coordinatesList = [{
                    longitude: request.longitude,
                    latitude: request.latitude,
                    accuracy: 0,
                    altitude: 0,
                    altitudeAccuracy: 0,
                    heading: 0,
                    speed: 0
                }];

                this.request = request;

                this.requestForm = this.formBuilder.group({
                    file: [""],
                    content: [this.request.content, Validators.required],
                    address: [this.request.address, Validators.required],
                    location: [this.request.location, Validators.required],
                    category: [this.request.categoryId, Validators.required]
                });
            },
            error: err => this.errorMessage = err
        });
    }

    onSubmit() {
        this.submitted = true;

        if (this.requestForm.invalid) {
            return;
        }

        this.requestForm.disable();
        this.disableSubmitButton = true;

        this.requestService.editRequest({
            id: this.requestId,
            file: this.fileData,
            address: this.requestForm.controls['address'].value,
            content: this.requestForm.controls['content'].value,
            location: this.requestForm.controls['location'].value,
            categoryId: this.requestForm.controls['category'].value
        }).subscribe({
            next: r => {
                this.toastService.Success('Zmieniono zgłoszenie').subscribe({
                    complete: () => location.href = '/#/requests',
                });
            },
            error: e => {
                this.toastService.Error('Błąd przy zapisywaniu zgłoszenia. ' + e);
                this.requestForm.enable();
                this.disableSubmitButton = false;
            }
        });
    }

}
