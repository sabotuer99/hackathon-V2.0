var pagingFilterGrid = angular.module('pagingFilterGrid', []);

pagingFilterGrid.directive('pagingFilterGrid', ['$scope', function ($scope) {
    "use strict";

    return {
        restrict: "E",
        scope: {
            columnDefs: "@columnDefs",
            sortInfo: "=sortInfo",
            allData: "=gridData",
            editRow: "&editRow"

        },
        controller: "gridDirectiveController",
        templateUrl: "../Partials/pagingFilterGrid.html"

    };
}]);