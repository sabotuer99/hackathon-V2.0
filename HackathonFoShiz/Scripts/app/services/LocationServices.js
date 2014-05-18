var locationServices = angular.module('locationServices', ['ngResource']);


locationServices.factory('locationFactory', function ($http) {
    var url = '/Api/Location';
    return {

        list: function () {
            console.log("I'm In Location");
            console.log(url);
            return $http.get(url);
        },
        listByEvent: function (eventId) {
            var path = url + "?eventId=" + eventId;
            console.log("I'm In Location");
            console.log(path);
            return $http.get(path);
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
            console.log(location.Id);
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