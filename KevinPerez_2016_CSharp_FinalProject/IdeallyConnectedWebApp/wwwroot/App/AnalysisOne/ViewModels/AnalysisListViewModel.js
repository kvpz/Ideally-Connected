/*
    The Table of Details
*/
analysisModule.controller("analysisListViewModel", function ($scope, analysisService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.analysisService = analysisService;

    var initialize = function () {
        $scope.refreshAnalysis();
    }

    $scope.refreshAnalysis = function () { 
        viewModelHelper.apiGet('list/analysis', null, function (result) {
                $scope.analysis = result.data;
            });
    }

    $scope.showAnalysis = function (analysis) {
        $scope.flags.shownFromList = true; 
        viewModelHelper.navigateTo('analysis/show/' + analysis.AnalysisID);
    }

    initialize();
});
