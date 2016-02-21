(function() {
    'use strict';
    
    angular
        .module('app')
        .controller('JobController', JobController);
        
        JobController.$inject = ['$http'];
        function JobController($http) {
            var vm = this;
            
            vm.jobs = [];
            
            activate();
            
            function activate() {
                $http.get('/api/job')
                .then(function(response) {
                    vm.jobs = response.data;
                })
                .catch(function(err) {
                    console.log(err);
                })
            }                    
        }
})();