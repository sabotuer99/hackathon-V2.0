var locationNeedHaveController = angular.module('locationNeedHaveController', []);

locationNeedHaveController.controller('locationNeedHaveController', ['$scope', '$routeParams', 'haveItemFactory', 'needItemFactory', 'locationFactory', 'itemFactory', function ($scope, $routeParams, haveItemFactory, needItemFactory, locationFactory, itemFactory) {

    $scope.bindNewDataHas = function () {
        console.log("getting");
        haveItemFactory.listByLocation($routeParams.locationId).then(function (data) {
            //locationFactory.listByEvent(2).then(function (data) {
            $scope.allHasData = data.data;
            console.log($scope.allHasData);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            //loggingService.error(error);
        });
    }



    $scope.buildItemList = function () {
        console.log("getting");
        itemFactory.list().then(function (data) {
            //locationFactory.listByEvent(2).then(function (data) {
            $scope.allItems = data.data;
            console.log($scope.allItems);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            //loggingService.error(error);
        });
    }
    $scope.bindNewDataNeeds = function () {
        console.log("getting");
        needItemFactory.listByLocation($routeParams.locationId).then(function (data) {
            //locationFactory.listByEvent(2).then(function (data) {
            $scope.allNeedsData = data.data;
            console.log($scope.allNeedsData);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            //loggingService.error(error);
        });
    }
    var init = function () {

        if ($routeParams.locationId != undefined) {
            console.log($routeParams.locationId);
            $scope.location.Id = $routeParams.locationId;
            console.log($routeParams.locationId);
            var id = $routeParams.locationId;
            locationFactory.get(id).then(function (data) {
                console.log(data);
                $scope.location = data.data;
            });
            $scope.title = "Update Location";

        }
        $scope.buildItemList();
        $scope.bindNewDataHas();
        $scope.bindNewDataNeeds();
    }
    init();


    $scope.columnDefsHas = [

                //{ field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'location/\', row)" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },
                //{ field:'id', displayName:'id' },
                //{ field: 'Address1', displayName: 'Address', width: 125 },

                { field: 'ItemId', displayName: 'item', enableCellEdit: false, cellTemplate: '<input type="text" value= "{{edit(row, \'getItem\')}}"  ng-model="edit(row, \'getItem\')" />' },
                { field: 'Qty', displayName: 'Total at Location', enableCellEdit: true, cellTemplate: '<input type="number" ng-input="COL_FIELD" ng-model="COL_FIELD" ng-blur="edit(row, \'has\')" />' }



    ]
    $scope.sortInfoHas = { fields: ['ItemId'], directions: ['asc'] };



    $scope.columnDefsNeeds = [

            //{ field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'location/\', row)" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },
            //{ field:'id', displayName:'id' },
            //{ field: 'Address1', displayName: 'Address', width: 125 },

            { field: 'ItemId', displayName: 'item' },
            { field: 'Qty', displayName: 'Estimated Need', enableCellEdit: true, cellTemplate: '<input type="number" ng-input="COL_FIELD" ng-model="COL_FIELD" ng-blur="edit(row, \'need\')" />' }

    ]
    $scope.sortInfoNeeds = { fields: ['ItemId'], directions: ['asc'] };

    $scope.getItem = function (itemId)
    {
        console.log("item" + itemId);
        for (var i = 0; i < $scope.allItems.length; i++) {
            console.log("compare" + itemId + " to" + JSON.stringify($scope.allItems[i], null, 2));
            if (itemId == $scope.allItems[i].Id) {
                
                console.log("found" + $scope.allItems[i].Description);
                return $scope.allItems[i].Description;
            }
        }
        //itemFactory.get(itemId).then(function (data) {
            //locationFactory.listByEvent(2).then(function (data) {
            //var item = data.data;
            //console.log(item);
            //return item.Description;

            //	        loggingService.debug(isDebug, data);
        //}, function (error) {
        //    console.log("error");
        //    console.log(error);
        //    //loggingService.error(error);
        //});
        return "";
    }
    $scope.edit = function (row, event)
    {
        console.log("row" + row);
        if (event == "need")
            $scope.SaveNeed(row);
        else if (event == "has")
            $scope.SaveHas(row);
        else if (event == "getItem")
            $scope.getItem(row.entity.ItemId)
    }
    $scope.SaveNeed = function(row)
    {
        console.log(row.entity);
        needItemFactory.save(row.entity).success(function (data) {
            $scope.feedback = "put!";
            //alert("Saved Successfully!!");
            //cust.editMode = false;
            //$scope.loading = false;
        }).error(function (data) {
            $scope.feedback = "fail";
            //alert("error!!");
            $scope.error = "An Error has occured while Saving location! " + data.ExceptionMessage;
            //$scope.loading = false;

        });
    }
    $scope.SaveHas = function (row) {
        console.log(row.entity);
        haveItemFactory.save(row.entity).success(function (data) {
            $scope.feedback = "put!";
            alert("Saved Successfully!!");
            //cust.editMode = false;
            //$scope.loading = false;
        }).error(function (data) {
            $scope.feedback = "fail";
            alert("error!!");
            $scope.error = "An Error has occured while Saving location! " + data.ExceptionMessage;
            //$scope.loading = false;

        });
    }



    

}]);
