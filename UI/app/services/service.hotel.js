(function () {
    
    'use strict';

    angular
        .module('app.services')
        .service('HotelService', HotelService);

        HotelService.$inject = ['Constantes', '$http'];

    function HotelService(Constantes, $http) {
        let hotelService = {};

        hotelService.cadastrar = cadastrar;
        hotelService.alterar = alterar;
        hotelService.excluir = excluir;
        hotelService.pesquisar = pesquisar;
        hotelService.carregar = carregar;

        function cadastrar(hotelDto) {
            return $http.post({
                url : `${Constantes.url}/hotel/cadastrar`,
                method: "POST",
                data: {envelope: JSON.stringify(hotelDto)},
            });
        }

        function alterar(hotelDto) {
            return $http.post({
                url : `${Constantes.url}/hotel/alterar`,
                method: "POST",
                data: angular.toJson(hotelDto),
            });
        }

        function excluir(hotelDto) {
            return $http.post({
                url: `${Constantes.url}/hotel/excluir`,
                method: "POST",
                data: hotelDto
            });
        }

        function pesquisar(filtro) {
            return $http.get({
                url: `${Constantes.url}/hotel/excluir`,
                method: "POST",
                data: filtro,
            });
        }

        function carregar(id) {
            return $http.get(`${Constantes.url}/hotel/carregar?id=${id}`);
        }

        return hotelService;
    }
    
})();