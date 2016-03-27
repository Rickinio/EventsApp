module eventApps.events {

    declare var google: any;

    export class EventsListController {
        static $inject = ["events"];
        public totalItems: number = 0;
        public currentChunk: number = 0;
        public pagedEvents = [];
        public markers = [];

        constructor(public events: eventApp.models.Event[]) {
            if (events && events.length > 0) {
                this.totalItems = events.length;
                this.events[0].IsSelected = true;
                this.loadMore();
                this.createMap();
            }
        }

        loadMore = () => {
            if (this.events && this.events.length > 0){
                this.pagedEvents = this.pagedEvents.concat(this.events.slice(this.currentChunk, this.currentChunk + 25));
                this.currentChunk = this.currentChunk + 25;
            }
        }

        createMap = () => {
            var self = this;

            var myLatLng = { lat: -25.363, lng: 131.044 };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 5,
                center: { lat: this.events[0].Venue.Latitude, lng: this.events[0].Venue.Longitude }
            });

            this.events.forEach(function (e: eventApp.models.Event) {
                var myLatLng = { lat: e.Venue.Latitude, lng: e.Venue.Longitude };
                var contentString = '<h3>'+ e.Name +'</h3><p>' + e.Venue.Name + '</p>'

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
            })
        }

        centerMap = (index) => {
            new google.maps.event.trigger(this.markers[index], 'click');
            this.events.forEach(function (e) {
                e.IsSelected = false;
            })
            this.events[index].IsSelected = true;
        }

    }

    eventsApp.events.mainModule.controller("EventsListController", EventsListController)

} 