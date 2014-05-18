var eventServices = angular.module('eventServices', ['ngResource']);


eventServices.factory('eventFactory', function ($http) {
    var url = '/Api/Event';
    return {
        list: function () {
            console.log("I'm In Event");
            console.log(url);
            return $http.get(url);
        },
        get: function (id) {

            var path = url + "?Id=" + id;
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
            console.log(location.Id);
            if (location.Id != 0) {
                console.log("updating");
                return $http.put(url + "?Id=" + location.Id, location);
            }
            else {
                console.log("inserting");
                return $http.post(url, location);
            }
        }

    };
});