(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelConsultarCtrl', HotelConsultarCtrl);

        HotelConsultarCtrl.$inject = ['$route', '$routeParams', '$location', 'HotelService'];

    function HotelConsultarCtrl($route, $routeParams, $location, HotelService) {
        let vm = this;

        vm.hoteis = [];
        vm.filtro = {};
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


        vm.cadastrar = cadastrar;
        vm.editar = editar;
        vm.excluir = excluir;
        vm.pesquisar = pesquisar

        pesquisar();

        function cadastrar() {
            $location.path('/hotel/cadastrar');
        }

        function editar(id) {
            $location.path(`/hotel/editar/${id}`);
        }

        function excluir(id) {
            HotelService.excluir(id)
                .then($route.reload())
                .catch(alert("Erro ao excluir o hotel."));
        }

        function pesquisar() {
            HotelService.pesquisar(vm.filtro)
                .then(response => vm.hoteis = response.data)
                .catch(() => alert("Erro ao pesquisar"));
        }
    }

})();