// We are calling the module's factory method to create a factory.
(function () {
    'use strict';

    var serviceId = 'personFactory';
   
    angular.module('PersonApp').factory(serviceId,
        ['$http', personFactory]);

    function personFactory($http) {
        function getPeople() {
            return $http.get('/api/people');
        }
        
        var service = {
            getPeople: getPeople
        };

        return service;
    }
})