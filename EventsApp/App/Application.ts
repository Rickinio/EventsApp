module eventsApp {
    export var services: ng.IModule = angular.module("eventsApp.services", []);
    export var app: ng.IModule = angular.module("eventsApp", ["ui.router", "infinite-scroll", "eventsApp.events", "eventsApp.services"]);

    app.config(["$stateProvider","$urlRouterProvider",function ($stateProvider:ng.ui.IStateProvider, $urlRouterProvider:ng.ui.IUrlRouterProvider) {
        
        $urlRouterProvider.otherwise("/list");
        
        $stateProvider
            .state('root', {
                url: "",
                abstract: true,
                template: '<div data-ui-view=""></div>'
            })
            .state('root.error', {
                url: "/error",
                templateUrl: 'Main/Error'
            });

    }]);
} 