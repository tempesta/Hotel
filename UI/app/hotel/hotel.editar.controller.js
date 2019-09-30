(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelEditarCtrl', HotelEditarCtrl);

        HotelEditarCtrl.$inject = ['$routeParams', '$location', 'HotelService'];

    function HotelEditarCtrl($routeParams, $location, HotelService) {
        let vm = this;
        vm.envelope = {
            Id: $routeParams.id
        };
        vm.carregarHotel = carregarHotel;
        vm.alterar = alterar;
        vm.voltar = voltar;

        carregarHotel(vm.envelope.Id);

        function carregarHotel(id) {
            HotelService.carregar(id)
                .then((response) => {
                    vm.envelope = response.data;
                })
                .catch($dialog.open("Erro ao carregar hotel."));
        }

        function alterar() {
            HotelService.alterar(vm.envelope)
                .then(() => {
                    $dialog.open("Alteração concluída com sucesso!");
                })
                .catch(
                    $dialog.open("Erro ao alterar hotel.")
                );
        }

        function voltar() {
            $location.path('/hotel');
        }
    }

})();