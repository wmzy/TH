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

            Mapper.CreateMap<ProjectCreateViewModel, Project>();
            Mapper.CreateMap<ProjectEditViewModel, Project>();

            Mapper.CreateMap<ContractProjectCreateViewModel, ContractProject>();
            Mapper.CreateMap<ContractProjectEditViewModel, ContractProject>();

            Mapper.CreateMap<BuildingMaterialCreateViewModel, BuildingMaterial>();
            Mapper.CreateMap<BuildingMaterialEditViewModel, BuildingMaterial>();

            Mapper.CreateMap<BuyBuildingMaterialCreateViewModel, BuyBuildingMaterial>();
            Mapper.CreateMap<BuyBuildingMaterialEditViewModel, BuyBuildingMaterial>();

            Mapper.CreateMap<CredentialCreateViewModel, Credential>();
            Mapper.CreateMap<CredentialEditViewModel, Credential>();

            Mapper.CreateMap<DetectionCreateViewModel, Detection>();
            Mapper.CreateMap<DetectionEditViewModel, Detection>();

            Mapper.CreateMap<EquipmentCreateViewModel, Equipment>();
            Mapper.CreateMap<EquipmentEditViewModel, Equipment>();

            Mapper.CreateMap<FinancingCreateViewModel, Financing>();
            Mapper.CreateMap<FinancingEditViewModel, Financing>();

            Mapper.CreateMap<MachineCreateViewModel, Machine>();
            Mapper.CreateMap<MachineEditViewModel, Machine>();

            Mapper.CreateMap<OtherInfoCreateViewModel, OtherInfo>();
            Mapper.CreateMap<OtherInfoEditViewModel, OtherInfo>();

            Mapper.CreateMap<RequireCredentialCreateViewModel, RequireCredential>();
            Mapper.CreateMap<RequireCredentialEditViewModel, RequireCredential>();

            Mapper.CreateMap<RequireDetectionCreateViewModel, RequireDetection>();
            Mapper.CreateMap<RequireDetectionEditViewModel, RequireDetection>();

            Mapper.CreateMap<UseEquipmentCreateViewModel, UseEquipment>();
            Mapper.CreateMap<UseEquipmentEditViewModel, UseEquipment>();

            Mapper.CreateMap<UseMachineCreateViewModel, UseMachine>();
            Mapper.CreateMap<UseMachineEditViewModel, UseMachine>();

            Mapper.CreateMap<PostCreateViewModel, Post>();
            Mapper.CreateMap<PostEditViewModel, Post>();
            Mapper.CreateMap<CommentFormViewModel, Comment>();

            Mapper.CreateMap<UserInfoViewModel, User>();
        }
    }
}