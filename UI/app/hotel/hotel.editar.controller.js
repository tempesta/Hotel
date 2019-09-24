(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelEditarCtrl', HotelEditarCtrl);

        HotelEditarCtrl.$inject = ['$routeParams', '$location', 'HotelService'];

    function HotelEditarCtrl($routeParams, $location, HotelService) {
        let vm = this;
    }

})();