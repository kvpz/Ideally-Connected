'use strict';

(function () {

    function UserListController(User) {
        this.users = User.query();
        this.orderProp = 'age';
    }

    angular.module('userList').component('userList', {
        templateUrl: 'App/user-list/user-list.template.html',
        controller: ['User', UserListController]
    });
})();
/*
    NOTES
    User represents a resource service.
    $http.get('users/users.json').then(function(response){ self.users = response.data });
*/