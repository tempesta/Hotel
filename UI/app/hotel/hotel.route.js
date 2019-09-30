(function () {
    'use strict';

    angular
        .module('app.hotel')
        .config(Routes);

        Routes.$inject = ['$routeProvider'];

        function Routes($routeProvider) {
            $routeProvider

                .when('/', {
                    templateUrl: 'app/hotel/hotel.consultar.html',
                    controller: 'HotelConsultarCtrl',
                    controllerAs: 'view'
                })
                .when('/hotel/cadastrar/', {
                    templateUrl: 'app/hotel/hotel.formulario.html',
                    controller: 'HotelCadastrarCtrl',
                    controllerAs: 'hotel'
                })
                .when('/hotel/editar/:id', {
                    templateUrl: 'app/hotel/hotel.formulario.html',
                    controller: 'HotelEditarCtrl',
                    controllerAs: 'hotel'
                })
                .otherwise('/');
        }
})();