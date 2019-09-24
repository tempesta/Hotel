(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelCadastrarCtrl', HotelCadastrarCtrl);

        HotelCadastrarCtrl.$inject = ['$routeParams', '$location', 'HotelService'];

    function HotelCadastrarCtrl($routeParams, $location, HotelService) {
        let vm = this;

        vm.comodidades = [
            {
                'id': 1,
                'nome': 'Estacionamento'
            },
            {
                'id': 2,
                'nome': 'Piscina'
            },
            {
                'id': 3,
                'nome': 'Sauna'
            },
            {
                'id': 4,
                'nome': 'Wi-fi'
            },
            {
                'id': 5,
                'nome': 'Bar'
            }
        ];

        vm.envelope = {};
        vm.cadastrar = cadastrar;

        function cadastrar() {
            vm.envelope.Comodidades = Object.keys(vm.selectedComodidades).toString();
            HotelService.cadastrar(vm.envelope)
            .then(() => {alert("Cadastrado")})
            .catch((resultado) => alert(resultado.toString()));
        }
    }

})();