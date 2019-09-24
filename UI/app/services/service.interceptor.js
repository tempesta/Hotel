(function() {

    'use strict';

    angular
        .module('app.services')
        .service('InterceptorService', InterceptorService);

    InterceptorService.$inject = ['$q'];

    function InterceptorService($q) {
        return {
            'request': function(config) {
                return config;
            },
            'response': function(response) {
                return response;
            },
           'requestError': function(rejection) {
                return $q.reject(rejection);
            },
           'responseError': function(rejection) {
                return $q.reject(rejection);
            }
        };
    }

})();