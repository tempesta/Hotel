(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelConsultarCtrl', HotelConsultarCtrl);

        HotelConsultarCtrl.$inject = ['$routeParams', '$location', 'HotelService'];

    function HotelConsultarCtrl($routeParams, $location, HotelService) {
        let vm = this;

        vm.hoteis = [
            {
                'id': 1,
                'Nome': 'Hotel Teste',
                'Avaliacao': '3'
            }
        ];
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


        vm.cadastrar = cadastrar;
        vm.editar = editar;
        vm.excluir = excluir;
        vm.pesquisar = pesquisar

        function cadastrar() {
            $location.path('/hotel/cadastrar');
        }

        function editar(id) {
            $location.path(`/hotel/editar/:${id}`);
        }

        function excluir() {
            alert("Abrir modal de exclusão de hotel");
        }

        function pesquisar() {
            alert("Pesquisar hotel");
        }
    }

})();