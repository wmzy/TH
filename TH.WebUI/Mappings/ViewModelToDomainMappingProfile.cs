using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TH.Model;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<JobCreateViewModel, Job>();
            Mapper.CreateMap<JobEditViewModel, Job>();

            Mapper.CreateMap<JobHuntingCreateViewModel, JobHunting>();
            Mapper.CreateMap<JobHuntingEditViewModel, JobHunting>();

            Mapper.CreateMap<ContractProjectCreateViewModel, ContractProject>();
        }
    }
}