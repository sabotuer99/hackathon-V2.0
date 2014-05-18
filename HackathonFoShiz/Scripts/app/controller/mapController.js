var mapControllers = angular.module('mapControllers', []);

mapControllers.controller('mapControllers', ['$scope','$routeParams', '$location', 'locationFactory', function ($scope, $routeParams, $location, locationFactory) {
    $scope.event = {
        Id: 0,
        Name: "",
        BeginDate: "",
        EndDate: "",
        Description: "",
        IsActive: "",
        Location: new Array()
    }
    var init = function () {
        //console.log("checking for user");

        if ($routeParams.id != undefined) {
            //console.log($routeParams.id);
            $scope.event.Id = $routeParams.id;
            //console.log($routeParams.id);
            //var id = $routeParams.id; // you're passing the event id to the location api! Doh!
            //locationFactory.get(id).then(function (data) {
            //    console.log(data);
            //    $scope.event = data.data;
            //});
            $scope.title = "Update Location";

        }
    }
    init();
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
        locationFactory.listByEvent($scope.event.Id).then(function (data) {
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
    $scope.listName = $scope.myData;
    $scope.gridOptions = {
        data: 'myData',
        columnDefs: $scope.columnDefs
    };
    function initialise() {
        $scope.myLatlng = new google.maps.LatLng(44,-105); // Add the coordinates
        locationFactory.listByEvent($scope.event.Id).then(function (data) {
            $scope.myData = data.data;
            var size = $scope.myData.length;
            for (var i = 0; i < size; i++) {
                console.log("lat" + $scope.myData[i].Latitude);
                console.log("long" + $scope.myData[i].Longitude);
                var addr = new google.maps.LatLng($scope.myData[i].Latitude, $scope.myData[i].Longitude);
                addMarker(addr, $scope.myData[i].Name, $scope.myData[i].Id);

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
        console.log(mapOptions);
        var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        function addMarker(location, title, id) {
            marker = new google.maps.Marker({
                position: location,
                map: map,
                title: title,
                url: "#/locationNeedHave/" + id

            });
            google.maps.event.addListener(marker, 'click', function () {

                var path = "#/locationNeedHave/" + id;
                $scope.Nav(path);
                window.location.href = marker.url;
            });
        }
        

    }
    $scope.btn = function()
    {
        var path = "/location/19";
        $scope.Nav(path);
    }
    $scope.Nav = function (path)
    {
        console.log(path);
        $location.path(path);
        console.log(path)
    }
    //google.maps.event.addDomListener(window, 'load', initialise); // Execute our 'initialise' function once the page has loaded.
    $(document).ready(initialise);
}]);