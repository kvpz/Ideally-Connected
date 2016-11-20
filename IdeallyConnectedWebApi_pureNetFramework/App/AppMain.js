var commonModule = angular.module("common", ["ngRoute"]);
var mainModule = angular.module("main", ["common"]);

commonModule.factory("viewModelHelper", function ($http, $q, $window, $location) {
    return MyApp.viewModelHelper($http, $q, $window, $location);
});

commonModule.factory("validator", function () {
    return valJs.validator();
});

mainModule.controller("indexViewModel", function ($scope, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    var self = this;
    $scope.topic = "Data Mining a network with ASP.NET and AngularJS";
    $scope.author = "Kevin Perez";
});


/*
mainModule.controller("analysisViewSelection", function ($scope, $http) {
    $scope.selection = 1;
    $scope.selectionResponse = function () {
        return 1;
    };
});
*/
/*
    This is an immediately invoked anonymous function. The () closures make this a function expression. 
    Also look into javascript closures
    It is a special object that combines two things: a function and the environment in which that function was created.
    The environment consists of any local variables that were in scope at the time that the closure was created.
    http://www.adequatelygood.com/JavaScript-Module-Pattern-In-Depth.html

    Note that MyApp.rootPath is defined in _layout.cshtml
*/
(function (myApp) {
    var viewModelHelper = function ($http, $q, $window, $location) {
        var self = this;
        self.modelIsValid = true;
        self.modelErrors = [];

        self.resetModelErrors = function () {
            self.modelErrors = [];
            self.modelIsValid = true;
        }

        self.apiGet = function (uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.get(MyApp.rootPath + uri, data).then(
                function (result) {
                    success(result);
                    if (always != null) always();
                },
                function (result) {
                    if (failure != null) failure(result);
                    else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null) {
                            if (result.data.Message != null) errorMessage += ' - ' + result.data.Message;
                            if (result.data.ExceptionMessage != null) errorMessage += ' - ' + result.data.ExceptionMessage;
                        }
                        self.ModelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }

                    if (always != null) always();
                });
        } // self.apiGet 

        self.apiPost = function (uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.post(MyApp.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                }, function (result) {
                    if (failure != null) {
                        failure(result);
                    }
                    else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null) {
                            if (result.data.Message != null)
                                errorMessage += ' - ' + result.data.Message;
                            if (result.data.ExceptionMessage != null)
                                errorMessage += ' - ' + result.data.ExceptionMessage;
                        }
                    }
                    if (always != null)
                        always();
                });
        }

        self.goBack = function () {
            $window.history.back();
        }

        self.navigateTo = function (path, params) {
            if (params == null)
                $location.path(MyApp.rootPath + path);
            else
                $location.path(MyApp.rootPath + path).search(params);
        }

        self.refreshPage = function (path) {
            $window.location.href = MyApp.rootPath + path;
        }

        self.clone = function (obj) {
            return JSON.parse(JSON.stringify(obj))
        }

        self.querystring = function (param) {
            if ($location.search != null)
                return $location.search()[param];
            else
                return null;
        }

        self.resetQueryParams = function () {
            $location.url($location.path());
        }

        return this;
    };
    myApp.viewModelHelper = viewModelHelper;
}) (window.MyApp);

