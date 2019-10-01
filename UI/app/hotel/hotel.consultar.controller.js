(function () {
    'use strict';

    angular
        .module('app.hotel')
        .controller('HotelConsultarCtrl', HotelConsultarCtrl);

        HotelConsultarCtrl.$inject = ['$route', '$routeParams', '$location', 'HotelService', 'Constantes'];

    function HotelConsultarCtrl($route, $routeParams, $location, HotelService, Constantes) {
        let vm = this;

        vm.hoteis = [];
        vm.filtro = {};
        vm.comodidades = Constantes.comodidades;

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
            if(window.confirm("Deseja realmente excluir este hotel?")) {
                HotelService.excluir(id)
                    .then(() => $route.reload(), () => alert("Erro ao excluir o hotel."))
            }
        }

        function pesquisar() {
            HotelService.pesquisar(vm.filtro)
                .then((response) => {
                    vm.hoteis = response.data
                }, () => {alert("Erro ao excluir o hotel.")});
        }
    }

})();