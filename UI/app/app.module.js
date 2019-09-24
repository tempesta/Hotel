(function() {

    'use strict';

    angular.module('app', [
        'app.core',
        'app.hotel',
        'app.services',   
        'app.constants',    
    ]);

    angular.module('app.core', [
        'ngRoute',
    ]);

    angular.module('app').run(Run);

    Run.$inject = ['$rootScope'];

    function Run($rootScope) {
        $rootScope.$on();
    }

})();