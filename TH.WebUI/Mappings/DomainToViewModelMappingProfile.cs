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
            Mapper.CreateMap<Job, JobIndexViewModel>();
            Mapper.CreateMap<Job, JobDetailsViewModel>();
            Mapper.CreateMap<Job, JobEditViewModel>();

            Mapper.CreateMap<JobHunting, JobHuntingIndexViewModel>();
            Mapper.CreateMap<JobHunting, JobHuntingDetailsViewModel>();
            Mapper.CreateMap<JobHunting, JobHuntingEditViewModel>();

            Mapper.CreateMap<Project, ProjectIndexViewModel>();
            Mapper.CreateMap<ContractProject, ContractProjectDetailsViewModel>();
        }
    }
}