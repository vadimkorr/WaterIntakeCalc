'use strict';

describe('Controller: WaterinakeCtrl', function () {

  // load the controller's module
  beforeEach(module('waterIntakeCalcWebApp'));

  var WaterinakeCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    WaterinakeCtrl = $controller('WaterinakeCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(WaterinakeCtrl.awesomeThings.length).toBe(3);
  });
});
