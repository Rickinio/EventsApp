var eventApps;
(function (eventApps) {
    var events;
    (function (events_1) {
        var EventsListController = (function () {
            function EventsListController(events) {
                var _this = this;
                this.events = events;
                this.totalItems = 0;
                this.currentChunk = 0;
                this.pagedEvents = [];
                this.markers = [];
                this.loadMore = function () {
                    if (_this.events && _this.events.length > 0) {
                        _this.pagedEvents = _this.pagedEvents.concat(_this.events.slice(_this.currentChunk, _this.currentChunk + 25));
                        _this.currentChunk = _this.currentChunk + 25;
                    }
                };
                this.createMap = function () {
                    var self = _this;
                    var myLatLng = { lat: -25.363, lng: 131.044 };
                    var map = new google.maps.Map(document.getElementById('map'), {
                        zoom: 5,
                        center: { lat: _this.events[0].Venue.Latitude, lng: _this.events[0].Venue.Longitude }
                    });
                    _this.events.forEach(function (e) {
                        var myLatLng = { lat: e.Venue.Latitude, lng: e.Venue.Longitude };
                        var contentString = '<h3>' + e.Name + '</h3><p>' + e.Venue.Name + '</p>';
                        var infowindow = new google.maps.InfoWindow({
                            content: contentString
                        });
                        var marker = new google.maps.Marker({
                            position: myLatLng,
                            map: map,
                            title: e.Venue.Name
                        });
                        marker.addListener('click', function () {
                            infowindow.open(map, marker);
                            map.setCenter(marker.getPosition());
                        });
                        self.markers.push(marker);
                    });
                };
                this.centerMap = function (index) {
                    new google.maps.event.trigger(_this.markers[index], 'click');
                    _this.events.forEach(function (e) {
                        e.IsSelected = false;
                    });
                    _this.events[index].IsSelected = true;
                };
                if (events && events.length > 0) {
                    this.totalItems = events.length;
                    this.events[0].IsSelected = true;
                    this.loadMore();
                    this.createMap();
                }
            }
            EventsListController.$inject = ["events"];
            return EventsListController;
        }());
        events_1.EventsListController = EventsListController;
        eventsApp.events.mainModule.controller("EventsListController", EventsListController);
    })(events = eventApps.events || (eventApps.events = {}));
})(eventApps || (eventApps = {}));
//# sourceMappingURL=EventsList.js.map