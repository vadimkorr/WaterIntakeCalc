'use strict';
angular.module('waterIntakeCalcWebApp')
  .controller('WaterinakeCtrl', function ($scope, $http) {

    $scope.addIntake = function(amount){
        $http.get('api/waterintake/AddWaterIntake/' + amount)
        .then(function (res) {
            alert(amount + " milliliters added for today");
        });
    }

    $scope.getNextWeek = function(){
  
    }

    $scope.getPrevWeek = function(){
  
    }
    $scope.chartPath;
    $scope.getCurrWeek = function(){
        $http.get('api/waterintake/GetChartOfWeek').then(function (res) {
            if (!res.data.Status) {
                $scope.chartPath = "/Scripts/images/chart.png";
            }
            else {
                $scope.chartPath = res.data.Result;
            }
          return res.data;
      });
    }
});
