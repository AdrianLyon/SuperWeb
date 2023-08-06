var app = angular.module('myApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/category/', {
            templateUrl: 'app/views/category/category-list.html',
            controller: 'CategoryListController'
        })
        .when('/category/create', {
            templateUrl: 'app/views/category/category-form.html',
            controller: 'CategoryFormController'
        })
        .when('/category/edit/:categoryId', {
            templateUrl: 'app/views/category/category-form.html',
            controller: 'CategoryFormController'
        })
        .when('/product/', {
            templateUrl: 'app/views/product/producttest-list.html',
            controller: 'productListController'
        })
        .when('/product/create', {
            templateUrl: 'app/views/product/prodtuct-form.html',
            controller: 'productFormController'
        })
        .when('/product/edit/:productId', {
            templateUrl: 'app/views/product/prodtuct-form.html',
            controller: 'productFormController'
        })
        .otherwise({
            redirectTo: '/'
        });
});
