import { Component, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

const INPUT_FIELD_VALUE_ACESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => TextInputComponent),
  multi: true
}

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css'],
  providers: [INPUT_FIELD_VALUE_ACESSOR]
})
export class TextInputComponent implements ControlValueAccessor {

  private innerValue: any

  get value() {
    return this.innerValue
  }

  set value(v: any) {
    if (v !== this.innerValue) {
      this.innerValue = v
      this.onChangeCb(v)
    }
  }

  @Input() name: string = ''
  @Input() label: string = ''
  @Input() isReadOnly = false

  onChangeCb: (_: any) => void = () => { }
  onTouchedCb: (_: any) => void = () => { }


  writeValue(v: any): void {
    this.value = v
  }

  registerOnChange(fn: any): void {
    this.onChangeCb = fn
  }

  registerOnTouched(fn: any): void {
    this.onTouchedCb = fn
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isReadOnly = isDisabled
  }
}
