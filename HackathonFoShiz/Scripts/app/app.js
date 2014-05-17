var mainApp = angular.module('mainApp', ['ngRoute', 'ngGrid', 'ngAnimate', 'locationServices', 'locationControllers', 'locationListController']);

mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/location', {
                templateUrl: '/Partials/Location.html',
                controller: 'locationControllers'
            }).
            when('/locationList', {
                templateUrl: '/Partials/LocationList.html',
                controller: 'locationListController'
            }).
            //when('/cards/:cardId', {
            //    templateUrl: '/Scripts/app/Views/detail.html',
            //    controller: 'cardDetailController'
            //}).
            //when('/cars', {
            //    templateUrl: '/Partials/carList.html',
            //    controller: 'carController'
            //}).
            otherwise({
                redirectTo: '/locationList'
            });
    }
]);