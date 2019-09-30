(function () {

    'use strict';

    angular
        .module('app.services', ['app.core'])
        .config(['$httpProvider', Interceptor]);
        
        function Interceptor($httpProvider) {
            $httpProvider.interceptors.push('InterceptorService');     
        }
        
})();