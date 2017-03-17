var app = angular.module('AdminApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
//路由
app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/Home.html"
    });

    $routeProvider.when("/usermanager", {
        controller: "userManagerController",
        templateUrl: "/app/views/UserManager.html"
    });
    //$routeProvider.otherwise({ redirectTo: "/home" });
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


