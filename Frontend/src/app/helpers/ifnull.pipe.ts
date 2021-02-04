import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'ifnull'
})

export class IfNullPipe implements PipeTransform {
    transform(value: string, args?: any) {
        if (!value)
            return 'No Parent';

        return value;
    }
}
