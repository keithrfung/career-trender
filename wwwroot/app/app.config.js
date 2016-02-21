(function() {
    'use strict';
    
    angular.module('app').config(initrouter);
    
    function initrouter($stateProvider, $locationProvider, $urlRouterProvider){
        $locationProvider.html5Mode(true);
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state('home', 
                { 
                    url: '/', 
                    templateUrl:'app/home.html', 
                    controller: 'HomeController',
                    controllerAs: 'vm'
                }
            )
            .state('jobs', 
                { 
                    url: '/jobs', 
                    templateUrl:'app/jobs.html', 
                    controller: 'JobController',
                    controllerAs: 'vm'
                }
            )
    }
    
})();