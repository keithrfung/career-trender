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
                //$http.get('http://api.indeed.com/ads/apisearch?publisher=1686088457887041&q=java&l=austin&chnl=&userip=1.2.3.4&useragent=Mozilla/%2F4.0%28Firefox%29&v=2')
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