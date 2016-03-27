var eventsApp;
(function (eventsApp) {
    eventsApp.services = angular.module("eventsApp.services", []);
    eventsApp.app = angular.module("eventsApp", ["ui.router", "infinite-scroll", "eventsApp.events", "eventsApp.services"]);
    eventsApp.app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
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
})(eventsApp || (eventsApp = {}));
//# sourceMappingURL=Application.js.map