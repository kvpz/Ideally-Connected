'use strict';
(function () {

    function IndexViewModelController($scope, $http, $q, $routeParams, $window, $location) {
        var self = this;
        self.author = "Created by Kevin Perez";
    }

    function configICApp($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/users', {
                template: '<user-list></user-list>'
            })
            .when('/users/:userId', {
                template: '<user-detail></user-detail>'
            })
            .otherwise('/');
    }

    angular
        .module('ICApp')
        .controller('IndexViewModel', ['$scope', '$http', '$q', '$routeParams', '$window', '$location', IndexViewModelController]);

    // Configure existing services & providers. The function is executed upon loading the module. 
    angular
        .module('ICApp')
        .config(['$locationProvider', '$routeProvider', configICApp]);
})();
/*
    All variables defined with the : prefix are extracted into the (injectable) $routeParams object and
    can then be retrieved as $routeParams.userId. (see user-detail.component.js for an example)
*/
