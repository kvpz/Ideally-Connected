/*D3js wrapper*/
angular.module('D3js',[]).factory('d3', [
    '$window',
    function ($window) {
        var d3 = $window.d3;
        return d3;
    }
]);
