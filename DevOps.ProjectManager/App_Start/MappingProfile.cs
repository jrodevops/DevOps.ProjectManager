﻿using AutoMapper;
using DevOps.ProjectManager.DTO;
using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Project
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>();
            //Issues
            Mapper.CreateMap<Issue, IssueDto>();
            Mapper.CreateMap<IssueDto, Issue>();
        }
    }
}