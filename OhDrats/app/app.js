﻿var app = angular.module('OhDrats', ['ngRoute']);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "app/Partials/Login.html",
            controller: "LoginController"
        })
        .when("/home",
        {
            templateUrl: "app/Partials/Home.html",
            controller: "HomeController"
        })
        .when("/signup",
        {
            templateUrl: "app/Partials/SignUp.html",
            controller: "SignUpController"
        })
        .when("/landing",
        {
            templateUrl: "app/Partials/LandingPage.html",
            controller: "LandingController"
        })
        .when("/opponent",
        {
            templateUrl: "app/Partials/Opponent.html",
            controller: "OpponentCtrl"
        })
        .when("/login",
        {
            templateUrl: "app/Partials/Login.html",
            controller: "LoginController"
        });
}]);


app.run(["$http", function ($http) {

    var token = sessionStorage.getItem('token');

    if (token)
        $http.defaults.headers.common['Authorization'] = `bearer ${token}`;

}
]);