/*
var App = angular.module('App', ['ngRoute']); //, 'ui.bootstrap', 'chart.js']);

// When instanstiated, all the controllers will be declared
App.controller('MainController', MainController);

    angular.module('module name', ['modules inherited']);
    note: the html file using this module must inject the scripts for the modules being inherited
*/
var App = angular.module('App', ['ngRoute', 'ui.bootstrap', 'chart.js']);

App.controller('MainController', MainController);
App.controller('GridController', GridController);
App.controller('ViewProductController', ViewProductController);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/grid', {
            templateUrl: '/SPA/Views/Grid.html',
            controller: GridController
        })
       .otherwise({
           redirectTo: function () {
               return '/grid';
           }
       });
}

configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);

