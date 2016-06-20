angular.module('waterIntakeCalcWebApp')
  .controller('MainCtrl', function ($scope, $rootScope, AuthService, $location, $cookies) {

   $scope.inCredentials = {
      userName: '',
      password: '',
      grant_type: 'password'
    };
    
    $scope.upCredentials = {
        email: '',
        password: '',
        confirmPassword: ''
    };

    $scope.signIn = function (credentials) {
        $scope.loading = true;
        AuthService.login(credentials).then(function (res) {
            $scope.loading = false;
            $cookies.put('loginTokenCookie', res.access_token);
            $location.url('waterIntake');
        }, function (msg) {
            alert(msg);
        });
    };
    
    $scope.signUp = function (credentials) {
        AuthService.signUp(credentials).then(function (res) {
        }, function (msg) {
        });
    };
});
