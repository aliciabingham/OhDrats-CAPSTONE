app.controller("LandingController", ["$scope", "$http", "$location", "$rootScope",
    function ($scope, $http, $location, $rootScope) {
        $scope.addNewBattle = function () {
            $location.path("/battle");
        }
        $scope.addNewGun = function () {
            $location.path("/gun");
            console.log("you hit submit on gun");
        }

        $scope.logout = function () {

            sessionStorage.removeItem('token');
            $http.defaults.headers.common['Authorization'] = "";

            $location.path("/login");
        };
    }
]);