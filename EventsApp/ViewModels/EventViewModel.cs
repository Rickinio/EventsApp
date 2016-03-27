using GogoKit.Models.Response;
using HalKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApp.ViewModels
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public Money MinTicketPrice { get; set; }
        public EmbeddedVenue Venue { get; set; }
        public Link WebPageLink { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public bool IsCoutryCheapest { get; set; }
    }

    public static class EventExtensionMethods
    {
        /// <summary>
        /// Extension Method to mark the cheapest ticket in each country
        /// </summary>
        public static List<EventViewModel> MarkCheapestEventByCountry(this List<EventViewModel> events) {
            var cheapestEventByCountry = events.GroupBy(e => e.Venue.Country.Code)
                                                .Select(e => e.OrderBy(x => x.MinTicketPrice.Amount))
                                                .Select(y => y.First());

            foreach (var e in cheapestEventByCountry) {
                e.IsCoutryCheapest = true;
            }

            return events;
        }
    }
}