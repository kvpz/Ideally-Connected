var userModule = angular.module("user", ["common"]);

// User routes
userModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when("/analysis", { 
        templateUrl: "/App/Users/Views/UserHomeView.html",
        controller: "userHomeViewModel"
    })
    $routeProvider.when("/analysis/user/list", {
        templateUrl: "/App/Users/Views/UserListView.html",
        controller: "userListViewModel"
    })
    $routeProvider.when("analysis/user/show/:userId", {
        templateUrl: "/App/Users/Views/UserView.html",
        controller: "userViewModel"
    })
    $routeProvider.otherwise({
        redirectTo: "/analysis"
    });
    $locationProvider.html5Mode({
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
}(window.MyApp));
