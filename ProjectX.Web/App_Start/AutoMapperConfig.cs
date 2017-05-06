using AutoMapper;
using ProjectX.Entities.Models;
using ProjectX.Web.Areas.Definitions.Models;

namespace ProjectX.Web
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            //The type on the left is the source type, and the type on the right is the destination type

            Mapper.CreateMap<SubInventory, SubInvModel>();
            Mapper.CreateMap<SubInvModel, SubInventory>();
       }
    }
}