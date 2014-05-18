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
        put: function (event) {
            return $http.post(url, event);
        },
        del: function (event) {
            return $http.delete(url + event.Id);
        },
        update: function (event) {
            return $http.put(url + event.Id, event);
        },
        save: function (event) {
            console.log(event.Id);
            if (event.Id != 0) {
                console.log("updating");
                return $http.put(url + "?Id=" + event.Id, event);
            }
            else {
                console.log("inserting");
                return $http.post(url, event);
            }
        }

    };
});