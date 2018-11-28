function dashboardCtrl($http) {
    var ctrl = this;

    ctrl.Title = "Ghost Game";   

    ctrl.newGame = function () {

        $http({
            method: 'POST',
            url: '/WebService/GameWS.asmx/StartGame'           
        }).then(function successCallback(response) {
            console.log(response);
            ctrl.word = response.data.currentWord;
            ctrl.gameOver = false;
            ctrl.humanScore = ctrl.cpuScore = "_ _ _ _ _";
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

        if (data.humanScore > 0) {
            var hScore = data.humanScore - 1;
            ctrl.humanScore = ctrl.humanScore.substr(0, hScore * 2) + array[hScore] + ctrl.humanScore.substr(hScore * 2 + 1);
        }

        if (data.cpuScore > 0) {
            var cpuScore = data.cpuScore - 1;
            ctrl.cpuScore = ctrl.cpuScore.substr(0, cpuScore * 2) + array[cpuScore] + ctrl.cpuScore.substr(cpuScore * 2 + 1);
        }


    }
    ctrl.testWS = function () {
          
        $http({
            method: 'POST',
            url: '/WebService/GameWS.asmx/PlayerInput',
            params: { input: ctrl.suffix}
        }).then(function successCallback(response) {
            ctrl.suffix = "";
            ctrl.updateScoring(response.data);
            ctrl.isGameOver(response.data);
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
    ctrl.isGameOver = function(answer) {
        ctrl.gameOver = answer.isGameOver;
        ctrl.word = (answer.isGameOver == true) ? "GAME OVER" : answer.currentWord;
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
