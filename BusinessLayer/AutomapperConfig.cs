using AutoMapper;
using BusinessLayer.DTO;
using DataLayer.Models;
using System;


namespace BusinessLayer
{
    static class AutomapperConfig
    {
        internal static MapperConfiguration Config {
            get {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Visitor, VisitorDTO>();
                    cfg.CreateMap<Room, RoomDTO>();
                    cfg.CreateMap<VisitorDTO, Visitor>();
                    cfg.CreateMap<RoomDTO, Room>();
                }
                ); 
                
            }
        }
    }
}
