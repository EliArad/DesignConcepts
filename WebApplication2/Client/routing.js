app.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', '$locationProvider',
            function ($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider) {

                $urlRouterProvider.otherwise('/');

                $stateProvider.state('/', {
                    url: '/',
                    templateUrl: '/Client/Views/home.html'
                });

                $locationProvider.html5Mode(true);
}]);

