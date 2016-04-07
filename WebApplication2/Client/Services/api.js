'use_strict'

app.factory("api", ['$http', '$q',
    function ($http, $q) {
              
        var getView = function (name) {
          
            return $http.get('Employees.asmx/getAllEmployees');
        }
        return {
            getView: getView
        };
    }
]);
