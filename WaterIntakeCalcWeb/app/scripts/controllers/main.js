'use strict';

/**
 * @ngdoc function
 * @name waterIntakeCalcWebApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the waterIntakeCalcWebApp
 */
angular.module('waterIntakeCalcWebApp')
  .controller('MainCtrl', function ($scope, $rootScope, AuthService, $location, $cookies) {

    $scope.upCredentials = {
      username: '',
      password: '',
      grant_type: 'password'
    };
    
    $scope.inCredentials = {
      username: '',
      password: '',
      grant_type: 'password'
    };

    $scope.signIn = function (credentials) {
        $scope.loading = true;
        AuthService.login(credentials).then(function (res) {
            $scope.loading = false;
            //$rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $cookies.put('loginTokenCookie', res.access_token);
            $location.url('experiments');
        }, function () {
            $scope.loading = false;
            $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        });
    };
    
    $scope.signUp = function (credentials) {
        /*$scope.loading = true;
        AuthService.login(credentials).then(function (res) {
            $scope.loading = false;
            //$rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $cookies.put('loginTokenCookie', res.access_token);
            $location.url('experiments');
        }, function () {
            $scope.loading = false;
            $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        });*/
    };
    
    
    
    
    
  });
