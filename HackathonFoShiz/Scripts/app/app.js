﻿var mainApp = angular.module('mainApp', ['ngRoute', 'ngGrid', 'ngAnimate', 'locationServices',
    'locationControllers', 'locationListController', 'controllersModule', 'gridDirectiveController',
    'itemControllers', 'itemServices', 'eventServices', 'eventSelectionController', 'mapControllers',
    'haveItemServices', 'itemTypeServices', 'needItemServices', 'peopleLocationServices', 'peopleServices', 'locationNeedHaveController']);
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
            })
            .when('/item', {
                templateUrl: '/Partials/Item.html',
                controller: 'itemControllers'
            })
            .when('/eventSelection', {
                templateUrl: '/Partials/EventSelection.html',
                controller: 'eventSelectionController'
            }).
             when('/crisismap', {
                templateUrl: '/Partials/CrisisMap.html',
                controller: 'mapControllers'
             }).
            when('/crisismap/:id', {
                templateUrl: '/Partials/CrisisMap.html',
                controller: 'mapControllers'
            }).
            when('/locationNeedHave/:locationId', {
                templateUrl: '/Partials/LocationNeedHave.html',
                controller: 'locationNeedHaveController'
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
                redirectTo: '/eventSelection'
            });
    }
]);