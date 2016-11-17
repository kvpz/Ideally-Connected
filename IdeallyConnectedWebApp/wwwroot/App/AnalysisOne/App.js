var analysisModule = angular.module('analysis', ['common']);

analysisModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/analysis', {
        templateUrl: '/App/AnalysisOne/Views/AnalysisHomeView.html',
        controller: 'analysisHomeViewModel'
    });
    $routeProvider.when('/analysis/list', {
        templateUrl: 'analysis/list'//, //'/App/AnalysisOne/Views/AnalysisListView.html',
        //controller: 'analysisListViewModel'
    });
    $routeProvider.when('/analysis/show/:analysisID', {
        templateUrl: '/App/Analysis/Views/AnalysisView.html',
        controller: 'analysisViewModel'
    });
    $routeProvider.when('Home/DataAnalysisOne', {
        templateUrl: '/Home/DataAnalysisOne',
        controller: 'analysisListViewModel'
    });
    $routeProvider.otherwise({
        redirectTo: '/analysis'
    });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

analysisModule.factory('analysisService', function ($http, $location, viewModelHelper) {
        return MyApp.analysisService($http, $location, viewModelHelper);
    });

(function (myApp) {
    var analysisService = function ($http, $location, viewModelHelper) {
        var self = this;
        self.analysisID = 0;

        return this;
    };
    myApp.analysisService = analysisService;
}(window.MyApp));
