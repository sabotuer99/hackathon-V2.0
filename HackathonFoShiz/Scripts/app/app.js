var mainApp = angular.module('mainApp', ['ngRoute', 'ngGrid', 'ngAnimate', 'locationServices', 'locationControllers', 'locationListController', 'controllersModule', 'gridDirectiveController','itemControllers','itemServices','mapControllers']);
console.log("here");
mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/location', {
                templateUrl: '/Partials/Location.html',
                controller: 'locationControllers'
            })
            .when('/location/:id', {
                templateUrl: '/Partials/Location.html',
                controller: 'locationControllers'
            })
            .when('/locationList', {
                templateUrl: '/Partials/LocationList.html',
                controller: 'locationListController'
            }).
            when('/item', {
                templateUrl: '/Partials/Item.html',
                controller: 'itemControllers'
            }).
            when('/crisismap', {
                templateUrl: '/Partials/CrisisMap.html',
                controller: 'mapControllers'
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