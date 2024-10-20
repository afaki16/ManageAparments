import { ManageApartmentsTemplatePage } from './app.po';

describe('ManageApartments App', function() {
  let page: ManageApartmentsTemplatePage;

  beforeEach(() => {
    page = new ManageApartmentsTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
