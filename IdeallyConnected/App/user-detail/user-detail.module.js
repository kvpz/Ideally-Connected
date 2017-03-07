'use strict';

angular.module('userDetail', [
    'ngRoute',
    'core.user'
]);

/*
    NOTES
    ngRoute is already being inherited from NCApp module, but it is good practice
    to not rely on inherited dependencies. Declaring the same dependency does not incur
    extra costs.
*/