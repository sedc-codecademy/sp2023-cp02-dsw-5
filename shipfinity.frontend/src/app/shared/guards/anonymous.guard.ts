import { CanActivateFn } from '@angular/router';

export const anonymousGuard: CanActivateFn = (route, state) => {
  if (!localStorage.getItem("Token")){
    return true;
  }
  return false;
};
