/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OutHirerComponent } from './outHirer.component';

describe('OutHirerComponent', () => {
  let component: OutHirerComponent;
  let fixture: ComponentFixture<OutHirerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OutHirerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OutHirerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
