var peopleServices = angular.module('peopleServices', ['ngResource']);


peopleServices.factory('peopleFactory', function ($http) {
    var url = '/Api/People';
    return {
        list: function () {
            console.log("I'm In people");
            console.log(url);
            return $http.get(url);
        },
        get: function (id) {

            var path = url + "?Id=" + id;
            console.log(path);
            return $http.get(path);
        },
        put: function (entity) {
            return $http.post(url, entity);
        },
        del: function (entity) {
            return $http.delete(url + entity.Id);
        },
        update: function (entity) {
            return $http.put(url + entity.Id, entity);
        },
        save: function (entity) {
            console.log(entity.Id);
            if (entity.Id != 0) {
                console.log("updating");
                return $http.put(url + "?Id=" + entity.Id, entity);
            }
            else {
                console.log("inserting");
                return $http.post(url, entity);
            }
        }

    };
});