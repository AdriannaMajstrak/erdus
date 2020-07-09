import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { RequestService } from '../../_services';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ToastService } from '../../_services/toast.service';
import { CategoryService } from '../../_services/category.service';
import { Category } from '../interfaces/Category';


@Component({
  selector: 'app-request-create',
  templateUrl: './request-create.component.html',
  styleUrls: ['./request-create.component.less']
})
export class RequestCreateComponent implements OnInit {

    requestForm: FormGroup;
    submitted = false;
    fileData: File = null;    
    disableSubmitButton = false;
    categories: Category[];
    errorMessage: string;

    constructor(private formBuilder: FormBuilder, private requestService: RequestService, private router: Router, private toastService: ToastService, private categoryService: CategoryService) { }

    ngOnInit() {

        this.getCategoryList();

        this.requestForm = this.formBuilder.group({
            topic: ["", Validators.required],
            file: ["", Validators.required],
            content: ["", Validators.required],
            address: ["", Validators.required],
            location: ["", Validators.required],
            category: ["", Validators.required]
        });
    }

    get requestF() { return this.requestForm.controls; }


    newCoorinatesSelected(coordinates: Coordinates) {
        this.requestForm.controls['location'].setValue(coordinates.longitude.toPrecision(8) + ', ' + coordinates.latitude.toPrecision(8));
    }

    fileProgress(fileInput: any) {
        this.fileData = <File>fileInput.target.files[0];
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


    onSubmit() {
        this.submitted = true;
        
        if (this.requestForm.invalid) {
            return;
        }

        this.requestForm.disable();
        this.disableSubmitButton = true;

        this.requestService.createRequest({
            file: this.fileData,
            address: this.requestForm.controls['address'].value,
            content: this.requestForm.controls['content'].value,
            location: this.requestForm.controls['location'].value,
            topic: this.requestForm.controls['topic'].value,
            categoryId: this.requestForm.controls['category'].value
        }).subscribe({
            next: r => {
                this.toastService.Success('Zapisano zgłoszenie').subscribe({
                    complete: () => location.href = '/#/requests',
                });
            },
            error: e => {
                this.toastService.Error('Błąd przy zapisywaniu zgłoszenia. ' + e);                
                this.requestForm.enable();
                this.disableSubmitButton = false;}            
        });
    }
}
