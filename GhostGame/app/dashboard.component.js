function dashboardCtrl($http) {
    var ctrl = this;

    ctrl.Title = "Ghost Game";   

    ctrl.newGame = function () {

        $http({
            method: 'GET',
            url: '/WebService/GameWS.asmx/StartGame'           
        }).then(function successCallback(response) {                     
            ctrl.word = response.data.currentWord;
            // this callback will be called asynchronously
            // when the response is available
        }, function errorCallback(response) {
            console.log(response);
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    }
    ctrl.updateScoring = function(data)
    {
        var array = ["G", "H", "O", "S", "T"];
        for (var x = 0; x < data.humanScore; x++) {
            
            ctrl.humanScore = ctrl.humanScore.replace(ctrl.humanScore.substring(x * 2, 1), array[x]);
        }
        for (var y = 0; y < data.cpuScore; y++) {
            ctrl.cpuScore += array[y];
        }
               
    }
    ctrl.testWS = function () {
          
        $http({
            method: 'GET',
            url: '/WebService/GameWS.asmx/PlayerInput',
            params: { input: ctrl.suffix}
        }).then(function successCallback(response) {
            ctrl.suffix = "";
            ctrl.updateScoring(response.data);
            ctrl.word = response.data.currentWord;
            // this callback will be called asynchronously
            // when the response is available
            }, function errorCallback(response) {
                console.log(response);
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    }

    ctrl.$onInit = function(){
        ctrl.humanScore = ctrl.cpuScore = "_ _ _ _ _";
    }
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
