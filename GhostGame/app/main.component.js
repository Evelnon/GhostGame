// create the module and name it scotchApp
var mainApp = angular.module('mainApp',
    ['ngRoute']);


mainApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);