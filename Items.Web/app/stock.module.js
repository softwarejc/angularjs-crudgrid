var stockModule = angular.module('stockModule', [
    'ui.router',
    'ui.bootstrap',
    'ngResource'
]);

stockModule.
    config(function ($stateProvider, $urlRouterProvider) {

        // For any unmatched URL redirect to dashboard URL
        $urlRouterProvider.otherwise("/items");

        $stateProvider
            // Known items
            .state('items', {
                url: "/items",
                views: {
                    'main': {
                        templateUrl: "app/items/items.view.html",
                        controller: "itemsController as itemsCtrl"
                    }
                },
            });

    });


