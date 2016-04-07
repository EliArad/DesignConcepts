app.directive('tableViewer', function ($http, $filter, $window, api) {
    return {
        restrict:'AE',
        templateUrl: '/Client/Directives/Templates/view.html',
        scope: {
            
        },
        link: function (scope, element, attr) {

            var myStr = attr.schema;
            var customer = eval("new " + attr.schema + "()");

            var schema = customer.getView();
            scope.headerSchema = schema;

            function display()
            {
                api.getView(attr.schema).then(function (result) {
                    scope.dataView = result.data;
                }).catch(function (result) {
                    console.log('error');
                })
            }

            scope.$on("updateDisplay", function (event, args) {
                display()
            });

            display();
        }


    };
});


