var eventSelectionController = angular.module('eventSelectionController', []);

eventSelectionController.controller('eventSelectionController', ['$scope', 'eventFactory', function ($scope, eventFactory) {

    $scope.columnDefs = [

                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'crisismap/\', row)" class="label btn-info">Select</button>', width: 70 },
                //{ field:'id', displayName:'id' },
                { field: 'Name', displayName: 'Name', width: 125 },
                { field: 'Description', displayName: 'Description' }

    ]
    $scope.sortInfo = { fields: ['Name'], directions: ['asc'] };

    $scope.bindNewData = function () {
        console.log("getting");
        eventFactory.list().then(function (data) {
            $scope.myData = data.data;
            console.log($scope.myData);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            //loggingService.error(error);
        });
    }

    $scope.bindNewData();


    $scope.listName = $scope.myData;

}]);