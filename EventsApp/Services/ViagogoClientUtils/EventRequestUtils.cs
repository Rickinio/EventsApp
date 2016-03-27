using GogoKit.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApp.Code.ViagogoClientUtils
{
    public static class EventRequestUtils
    {
        ///<summary>
        ///Sets the page to 1, page size to 30 and sort option MinTicketPrice Ascending
        ///</summary>
        public static EventRequest SetPagingAndSorting(this EventRequest request) {
            //var sortOptions = new List<Sort<EventSort>>();
            //sortOptions.Add(new Sort<EventSort>(EventSort.MinTicketPrice, SortDirection.Ascending));

            request.Page = 1;
            request.PageSize = 30;
            //request.Sort = sortOptions;

            return request;
        }
    }
}