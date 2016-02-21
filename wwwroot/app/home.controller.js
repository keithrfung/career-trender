(function() {
    'use strict';
    
    angular
        .module('app')
        .controller('HomeController', HomeController);
        
        //HomeController.$inject = ['$scope'];
        HomeController.$inject = ['$scope', '$http'];
        function HomeController($scope, $http) {
            var vm = this;
            
            vm.jobs = [];
            
            activate();
            
            function activate() 
            {
                //Perform any necessary initialization here...
            }
                     
            $scope.message = "";
                     
            $scope.Search = function () {
                $scope.message = 'Searching for: ' + $scope.query;
                                
                var parameters = {
                    keyword: $scope.query
                };
                
                var config = {
                    params: parameters
                };                                
                                
                $http.get('/api/job', config)
                .then(function(response) {
                    $scope.vm.jobs = response.data;
                    $scope.message = 'Showing results for: ' + $scope.query;
                    
                    if ($scope.vm.jobs.length == 0)
                    {
                        $scope.message = 'No results for: ' + $scope.query;
                    }
                })
                .catch(function(err) {
                    console.log(err);
                })
            }          
        }        
})();