(function() {

    'use strict';

    angular.module('app', [
        'app.core',
        'app.hotel',
        'app.services',   
        'app.constants',    
    ])
    .config(function($httpProvider) {
        $httpProvider.interceptors.push('InterceptorService');
    });

    angular.module('app.core', [
        'ngRoute',
        'checklist-model'
    ]);
    
    angular.module('app').run(Run);

    Run.$inject = ['$rootScope'];

    function Run($rootScope) {
        $rootScope.$on();
    }

})();