'use strict';

(function () {

    function UserDetailController($routeParams, User) {
        var self = this;
        self.checkrp = $routeParams;

        self.user = User.get({
            userId: $routeParams.userId
        }, function (user) {
            self.skills = user.Skills;
            self.bio = [user.firstName, user.lastName, user.age];
        });
    }

    angular
        .module('userDetail')
        .component('userDetail', {
            templateUrl: 'App/user-detail/user-detail.template.html',
            controller: ['$routeParams', 'User', UserDetailController]
        });

})();
/*
    NOTES
    Components are referenced in HTML in kebab case, ex: userDetail become user-detail.
    $ctrl used outside the definition of controller refers to an instance of the controller.
    So, when $ctrl is used in user-detail.template.html, it's equivalent to 'this' controller.

    $routeParams
*/