/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HirerComponent } from './hirer.component';

describe('HirerComponent', () => {
  let component: HirerComponent;
  let fixture: ComponentFixture<HirerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HirerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HirerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
