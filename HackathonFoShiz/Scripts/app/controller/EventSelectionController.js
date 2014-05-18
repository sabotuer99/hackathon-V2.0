var eventSelectionController = angular.module('eventSelectionController', []);

eventSelectionController.controller('eventSelectionController', ['$scope', 'eventFactory', function ($scope, eventFactory) {

    $scope.columnDefs = [

                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'location/\', row)" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },
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