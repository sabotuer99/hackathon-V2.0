var haveItemServices = angular.module('haveItemServices', ['ngResource']);


haveItemServices.factory('haveItemFactory', function ($http) {
    var url = '/Api/HaveItem';
    return {
        list: function () {
            console.log("I'm In Have Item");
            console.log(url);
            return $http.get(url);
        },
        listByLocation: function (locationId) {
            console.log("listByLoc");
            var path = url + "?locationId=" + locationId;
            console.log(path);
            return $http.get(path);
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