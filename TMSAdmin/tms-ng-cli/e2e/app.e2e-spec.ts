import { TmsNgCliPage } from './app.po';

describe('tms-ng-cli App', () => {
  let page: TmsNgCliPage;

  beforeEach(() => {
    page = new TmsNgCliPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
