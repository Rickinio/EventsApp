var eventsApp;
(function (eventsApp) {
    var common;
    (function (common) {
        var services;
        (function (services) {
            var ViagogoService = (function () {
                function ViagogoService($http) {
                    this.$http = $http;
                    this.baseUrl = "/api/Events";
                }
                ViagogoService.prototype.getList = function () {
                    return this.$http.get(this.baseUrl + "/Get");
                };
                ViagogoService.$inject = ["$http"];
                return ViagogoService;
            }());
            services.ViagogoService = ViagogoService;
            eventsApp.services.service("ViagogoService", ViagogoService);
        })(services = common.services || (common.services = {}));
    })(common = eventsApp.common || (eventsApp.common = {}));
})(eventsApp || (eventsApp = {}));
//# sourceMappingURL=ViagogoService.js.map