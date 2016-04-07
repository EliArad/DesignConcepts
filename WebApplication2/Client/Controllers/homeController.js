'use strict';

app.controller('homeController', ['$scope', '$state','$http',
    function ($scope, $state, $http) {

        var vm = this;
        vm.user = {
            
        };

        

        

        $scope.submitForm = function(valid)
        {
             

            $http.post('Employees.asmx/AddNewEmployee', {email: vm.user.email,  data: vm.user }).then(function (result) {
                console.log(result.data.d);
                var s = JSON.parse(result.data.d);               
                $scope.$broadcast("updateDisplay", 'eeee');
            }).catch(function (result) {
                console.log(result);
            })            
        }
    }
]);