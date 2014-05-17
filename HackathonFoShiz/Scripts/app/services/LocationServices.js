var locationServices = angular.module('locationServices', ['ngResource']);

var url = '/Api/Location';
locationServices.factory('locationFactory', function ($http) {
    return {
        list: function () {
            return $http.get(url);
        },
        get: function (id) {
            return $http.get(url, id);
        },
        put: function (location) {
            return $http.post(url, location);
        },
        del: function (location) {
            return $http.delete(url + location.id);
        },
        update: function (location) {
            return $http.put(url + location.Id, location);
        }

    };
});