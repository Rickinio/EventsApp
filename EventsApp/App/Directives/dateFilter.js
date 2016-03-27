var eventsApp;
(function (eventsApp) {
    var filters;
    (function (filters) {
        eventsApp.app.filter("dateToIso", function () {
            return function (input) {
                input = new Date(parseInt(input.substr(6)));
                return input;
            };
        });
    })(filters = eventsApp.filters || (eventsApp.filters = {}));
})(eventsApp || (eventsApp = {}));
//# sourceMappingURL=dateFilter.js.map