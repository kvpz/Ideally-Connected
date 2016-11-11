analysisModule.controller("rootViewModel", function ($scope, analysisService, $http, viewModelHelper) {
        // This is the parent controller/viewmodel for 'analysisModule' and its $scope is accesible
        // down controllers set by the routing engine. This controller is bound to the Analysis.cshtml in the
        // Home view-folder.
        $scope.viewModelHelper = viewModelHelper;
        $scope.analysisService = analysisService;
        $scope.flags = { shownFromList: false };

        var initialize = function () {
            $scope.pageHeading = "Dashboard";
        }

        $scope.analysisList = function () {
            // $.get("/Home/index"), function (data) { $("p").html(data); }
            // App.js(global) -> App.js -> AnalysisViewModel.js -> AnalysisListView.html
            viewModelHelper.navigateTo('analysis/list'); // $location.path(MyApp.rootPath + "home/index").search(params);

        }

        $scope.showAnalysis = function () {
            if (analysisService.analysisID != 0) {
                $scope.flags.shownFromList = false;
                viewModelHelper.navigateTo('analysis/show/' + analysisService.analysisID);
            }
        }

        initialize();
    });

/*
    AngularJS controller parameters are dependencies injected by AngularJS injector service. When the parameters are
    being read by AngularJS, it searches for registered services with that name which is then provided as the parameter
    when the function is called.
*/