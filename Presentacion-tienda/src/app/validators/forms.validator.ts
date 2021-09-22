import { FormGroup } from "@angular/forms";

export function ValidateForm(formName: any) {
    return function (target: any, key: any, descriptor: any) {
        const originalMethod:Function = descriptor.value;

        descriptor.value = function (this: any,...args: any) {
            let formGroup:FormGroup = this[formName] 
            if (_validateForm(formGroup)) {
                originalMethod.apply(this, args);
            }
        };

        return descriptor;
    }


}
// the function which we will execute in the formGroup variable
function _validateForm(form:FormGroup): boolean {
    if (!form.valid) {
        /* if you are using angular 8 or above, you can just do form.markAllAsTouched() which will touch 
           all the fields without having to loop through all the fields and mark it as touched.
        */
        for (let i in form.controls) {
            form.controls[i].markAsTouched()
        }
        return false
    }
    else {
        return true
    }
}