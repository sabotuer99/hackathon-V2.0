var itemServices = angular.module('itemServices', ['ngResource']);

var url = '/Api/Item';
itemServices.factory('itemFactory', function ($http) {
    return {
        list: function () {
            return $http.get(url);
        },
        get: function (id) {

            var path = url + "?Id=" + id;
            console.log(path);
            return $http.get(path);
        },
        put: function (item) {
            return $http.post(url, item);
        },
        del: function (item) {
            return $http.delete(url + item.Id);
        },
        update: function (item) {
            return $http.put(url + item.Id, item);
        },
        save: function (item) {
        if (item.Id && item.Id != 0) {
            console.log("save");
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