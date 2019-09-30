(function() {

    'use strict';

    angular
        .module('app.services')
        .config(Interceptor)
        .service('InterceptorService', InterceptorService);
    
    Interceptor.$inject = ['$httpProvider'];
    
    function Interceptor($httpProvider) {
        $httpProvider.interceptors.push('InterceptorService');     
    }

    InterceptorService.$inject = ['$q'];

    function InterceptorService($q) {

        return {
            'request': function(config) {
                if(config.method === 'POST')
                    config.headers["Content-Type"] = "application/json";
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