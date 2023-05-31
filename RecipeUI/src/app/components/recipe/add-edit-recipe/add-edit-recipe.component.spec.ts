import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRecipeComponent } from './add-edit-recipe.component';

describe('AddEditRecipeComponent', () => {
  let component: AddEditRecipeComponent;
  let fixture: ComponentFixture<AddEditRecipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditRecipeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
