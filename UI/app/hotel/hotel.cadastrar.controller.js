(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelCadastrarCtrl', HotelCadastrarCtrl);

        HotelCadastrarCtrl.$inject = ['$routeParams', '$location', 'HotelService'];

    function HotelCadastrarCtrl($routeParams, $location, HotelService) {
        let vm = this;

        vm.titulo = "Cadastrar novo Hotel";
        vm.comodidades = [
            {
                'Id': 1,
                'Nome': 'Estacionamento'
            },
            {
                'Id': 2,
                'Nome': 'Piscina'
            },
            {
                'Id': 3,
                'Nome': 'Sauna'
            },
            {
                'Id': 4,
                'Nome': 'Wi-fi'
            },
            {
                'Id': 5,
                'Nome': 'Restaurante'
            },
            {
                'Id': 6,
                'Nome': 'Bar'
            }
        ];

        vm.envelope = {};
        vm.cadastrar = cadastrar;
        vm.voltar = voltar;

        function cadastrar() {
            HotelService.cadastrar(vm.envelope)
            .then(() => {
                vm.envelope = {};
                alert("Cadastro realizaco com sucesso!")
            })
            .catch((resultado) => alert(resultado.toString()));
        }

        function voltar() {
            $location.path("/hotel");
        }
    }

})();