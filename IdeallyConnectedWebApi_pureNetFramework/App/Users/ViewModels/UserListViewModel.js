userModule.controller("userListViewModel",
    function ($scope, userService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    
        $scope.viewModelHelper = viewModelHelper;
        $scope.userService = userService;

        var initialize = function () {
            $scope.refreshUsers;
        }

        $scope.refreshUsers = function () {
            viewModelHelper.apiGet("api/users", null, function (result) {
                $scope.users = result.data;
            });
        }

        $scope.showUser = function (user) {
            $scope.flags.shownFromList = true;
            viewModelHelper.navigateTo("user/show/" + user.UserId);
        }

        initialize();
});