import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const auth = inject(AuthService);
  if(auth.currentUser$.getValue()?.role == "ADMINISTRATOR"){
    return true;
  }
  return false;
};
