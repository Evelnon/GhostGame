function dashboardCtrl($http) {
    var ctrl = this;

    ctrl.Title = "Hola Mundo";    
}


mainApp.component('dashboard',
        {
            templateUrl: '../Views/dashboard.template.html',
            controller: dashboardCtrl,
            controllerAs: 'dashboardCtrl'

        });

    mainApp.config(function ($routeProvider) {
        $routeProvider.when('/dashboard/',
            {
                template: '<dashboard></dashboard>'
            });
    });
