'use strict';

// Creating a custom service(User) dependent on the $resource service (provided by ngResource).
// The query(function) below retrieves a JSON array located in /users/users.json.
angular.module('core.user').factory('User', ['$resource', 
    function ($resource) {
        return $resource('/App/users/:userId.json', {}, {
            query: { 
                method: 'GET',
                params: { userId: 'users' },
                isArray: true 
            }
        });
    }
]);

/*
    NOTES
    $resource(url, [paramDefaults], [actions], options);
    The URL template parameters are prefixed by ':'. Port numbers are also interpreted.
*/
