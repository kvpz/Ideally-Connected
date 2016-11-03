angular.module('d3', [])
    .factory('d3Service', [function(){
        var d3;
        // insert d3 code here
        return d3;
    }]);

// inject d3 service into app module as a dependency
angular.module('app', ['d3']);

angular.module('myApp.directives', ['d3'])
    .directive('barChart', ['d3Service', function (d3Service) {
        return { restrict: 'EA' }
    }]);