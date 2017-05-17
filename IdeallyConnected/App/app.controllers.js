'use strict';

angular
    .module('ICApp.controllers', [])
    .controller('MainController', ['$scope', 'UserService',
        function ($scope, UserService) {
            var self = this;
        }]);

angular
    .module('ICApp.controllers')
    .controller('IndexViewController', ['$scope',
        function ($scope) {
            var self = this;

        }]);

angular
    .module('ICApp.controllers')
    .factory('UserService', ['$http',
    function ($http) {
        var service = {};
        service.GetUsers = function () {
            return $http.get("users/GetUsers");
        }
    }]);