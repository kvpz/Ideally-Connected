'use strict';

// Creating a custom service(User) dependent on the $resource service (provided by ngResource).
// The query(function) below retrieves a JSON array located in /users/users.json.
(function () {

    // functions used in factory
    function getUserData($resource) {
        return $resource('/App/users/:userId.json', {}, {
            query: {
                method: 'GET',
                params: { userId: 'users' },
                isArray: true
            }
        });
    }

    angular
        .module('core.user')
        .factory('User', ['$resource',
            getUserData
        ]);
})();
/*
    NOTES
    $resource(url, [paramDefaults], [actions], options);
    The URL template parameters are prefixed by ':'. Port numbers are also interpreted.
*/
