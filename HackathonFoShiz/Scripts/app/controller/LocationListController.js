﻿var locationListController = angular.module('locationListController', []);

locationListController.controller('locationListController', ['$scope', 'locationFactory', function ($scope, locationFactory) {

    $scope.columnDefs = [
                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="edit(row, \'Edit\')" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },

                //{ field:'id', displayName:'id' },
                { field: 'Address1', displayName: 'address1', width: 125 },
                { field: 'Address2', displayName: 'address2' },
                { field: 'City', displayName: 'city' },
                { field: 'State', displayName: 'state' }
                
    ]
    $scope.sortInfo = { fields: ['city'], directions: ['asc'] };

    $scope.bindNewData = function () {
        console.log("getting");
        locationFactory.get().then(function (data) {
            $scope.myData = data.data;
            console.log($scope.myData);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            loggingService.error(error);
        });
    }

    $scope.bindNewData();

  
    //$scope.myData = [{ name: "Moroni", age: 50 },
    //             { name: "Tiancum", age: 43 },
    //             { name: "Jacob", age: 27 },
    //             { name: "Nephi", age: 29 },
    //             { name: "Enos", age: 34 }];

    $scope.listName = $scope.myData;
    $scope.gridOptions = {
        data: 'myData',
        columnDefs: $scope.columnDefs
    };
}]);