'use strict';
var appControllers = angular.module('appControllers', []);
//(function () {
    angular.module('userList').factory('UserService', ['$http',
    function ($http) {

        var fac = {};

        fac.GetUserFromDb = function () {
            return $http.get("/users");
        };

        return fac;
    }]);

    function UserListController(UserService) {
        var self = this;
        this.users = User.query();
        this.orderProp = 'age';

        var datajson;
        UserService.GetUserFromDb().then(function (d) {
            datajson = d.data.list;
            self.listUsersFromDb = datajson;
            //tabtab(datajson);
        });
        /*
        var tabtab = function (datajson) {
            tabulate(datajson, ['PlayerId', 'Name', 'Club', 'Country'])
        }
        */
    }

    angular.module('userList').component('userList', {
        templateUrl: 'App/user-list/user-list.template.html',
        controller: ['UserService', function (UserService) {
            var self = this;
            //this.users = User.query();
            this.orderProp = 'age';

            var datajson;
            UserService.GetUserFromDb().then(function (d) {
                datajson = d.data.list;
                self.listUsersFromDb = datajson;
                //tabtab(datajson);
            });
        }]
    });


//})();
/*
    NOTES
    User represents a resource service.
    $http.get('users/users.json').then(function(response){ self.users = response.data });
*/
