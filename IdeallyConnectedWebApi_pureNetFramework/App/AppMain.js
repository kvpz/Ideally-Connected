var commonModule = angular.module("common", ["ngRoute"]);
var mainModule = angular.module("main", ["common"]);

commonModule.factory("validator", function () { return valJs.validator(); });

mainModule.controller("indexViewModel", function ($scope, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    var self = this;
    $scope.topic = "Data Mining a network with ASP.NET and AngularJS";
    $scope.author = "Kevin Perez";
});

/*
    This is an Anonymous Closure. It is an anonymous function that is executed immediately. The () closures
    make this a function expression.
    http://www.adequatelygood.com/JavaScript-Module-Pattern-In-Depth.html
*/
(function (myApp) {
    var viewModelHelper = function ($http, $q, $window, $location) {
        var self = this;
        self.modelIsValid = true;
    }
}) (window.MyApp);

