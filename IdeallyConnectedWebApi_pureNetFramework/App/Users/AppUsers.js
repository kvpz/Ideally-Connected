// consider moving this to appUsers.module.js
var userModule = angular.module("user", ["common"]);

// User routes (consider moving to a file named appUsers.config.js
userModule.config(function ($routeProvider, $locationProvider) {
    //$locationProvider.hashPrefix("!"); // appears on client-side routes
    $routeProvider.when("/analysis", {
        templateUrl: "/App/Users/Views/UserHomeView.html",
        controller: "userHomeViewModel"
    });
    $routeProvider.when("/analysis/userlist", {
        templateUrl: "/App/Users/Views/UserListView.html",
        controller: "userListViewModel"
    });
    $routeProvider.when("analysis/user/show/:userId", {
        templateUrl: "/App/Users/Views/UserView.html",
        controller: "userViewModel"
    });
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
    };
    myApp.userService = userService;
}(window.MyApp));
