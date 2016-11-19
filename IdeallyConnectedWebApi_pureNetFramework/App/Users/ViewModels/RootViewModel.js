userModule.controller("rootViewModel", function ($scope, userService, $http, viewModelHelper) {
    $scope.viewModelHelper = viewModelHelper;
    $scope.userService = userService;
    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "User Section";
    }
   
    $scope.userList = function () {
        viewModelHelper.navigateTo("user/list");
    }

    $scope.showUser = function () {
        if (userService.userId != 0) {
            $scope.flags.shownFromList = false;
            viewModelHelper.navigateTo("user/show" + userService.userId);
        }
    }

    initialize();
});