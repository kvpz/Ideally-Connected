userModule.controller("userHomeViewModel",
    function ($scope, userService, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.userService = userService;
    
    var initialize = function () {

    }

    initialize();
});