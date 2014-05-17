var mainApp = angular.module('mainApp', ['ngRoute', 'ngAnimate', 'locationServices', 'locationControllers']);

mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/location', {
                templateUrl: '/Partials/Location.html',
                controller: 'locationControllers'
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
                redirectTo: '/location'
            });
    }
]);