module eventsApp.filters {
    eventsApp.app.filter("dateToIso", function () {
        return function (input) {
            input = new Date(parseInt(input.substr(6)))
            return input;
        };
    })
}