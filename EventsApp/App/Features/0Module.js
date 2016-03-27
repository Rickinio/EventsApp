var eventsApp;
(function (eventsApp) {
    var events;
    (function (events) {
        events.mainModule = angular.module("eventsApp.events", []);
        events.mainModule.config(function ($stateProvider, $urlRouterProvider) {
            // Set up the states
            $stateProvider
                .state('root.events', {
                url: "/list",
                templateUrl: "Templates/Features/Events/List",
                controller: "EventsListController as vm",
                resolve: {
                    events: ["$state", "ViagogoService", function ($state, ViagogoService) {
                            return ViagogoService.getList()
                                .then(function (response) {
                                if (response.status == 200) {
                                    return response.data;
                                }
                                else {
                                    $state.go("root.error");
                                }
                            }, function (err) {
                                $state.go("root.error");
                            });
                        }]
                }
            });
        });
    })(events = eventsApp.events || (eventsApp.events = {}));
})(eventsApp || (eventsApp = {}));
//# sourceMappingURL=0Module.js.map