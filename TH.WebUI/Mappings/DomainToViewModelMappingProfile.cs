using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TH.Model;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Project, ProjectIndexViewModel>();
        }
    }
}