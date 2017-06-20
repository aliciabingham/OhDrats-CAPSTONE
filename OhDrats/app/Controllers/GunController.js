app.controller("GunController", ["$scope", "$http", "$location", "$rootScope",
    function ($scope, $http, $location, $rootScope) {

        $scope.addGun = function () {
            console.log("you clicked submit on gun");
            $http({
                method: 'POST',
                url: "api/gun",
                data: { GunName: $scope.gunName, AmountOfAmmo: $scope.AmountOfAmmo }
            })
             .then(function (result) {
                 console.log("result from gun=", result);
             });
        };


        $scope.gunHistory = function () {
            $http({
                method: 'GET',
                url: 'api/gun/gunhistory'
            })
            .then(function (result) {
                $scope.displayGunHistory(result);
            });
        };

        $scope.displayGunHistory = function (result) {
            $('#gunHistoryOutput').html('');
            
            console.log(result.data[0]);
            
            for (var i = 0; i <= 5; i++) {
                var gunSelectionName = result.data[i].GunName;
                var gunSelectionAmmo = result.data[i].AmountOfAmmo;

                $('#gunHistoryOutput').append(`<h4>You have the ${gunSelectionName} gun, and it holds ${gunSelectionAmmo} rounds of ammo.</h4>`);
            }
        };

        $scope.addNewBattle = function () {
            $location.url("/battle");
        };
    }
]);