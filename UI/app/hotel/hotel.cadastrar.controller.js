(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelCadastrarCtrl', HotelCadastrarCtrl);

        HotelCadastrarCtrl.$inject = ['$routeParams', '$location', 'HotelService', 'Constantes'];

    function HotelCadastrarCtrl($routeParams, $location, HotelService, Constantes) {
        let vm = this;

        vm.titulo = "Cadastrar novo Hotel";
        vm.comodidades = Constantes.comodidades;

        vm.envelope = {};
        vm.cadastrar = cadastrar;
        vm.voltar = voltar;

        function cadastrar() {
            vm.envelope.comodidades = Array.from(vm.comodidadesIds, comodidade => comodidade= { 'id':comodidade });
            HotelService.cadastrar(vm.envelope)
            .then(() => {
                vm.envelope = {};
                vm.comodidadesIds = [];
                alert("Cadastro realizaco com sucesso!")
            },() => alert("Erro ao cadastrar hotel"));
        }

        function voltar() {
            $location.path("/hotel");
        }
    }

})();