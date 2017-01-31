'use strict';

// Configure existing services & providers. The function is executed upon loading the module. 
angular.module('ICApp')
    .config(['$locationProvider', '$routeProvider',
        function configICApp($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');

            $routeProvider
                .when('/users', {
                    template: '<user-list></user-list>'
                    //controller: 
                })
                .when('/users/:userId', {
                    template: '<user-detail></user-detail>'
                })
                .otherwise('/users');
        }
    ]);

/*
    All variables defined with the : prefix are extracted into the (injectable) $routeParams object and
    can then be retrieved as $routeParams.userId. (see user-detail.component.js for an example)
*/
