userModule.controller("userViewModel",
    function ($scope, userService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
        $scope.viewModelHelper = viewModelHelper;
        $scope.userService = userService;

        var initializer = function () {
            $scope.refreshUser($routeParams.userId);
        }

        $scope.refreshUser = function (userId) {
            viewModelHelper.apiGet("api/user/" + userId, null, function (result) {
                userService.userId = userId;
                $scope.user = result.data;
            });
        }
    });

