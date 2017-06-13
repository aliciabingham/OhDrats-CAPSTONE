app.controller("GunController", ["$scope", "$http", "$location", "$rootScope",
    function ($scope, $http, $location, $rootScope) {

        $scope.addGun = function () {
            console.log("you clicked submit on gun");
            $http({
                method: 'POST',
                url: "api/gun",
                data: { GunName: $scope.gunName }
            })
             .then(function (result) {
               console.log("result from battle=", result);
            });  
        }
    }
]);