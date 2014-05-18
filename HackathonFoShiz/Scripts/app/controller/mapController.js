var mapControllers = angular.module('mapControllers', []);

mapControllers.controller('mapControllers', ['$scope', 'locationFactory', function ($scope, locationFactory) {

    $scope.columnDefs = [

                { field: '', displayName: 'Details', cellTemplate: '<button ng-click="navigate(\'location/\', row)" class="label btn-info"><div class="fs1" aria-hidden="true" data-icon="&#xe005;"></div></button>', width: 50 },
                //{ field:'id', displayName:'id' },
                { field: 'Address1', displayName: 'address1', width: 125 },
                { field: 'Address2', displayName: 'address2' },
                { field: 'City', displayName: 'city' },
                { field: 'State', displayName: 'state' }

    ]
    $scope.sortInfo = { fields: ['city'], directions: ['asc'] };
    $scope.myData = null;
    $scope.bindNewData = function () {
        //console.log("getting");
        locationFactory.list().then(function (data) {
            $scope.myData = data.data;
            console.log($scope.myData);
            //	        loggingService.debug(isDebug, data);
        }, function (error) {
            console.log("error");
            console.log(error);
            //loggingService.error(error);
        });
    }
    $scope.bindNewData();
    //$scope.myData = [{ name: "Moroni", age: 50 },
    //             { name: "Tiancum", age: 43 },
    //             { name: "Jacob", age: 27 },
    //             { name: "Nephi", age: 29 },
    //             { name: "Enos", age: 34 }];
    $scope.listName = $scope.myData;
    $scope.gridOptions = {
        data: 'myData',
        columnDefs: $scope.columnDefs
    };
    function initialise() {
        $scope.myLatlng = new google.maps.LatLng(44,-105); // Add the coordinates
        locationFactory.list().then(function (data) {
            $scope.myData = data.data;
            var size = $scope.myData.length;
            for (var i = 0; i < size; i++) {
                console.log("lat" + $scope.myData[i].Latitude);
                console.log("long" + $scope.myData[i].Longitude);
                var addr = new google.maps.LatLng($scope.myData[i].Latitude, $scope.myData[i].Longitude);
                addMarker(addr);

            }



        }, function (error) {
            console.log("error");
            console.log(error);
        });
        var mapOptions = {
            zoom: 6, // The initial zoom level when your map loads (0-20)
            center: $scope.myLatlng, // Centre the Map to our coordinates variable
            mapTypeId: google.maps.MapTypeId.ROADMAP, // Set the type of Map
            panControl: true,
            zoomControl: true,
            scaleControl: true
        }
        var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        function addMarker(location) {
            marker = new google.maps.Marker({
                position: location,
                map: map
            });
        }
        

    }
    google.maps.event.addDomListener(window, 'load', initialise); // Execute our 'initialise' function once the page has loaded.
}]);