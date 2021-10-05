using AutoMapper;
using BusinessLayer.DTO;
using Nix_Task2.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nix_Task2
{
    static class AutomapperConfig
    {
        internal static MapperConfiguration Config
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VisitorDTO, VisitorView>();
                    cfg.CreateMap<RoomDTO, RoomView>();
                    cfg.CreateMap<VisitorView, VisitorDTO>();
                    cfg.CreateMap<RoomView, RoomDTO>();
                }
                );

            }
        }
    }
}
