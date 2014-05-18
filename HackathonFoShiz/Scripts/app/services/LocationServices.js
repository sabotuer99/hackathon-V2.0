var locationServices = angular.module('locationServices', ['ngResource']);

var url = '/Api/Location';
locationServices.factory('locationFactory', function ($http) {
    return {
        list: function () {
            return $http.get(url);
        },
        get: function (id) {
            
            var path = url + "?id=" + id;
            console.log(path);
            return $http.get(path);
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