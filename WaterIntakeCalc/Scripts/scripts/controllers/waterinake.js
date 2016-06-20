'use strict';
angular.module('waterIntakeCalcWebApp')
  .controller('WaterinakeCtrl', function ($scope, $http) {

    $scope.addIntake = function(amount) {
        $http.get('api/waterintake/AddWaterIntake/' + amount)
            .then(function(res) {
                alert(amount + " milliliters added for today");
            });
    };

    $scope.getNextWeek = function() {

    };

    $scope.getPrevWeek = function() {

    };
    $scope.chartPath = "/Scripts/images/chart.png";
    $scope.getCurrWeek = function () {



        $http.get('/api/waterintake/GetChartOfWeek/',
        { responseType: 'arraybuffer' }
      ).success( function ( res ) {
        var blob = new Blob( [res], { type: 'image/png' } );
        $scope.chartPath = (window.URL || window.webkitURL).createObjectURL(blob);
      } );




        //$scope.chartPath = "/api/waterintake/GetChartOfWeek/";
        //$http.get('api/waterintake/GetChartOfWeek').then(function(res) {   
        //        $scope.chartPath = res.data;
        //    return res.data;
        //});
    };
});
