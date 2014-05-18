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
            return $http.delete(url + location.Id);
        },
        update: function (location) {
            return $http.put(url + location.Id, location);
        },
        save: function (location) {
            if (location.Id != 0) {
                console.log("updating");
                return $http.put(url + "?id=" + location.Id, location);
            }
            else
            {
                console.log("inserting");
                return $http.post(url, location);
            }
        }

    };
});