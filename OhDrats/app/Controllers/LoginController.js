﻿app.controller("LoginController", ["$scope", "$http", "$location", "$rootScope",
    function ($scope, $http, $location, $rootScope) {

        $scope.username = "b@b.com";
        $scope.password = "aS$1234";

        console.log("first login controller check");



        $scope.login = function () {
            console.log("you clicked login");
            $http({
                method: 'POST',
                url: "/Token",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                data: { grant_type: "password", username: $scope.username, password: $scope.password }
            })
            .then(function (result) {
                console.log("result=", result);

                sessionStorage.setItem('token', result.data.access_token);
                // sessionStorage.removeItem for logout (keyname)
                $http.defaults.headers.common['Authorization'] = `bearer ${result.data.access_token}`;

                $rootScope.username = result.data.userName;

                $location.path("/landing");

            });
        };
    }
]);