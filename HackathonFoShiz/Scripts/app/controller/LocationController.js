var locationControllers = angular.module('locationControllers', []);

locationControllers.controller('locationControllers', ['$scope', 'locationFactory', function ($scope, locationFactory) {
    $scope.cars = "welcome to cars";
    $scope.save = function () {
        $scope.feedback = "saving";
        locationFactory.put($scope.cars).success(function (data) {
            $scope.feedback = "put!";
            alert("Saved Successfully!!");
            //cust.editMode = false;
            //$scope.loading = false;
        }).error(function (data) {
            $scope.feedback = "fail";
            alert("error!!");
            $scope.error = "An Error has occured while Saving location! " + data.ExceptionMessage;
            //$scope.loading = false;

        });
    };

}]);