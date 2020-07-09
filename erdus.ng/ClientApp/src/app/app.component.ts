import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from './_services';
import { User, Role } from './_models';
import { NgcNoCookieLawEvent, NgcStatusChangeEvent, NgcInitializeEvent, NgcCookieConsentService } from 'ngx-cookieconsent';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { environment } from '../environments/environment';

@Component({ selector: 'app', templateUrl: 'app.component.html', styleUrls: ['app.component.css'] })

export class AppComponent implements OnInit, OnDestroy {
  currentUser: User;

  //keep refs to subscriptions to be able to unsubscribe later
  private popupOpenSubscription: Subscription;
  private popupCloseSubscription: Subscription;
  private initializeSubscription: Subscription;
  private statusChangeSubscription: Subscription;
  private revokeChoiceSubscription: Subscription;
  private noCookieLawSubscription: Subscription;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private ccService: NgcCookieConsentService,
    private translateService: TranslateService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {

    if (environment.production) {
      if (location.protocol === 'http:') {
        window.location.href = location.href.replace('http', 'https');
      }
    }

    if (this.ccService.hasConsented() === false) {
      this.ccService.clearStatus();
    }

    if (this.getCookie("cookieconsent_status") === "allow") {
      this.ccService.destroy();
    }
    else {
      this.translateService//
        .get(['cookie.header', 'cookie.message', 'cookie.dismiss', 'cookie.allow', 'cookie.deny', 'cookie.link', 'cookie.policy'])
        .subscribe(data => {
          this.ccService.getConfig().content = this.ccService.getConfig().content || {};
          // Override default messages with the translated ones
          this.ccService.getConfig().content.policy = "Polityka Cookie";
          this.ccService.getConfig().content.deny = "Nie zgadzam się";
          this.ccService.getConfig().content.allow = "Zgadzam się";

          this.ccService.destroy();//remove previous cookie bar (with default messages)
          this.ccService.init(this.ccService.getConfig()); // update config with translated messages
        });
    }

   


    // subscribe to cookieconsent observables to react to main events
    this.popupOpenSubscription = this.ccService.popupOpen$.subscribe(
      () => {

        // you can use this.ccService.getConfig() to do stuff...
      });

    this.popupCloseSubscription = this.ccService.popupClose$.subscribe(
      () => {
        // you can use this.ccService.getConfig() to do stuff...
      });

    this.initializeSubscription = this.ccService.initialize$.subscribe(
      (event: NgcInitializeEvent) => {

        // you can use this.ccService.getConfig() to do stuff...
      });

    this.statusChangeSubscription = this.ccService.statusChange$.subscribe(
      (event: NgcStatusChangeEvent) => {
        if (event.status == "deny") {
          location.href = "https://google.com"

        } else {
          document.cookie = "cookieconsent_status=allow";
          this.ccService.destroy();
        }
        // you can use this.ccService.getConfig() to do stuff...
      });

    this.revokeChoiceSubscription = this.ccService.revokeChoice$.subscribe(
      () => {
        // you can use this.ccService.getConfig() to do stuff...
      });

    this.noCookieLawSubscription = this.ccService.noCookieLaw$.subscribe(
      (event: NgcNoCookieLawEvent) => {
        // you can use this.ccService.getConfig() to do stuff...
      });
  }

  ngOnDestroy(): void {
    // unsubscribe to cookieconsent observables to prevent memory leaks
    this.popupOpenSubscription.unsubscribe();
    this.popupCloseSubscription.unsubscribe();
    this.initializeSubscription.unsubscribe();
    this.statusChangeSubscription.unsubscribe();
    this.revokeChoiceSubscription.unsubscribe();
    this.noCookieLawSubscription.unsubscribe();
  }

  logout() {
    this.authenticationService.logout()
      .subscribe({
        complete: () => this.router.navigate(['/login']),
      });
  }

  login() {
    this.router.navigate(['/login']);
  }

  register() {
    this.router.navigate(['/register']);
  }

  goToList() {
    if (this.currentUser.roles.find(x => x == Role.Moderator)) {
      this.router.navigate(['/responsibility/requests']);
    }
    else {
      this.router.navigate(['/user/requests']);
    }
  }

  getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return "";
  }

}
