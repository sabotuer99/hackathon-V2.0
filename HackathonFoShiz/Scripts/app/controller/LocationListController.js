var locationListController = angular.module('locationListController', []);

locationListController.controller('locationListController', ['$scope', 'locationFactory', function ($scope, locationFactory) {

    $scope.columnDefs = [
                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="edit(row, \'Edit\')" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },

                //{ field:'id', displayName:'id' },
                { field: 'address.address1', displayName: 'address1', width: 125 },
                { field: 'address.address2', displayName: 'address2' },
                { field: 'address.city', displayName: 'city' },
                { field: 'address.state', displayName: 'state' }
                
    ]
    $scope.sortInfo = { fields: ['city'], directions: ['asc'] };

    //$scope.bindNewData = function () {
    //    agencyLookupService.listEgiView(true).then(function (data) {
    //        $scope.allData = data.items;
    //        //	        loggingService.debug(isDebug, data);
    //    }, function (error) {
    //        loggingService.error(error);
    //    });
    //}

    //$scope.bindNewData();


    $scope.myData = [{ name: "Moroni", age: 50 },
                 { name: "Tiancum", age: 43 },
                 { name: "Jacob", age: 27 },
                 { name: "Nephi", age: 29 },
                 { name: "Enos", age: 34 }];

    $scope.listName = $scope.myData;
    $scope.gridOptions = {
        data: 'myData',
        columnDefs: $scope.columnDefs
    };
}]);