using AutoMapper;
using ProjectX.Entities.Models;
using ProjectX.Web.Areas.Definitions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Web.Utility
{
    public static class Mappings
    {
        public static SubInventory ToEntity(this SubInvModel model) 
        {
            return Mapper.Map<SubInvModel, SubInventory>(model);
        }

        public static SubInvModel ToModel(this SubInventory entity) 
        {
            return Mapper.Map<SubInventory, SubInvModel>(entity);
        }
    }
}