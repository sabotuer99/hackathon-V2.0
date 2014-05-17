var locationControllers = angular.module('locationControllers', []);

locationControllers.controller('locationControllers', ['$scope', 'locationFactory', function ($scope, locationFactory) {
    $scope.cars = "welcome to cars";
    $scope.save = function () {
        $scope.feedback = "saving";
        locationFactory.put($scope.location).success(function (data) {
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
    $scope.getgeodata = function () {
        var geocoder;
        var map;
        geocoder = new google.maps.Geocoder();
        if ($scope.location.City && $scope.location.State) {
            var Address = $scope.location.City + ', ' + $scope.location.State;
            console.log("Address");
            //console.log(Address);
            geocoder.geocode({ 'address': Address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    console.log("success");
                    //console.log(results[0]);
                    $scope.location.Latitude = results[0].geometry.location.lat();
                    $scope.location.Longitude = results[0].geometry.location.lng();
                    console.log($scope.location.Latitude);
                    console.log($scope.location.Longitude);

                }
                else {
                    console.log("failure");
                }
            }
            );
        }
    }
}]);