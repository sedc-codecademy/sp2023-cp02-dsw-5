import { AbstractControl, FormGroup, ValidationErrors, ValidatorFn } from "@angular/forms";

export function passwordConfirmValidator(): ValidatorFn {
    return (control: AbstractControl) : ValidationErrors | null => {
        const value = control.get("passwordRepeated");
        const password = control.get("password");
        if(value === null)
            return null;

        if(password?.value !== value){
            return { 'passwordMismatch': true };
        }
        return null;
    };
}