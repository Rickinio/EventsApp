module eventsApp.events {
    export var mainModule: ng.IModule = angular.module("eventsApp.events", []);

    mainModule.config(function ($stateProvider, $urlRouterProvider) {
       
        // Set up the states
        $stateProvider
            .state('root.events', {
                url: "/list",
                templateUrl: "Templates/Features/Events/List",
                controller: "EventsListController as vm",
                resolve: {
                    events: ["$state","ViagogoService", function ($state:ng.ui.IStateService,ViagogoService: eventsApp.common.services.IViagogoService) {
                        return ViagogoService.getList()
                            .then(function (response) {
                                if (response.status == 200) {
                                    return response.data
                                }
                                else {
                                    $state.go("root.error");
                                }
                            }, function (err) {
                                $state.go("root.error");
                            })
                    }]
                }
            });

    });
}  