analysisModule.controller("analysisViewModel", function ($scope, analysisService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.analysisService = analysisService;

    var initialize = function () {
        $scope.refreshAnalysis($routeParams.analysisID);
    }

    $scope.refreshAnalysis = function (analysisID) {
        viewModelHelper.apiGet('api/analysis/' + analysisID, null, function (result) {
                analysisService.analysisID = analysisID;
                $scope.analysis = result.data;
            });
    }

    initialize();
});
