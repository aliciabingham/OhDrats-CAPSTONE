﻿var app = angular.module('OhDrats', ['ngRoute']);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "app/Partials/Home.html",
            controller: "HomeController"
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
        .when("/battle",
        {
            templateUrl: "app/Partials/Battle.html",
            controller: "BattleController"
        })
        .when("/gun",
        {
            templateUrl: "app/Partials/Gun.html",
            controller: "GunController"
        })
        .when("/login",
        {
            templateUrl: "app/Partials/Login.html",
            controller: "LoginController"
        });
}]);


app.run(["$http", function ($http) {

    var token = sessionStorage.getItem('token');

    if (token) {
        $http.defaults.headers.common['Authorization'] = `bearer ${token}`;

    }

}
]);