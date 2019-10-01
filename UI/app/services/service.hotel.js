(function () {
    
    'use strict';

    angular
        .module('app.services')
        .service('HotelService', HotelService);

        HotelService.$inject = ['$http','Constantes'];

    function HotelService($http, Constantes) {
        let hotelService = {};

        hotelService.cadastrar = cadastrar;
        hotelService.alterar = alterar;
        hotelService.excluir = excluir;
        hotelService.pesquisar = pesquisar;
        hotelService.carregar = carregar;

        function cadastrar(hotelDto) {
            return $http.post(`${Constantes.url}/hotel/Cadastrar`, hotelDto);
        }

        function alterar(hotelDto) {
            return $http.post(`${Constantes.url}/hotel/alterar`, hotelDto);
        }

        function excluir(id) {
            return $http.post(`${Constantes.url}/hotel/excluir`, id);
        }

        function pesquisar(filtro) {
            return $http.post(`${Constantes.url}/hotel/Pesquisar`, filtro);
        }

        function carregar(id) {
            return $http.get(`${Constantes.url}/hotel/Buscar?id=${id}`);
        }

        return hotelService;
    }
    
})();