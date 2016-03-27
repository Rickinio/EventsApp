using AutoMapper;
using EventsApp.ViewModels;
using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApp.Code.App_Config
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings() {
            Mapper.CreateMap<Event, EventViewModel>();
        }
    }
}