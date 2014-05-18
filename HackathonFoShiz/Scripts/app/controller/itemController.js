var itemControllers = angular.module('itemControllers', []);

itemControllers.controller('itemControllers', ['$scope', 'itemFactory', function ($scope, itemFactory) {
    $scope.cars = "welcome to cars";
    $scope.saveNewItem = function () {
        console.log("here");
        $scope.feedback = "saving";
        itemFactory.save($scope.item).success(function (data) {
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
    
    $scope.$watch('item.editCurrentItem', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.checkActive();
            console.log("here");
        }
    }, true);
    $scope.checkActive = function ()
    {
        if($scope.item.editCurrentItem)
        {
            console.log("there");
            $scope.showEditItem = true;
        }
        else
        {
            $scope.showEditItem = false;
        }
    }

}]);