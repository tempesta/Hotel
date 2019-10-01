(function () {
    'use strict';

    angular
        .module('app.constants', [])
        .constant('Constantes', {
            url: 'http://localhost:5000',
            comodidades : [
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
            ]
        });
})();