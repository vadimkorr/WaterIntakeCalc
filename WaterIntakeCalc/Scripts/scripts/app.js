'use strict';
angular
  .module('waterIntakeCalcWebApp', [
    'ngAnimate',
    'ngAria',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider, $httpProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'Scripts/views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
    })
    .when('/waterIntake', {
        templateUrl: 'Scripts/views/waterIntake.html',
        controller: 'WaterinakeCtrl',
        controllerAs: 'waterIntake'
    })
      .otherwise({
        redirectTo: '/'
      });
    $httpProvider.interceptors.push(function ($q, $cookies, $location) {
        return {
            'request': function (config) {
                $cookies.get('loginTokenCookie') ? config.headers['Authorization'] = 'Bearer ' + $cookies.get('loginTokenCookie') : $location.path() == '/';
                return config;
            }
        }
    })
  } );
