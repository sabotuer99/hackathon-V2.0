var itemServices = angular.module('itemServices', ['ngResource']);

var url = '/Api/Item';
itemServices.factory('itemFactory', function ($http) {
    return {
        list: function () {
            return $http.get(url);
        },
        get: function (id) {
            return $http.get(url, id);
        },
        put: function (item) {
            return $http.post(url, item);
        },
        del: function (item) {
            return $http.delete(url + item.id);
        },
        update: function (item) {
            return $http.put(url + item.Id, item);
        },
        save: function (item) {
        if (item.Id != 0) {
            console.log("updating");
            return $http.put(url + "?id=" + item.Id, item);
        }
        else
        {
            console.log("inserting");
            return $http.post(url, item);
        }
    }

    };
});