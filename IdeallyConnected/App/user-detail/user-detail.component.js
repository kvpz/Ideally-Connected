'use strict';

angular.module('userDetail')
    .component('userDetail', {
        templateUrl: 'user-detail/user-detail.template.html',
        controller: ['$routeParams', 'User',
            function UserDetailController($routeParams, User) {
                var self = this;
                self.checkrp = $routeParams;
                
                self.user = User.get({ userId: $routeParams.userId }, function(user) {
                    self.stuff = user.Skills;
                });
                self.checkUser = User.toString();
            }
        ]
    });

/*
    NOTES
    Components are referenced in HTML in kebab case, ex: userDetail become user-detail.
    $ctrl used outside the definition of controller refers to an instance of the controller.
    So, when $ctrl is used in user-detail.template.html, it's equivalent to 'this' controller.

    $routeParams
*/