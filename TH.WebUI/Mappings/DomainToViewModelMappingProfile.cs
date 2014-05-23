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
            Mapper.CreateMap<Project, ProjectDetailsViewModel>();
            Mapper.CreateMap<Project, ProjectEditViewModel>();

            Mapper.CreateMap<ContractProject, ContractProjectIndexViewModel>();
            Mapper.CreateMap<ContractProject, ContractProjectDetailsViewModel>();
            Mapper.CreateMap<ContractProject, ContractProjectEditViewModel>();

            Mapper.CreateMap<BuildingMaterial, BuildingMaterialIndexViewModel>();
            Mapper.CreateMap<BuildingMaterial, BuildingMaterialDetailsViewModel>();
            Mapper.CreateMap<BuildingMaterial, BuildingMaterialEditViewModel>();

            Mapper.CreateMap<BuyBuildingMaterial, BuyBuildingMaterialIndexViewModel>();
            Mapper.CreateMap<BuyBuildingMaterial, BuyBuildingMaterialDetailsViewModel>();
            Mapper.CreateMap<BuyBuildingMaterial, BuyBuildingMaterialEditViewModel>();

            Mapper.CreateMap<Credential, CredentialIndexViewModel>();
            Mapper.CreateMap<Credential, CredentialDetailsViewModel>();
            Mapper.CreateMap<Credential, CredentialEditViewModel>();

            Mapper.CreateMap<Detection, DetectionIndexViewModel>();
            Mapper.CreateMap<Detection, DetectionDetailsViewModel>();
            Mapper.CreateMap<Detection, DetectionEditViewModel>();

            Mapper.CreateMap<Equipment, EquipmentIndexViewModel>();
            Mapper.CreateMap<Equipment, EquipmentDetailsViewModel>();
            Mapper.CreateMap<Equipment, EquipmentEditViewModel>();

            Mapper.CreateMap<Financing, FinancingIndexViewModel>();
            Mapper.CreateMap<Financing, FinancingDetailsViewModel>();
            Mapper.CreateMap<Financing, FinancingEditViewModel>();

            Mapper.CreateMap<Machine, MachineIndexViewModel>();
            Mapper.CreateMap<Machine, MachineDetailsViewModel>();
            Mapper.CreateMap<Machine, MachineEditViewModel>();

            Mapper.CreateMap<OtherInfo, OtherInfoIndexViewModel>();
            Mapper.CreateMap<OtherInfo, OtherInfoDetailsViewModel>();
            Mapper.CreateMap<OtherInfo, OtherInfoEditViewModel>();

            Mapper.CreateMap<RequireCredential, RequireCredentialIndexViewModel>();
            Mapper.CreateMap<RequireCredential, RequireCredentialDetailsViewModel>();
            Mapper.CreateMap<RequireCredential, RequireCredentialEditViewModel>();

            Mapper.CreateMap<RequireDetection, RequireDetectionIndexViewModel>();
            Mapper.CreateMap<RequireDetection, RequireDetectionDetailsViewModel>();
            Mapper.CreateMap<RequireDetection, RequireDetectionEditViewModel>();

            Mapper.CreateMap<UseEquipment, UseEquipmentIndexViewModel>();
            Mapper.CreateMap<UseEquipment, UseEquipmentDetailsViewModel>();
            Mapper.CreateMap<UseEquipment, UseEquipmentEditViewModel>();

            Mapper.CreateMap<UseMachine, UseMachineIndexViewModel>();
            Mapper.CreateMap<UseMachine, UseMachineDetailsViewModel>();
            Mapper.CreateMap<UseMachine, UseMachineEditViewModel>();

            Mapper.CreateMap<Post, PostIndexViewModel>();
            Mapper.CreateMap<Post, PostDetailsViewModel>();
            Mapper.CreateMap<Post, PostEditViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>().ForMember(cvm => cvm.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}