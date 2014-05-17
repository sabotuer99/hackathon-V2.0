var controllersModule = angular.module('controllersModule', []);
controllersModule.directive('pagingFilterGrid', function () {
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
        templateUrl: "/Partials/pagingFilterGrid.html"

    };
});