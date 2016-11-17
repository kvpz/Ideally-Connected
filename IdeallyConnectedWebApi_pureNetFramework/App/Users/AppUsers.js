var userModule = angular.module("user", ["common"]);

userModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when("/user", {
        templateUrl: "/App/User/Views/UserHomeView.html",
        controller: "userHomeViewModel"
    })
    .when("user/list", {
        templateUrl: "/App/User/Views/UserListView.html",
        controller: "userListViewModel"
    })
    .when("user/show/:userId", {
        templateUrl: "/App/User/Views/UserView.html",
        controller: "userViewModel"
    })
    .otherwise({
        redirectTo: "/user"
    });

    $locationProvider.html5mode({
        enabled: true,
        requireBase: false
    });
});

userModule.factory("userService",
    function ($http, $location, viewModelHelper) {
        return MyApp.userService($http, $location, viewModelHelper);
    });

(function (myApp) {
    var userService = function ($http, $location, viewModelHelper) {
        var self = this;
        self.userId = 0;
        return this;
    }
    myApp.userService = userService;
} (window.MyApp));