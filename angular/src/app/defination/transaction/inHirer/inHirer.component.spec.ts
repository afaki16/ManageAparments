/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InHirerComponent } from './inHirer.component';

describe('InHirerComponent', () => {
  let component: InHirerComponent;
  let fixture: ComponentFixture<InHirerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InHirerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InHirerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
