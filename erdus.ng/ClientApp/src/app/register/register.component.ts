import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from '@app/_services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required],
            password2: ['', Validators.required],
            privacy: ['', Validators.required]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    onSubmit() {
        this.submitted = true;

        if (this.registerForm.controls.password2.value !== this.registerForm.controls.password.value) {
            this.registerForm.controls.password2.setErrors({ 'different': true });
        }

        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;

        this.authenticationService.register(this.registerForm.controls.username.value, this.registerForm.controls.password.value)
            .subscribe(
                data => this.login(),
                error => {
                    if (error == 'Conflict') {
                        this.error = "Użytkownik już istnieje";
                    }
                    else if (error == 'Bad Request') {
                        this.error = "Hasło musi zawierać minimum 8 znaków, w tym 1 wielką literę, 1 małą literę, 1 cyfrę i 1 znak specialny";
                    } else {
                        this.error = error;
                    }
                    this.loading = false;
                });
    }

    login() {
        this.authenticationService.login(this.registerForm.controls.username.value, this.registerForm.controls.password.value)
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.error = error;
                    this.loading = false;
                });
    }

}
