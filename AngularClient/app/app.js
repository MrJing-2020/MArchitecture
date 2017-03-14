
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
//路由
app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});
//全局变量
app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost:11572/',
    clientId: 'ngAuthApp'
});
//添加http请求拦截器
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
//登录，登出，刷新token服务
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


