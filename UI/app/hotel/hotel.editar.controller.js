(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelEditarCtrl', HotelEditarCtrl);

        HotelEditarCtrl.$inject = ['$routeParams', '$location', 'HotelService', 'Constantes'];

    function HotelEditarCtrl($routeParams, $location, HotelService, Constantes) {
        let vm = this;
        vm.editar = true;

        vm.envelope = {
            Id: $routeParams.id
        };

        vm.titulo = "Alterar Hotel";
        vm.comodidades = Constantes.comodidades;
        vm.carregarHotel = carregarHotel;
        vm.alterar = alterar;
        vm.voltar = voltar;

        carregarHotel(vm.envelope.Id);

        function carregarHotel(id) {
            HotelService.carregar(id)
                .then((response) => {
                    vm.envelope = response.data;
                    vm.comodidadesIds = Array.from(response.data.comodidades, comodidade => comodidade.id);
                }, () => alert("Erro ao carregar hotel."));
        }

        function alterar() {
            vm.envelope.comodidades = Array.from(vm.comodidadesIds, comodidade => comodidade= { 'id':comodidade })
            HotelService.alterar(vm.envelope)
                .then(() => {
                    vm.envelope = {};
                    vm.comodidadesIds = [];
                    alert("Alteração concluída com sucesso!");
                    $location.path('/');
                }, () => alert("Erro ao carregar hotel."));
        }

        function voltar() {
            $location.path('/hotel');
        }
    }

})();