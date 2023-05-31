import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRecipeComponent } from './show-recipe.component';

describe('ShowRecipeComponent', () => {
  let component: ShowRecipeComponent;
  let fixture: ComponentFixture<ShowRecipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRecipeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
