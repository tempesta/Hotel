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
            return $http.post({
                url : `${Constantes.url}/hotel/alterar`,
                method: "POST",
                data: angular.toJson(hotelDto),
            });
        }

        function excluir(id) {
            return $http.post({
                url: `${Constantes.url}/hotel/excluir`,
                method: "POST",
                data: id
            });
        }

        function pesquisar(filtro) {
            return $http({
                url: `${Constantes.url}/hotel/Pesquisar`,
                method: 'POST',
                data: filtro
            });
        }

        function carregar(id) {
            return $http.get(`${Constantes.url}/hotel/carregar?id=${id}`);
        }

        return hotelService;
    }
    
})();