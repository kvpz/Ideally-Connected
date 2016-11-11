// Write your Javascript code.
var personApp = angular.module('personApp', []);

personApp.controller('personController', function ($scope) {
    $scope.name = 'Mary Jane';
});

// creating an angularjs module. Here we are registering a controller, <module name>.controller()
// ng-controller is used to implement an angularjs controller in HTML
personApp.controller('personModController', function ($scope) {
    $scope.fName = "Juan";
    $scope.lName = "Pablo"
});

var PersonControllerComp = function () {
    var vm = this;
    vm.firstName = "Aftab";
    vm.lastName = "Ansari";
}

personApp.component('personComponent', {
    templateUrl: '/js/personcomponent.html',
    controller: PersonControllerComp,
    controllerAs: 'vm'
});

personApp.factory('personFactory', function () {
    function getName() {
        return "Mary Jane";
    }

    var service = {
        getName: getName
    }

    return service;
});

// this controller is used to call the personFactory function
personApp.controller('personControllerFactory', function ($scope, personFactory) {
    $scope.name = personFactory.getName();
});
