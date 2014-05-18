var locationListController = angular.module('locationListController', []);

locationListController.controller('locationListController', ['$scope', 'locationFactory', function ($scope, locationFactory) {

    $scope.columnDefs = [

                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'location/\', row)" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },
                //{ field:'id', displayName:'id' },
                { field: 'Address1', displayName: 'Address', width: 125 },
                
                { field: 'City', displayName: 'City' },
                { field: 'State', displayName: 'State' }
                
    ]
    $scope.sortInfo = { fields: ['city'], directions: ['asc'] };

    $scope.bindNewData = function () {
        console.log("getting");
        locationFactory.list().then(function (data) {
        //locationFactory.listByEvent(2).then(function (data) {
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
    $scope.gridOptions = {
        data: 'myData',
        columnDefs: $scope.columnDefs
    };
}]);