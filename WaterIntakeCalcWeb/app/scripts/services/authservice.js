'use strict';

/**
 * @ngdoc service
 * @name waterIntakeCalcWebApp.AuthService
 * @description
 * # AuthService
 * Service in the waterIntakeCalcWebApp.
 */
angular.module('waterIntakeCalcWebApp')
  .service('AuthService', function ($http, $httpParamSerializerJQLike, session, $cookies) {

  var authService = {};

  authService.login = function (credentials) {
    return $http
      .post('/Token', $httpParamSerializerJQLike(credentials), { headers: { 'Content-Type': 'application/x-www-form-urlencoded' }})
      .then( function ( res ) {
          session.create(res.data.userName);
          return res.data;
      });
  };

  authService.logout = function (credentials) {
    return $http
      .post('/api/Account/Logout')
      .then(function (res) {
        session.destroy();
        return res.data;
      });
  };

  authService.isLoggedIn = function () {
    return !!$cookies.get('loginTokenCookie');
  };

  authService.isAuthorized = function (authorizedRoles) {
    if (!angular.isArray(authorizedRoles)) {
      authorizedRoles = [authorizedRoles];
    }
    return (authService.isAuthenticated() &&
    authorizedRoles.indexOf(Session.userRole) !== -1);
  };

  return authService;


  });
