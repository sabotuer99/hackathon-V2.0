var gridDirectiveController = angular.module('gridDirectiveController', []);

gridDirectiveController.controller('gridDirectiveController', ['$scope', '$location', function ($scope, $location) {
    'use strict';
    var isDebug = true;

    $scope.description = "gridDirectiveController";


    $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };

    $scope.pagingOptions = {
        pageSizes: [5, 10, 15],
        pageSize: 10,
        currentPage: 1
    };
    $scope.totalServerItems = 0;



    function sortData(field, direction) {
        if (!$scope.allData) return;
        $scope.allData.sort(function (a, b) {
            if (typeof a[field] === 'string' && typeof b[field] === 'string') {
                if (direction == "asc") {
                    return a[field].toLowerCase() > b[field].toLowerCase() ? 1 : -1;
                } else {
                    return a[field].toLowerCase() > b[field].toLowerCase() ? -1 : 1;
                }
            }
            else {
                if (direction == "asc") {
                    return a[field] > b[field] ? 1 : -1;
                } else {
                    return a[field] > b[field] ? -1 : 1;
                }
            }
        })
    }





    $scope.gridHeight = 400;

    $scope.setPagingData = function setPagingData(page, pageSize) {

        if ($scope.allData) {
            var data;
            if ($scope.filterOptions.filterText) {
                data = $scope.allData.filter(function (item) {
                    return propertyFilter(item);
                    //return JSON.stringify(item).toLowerCase().indexOf($scope.filterOptions.filterText.toLowerCase()) != -1;

                });
            }
            else {
                data = $scope.allData;
            }

            $scope.totalServerItems = $scope.allData.length;
            $scope.gridData = data.slice((page - 1) * pageSize, page * pageSize);
        }
        else {
            $scope.gridData = new Array();
        }
        $scope.gridHeight = pageSize * 40;

    };

    var propertyFilter = function (item) {
        for (var properties in item) {
            if (JSON.stringify(item[properties]).toLowerCase().indexOf($scope.filterOptions.filterText.toLowerCase()) != -1)
                return true;
        }
        return false;

    }
    $scope.navigate = function (path, row) {
        var isDebug = true;
        console.log(row);
        if (row.entity.Id)
            path = path + row.entity.Id;
        else if (row.entity.ID)
            path = path + row.entity.ID;

        //loggingService.debug(isDebug, 'mainController.navigate - ' + path);
        console.log(path);
        $location.path(path);

    };
    $scope.edit = function (row) {
        //    	loggingService.debug(isDebug, row);
        var rowCopy = row.entity.Id;
        //loggingService.debug(isDebug, rowCopy);
        $scope.editRow({ row: row });
        //loggingService.debug(isDebug, rowCopy);
    };
    $scope.edit = function (row, event) {
        //    	loggingService.debug(isDebug, row);
        var rowCopy = row.entity.Id;
        //loggingService.debug(isDebug, rowCopy);
        $scope.editRow({ row: row, event: event });
        //loggingService.debug(isDebug, rowCopy);
    };
    $scope.gridOptions = {
        data: 'gridData',
        columnDefs: $scope.columnDefs,
        enablePaging: true,

        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        sortInfo: $scope.sortInfo,
        useExternalSorting: true

    };



    $scope.$watch('pagingOptions', function (newVal, oldVal) {
        if (newVal !== oldVal && (newVal.currentPage !== oldVal.currentPage || newVal.pageSize !== oldVal.pageSize)) {
            $scope.setPagingData($scope.pagingOptions.currentPage, $scope.pagingOptions.pageSize);
        }
    }, true);
    $scope.$watch('filterOptions', function (newVal, oldVal) {
        if (newVal !== oldVal && newVal.filterText !== oldVal.filterText) {
            $scope.setPagingData($scope.pagingOptions.currentPage, $scope.pagingOptions.pageSize);
        }
    }, true);

    $scope.$watch('sortInfo', function (newVal, oldVal) {
        if (newVal && newVal.fields && newVal.directions) {
            sortData(newVal.fields[0], newVal.directions[0]);
            $scope.pagingOptions.currentPage = 1;
            $scope.setPagingData($scope.pagingOptions.currentPage, $scope.pagingOptions.pageSize);
        }
    }, true);
    $scope.$watch('allData', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.setPagingData($scope.pagingOptions.currentPage, $scope.pagingOptions.pageSize);
        }
    }, true);



}])
.filter('ArrayDescriptionFilter', function () {
    return function (lookupList) {
        var list = "";


        if (lookupList && Object.prototype.toString.call(lookupList) === '[object Array]') {

            for (var i = 0; i < lookupList.length; i++) {
                if (lookupList[i]) {
                    if (i == 0) {
                        list = lookupList[i].description;
                    }
                    else
                        list += ", " + lookupList[i].description;
                }
            }
        }
        return list;
    };
});