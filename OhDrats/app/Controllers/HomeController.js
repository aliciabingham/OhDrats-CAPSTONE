app.controller("HomeController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {



        $scope.goLogin = function () {
            $location.path("/login");
        };

<<<<<<< Updated upstream
        $scope.goLogin = function () {
            $location.path("/login");
        };

=======
>>>>>>> Stashed changes
        $scope.goSignUp = function () {
            $location.path("/signup");
        };





    }
]);