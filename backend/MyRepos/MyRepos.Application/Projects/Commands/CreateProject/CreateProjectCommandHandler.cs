﻿using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IGithubService _githubService;

        public CreateProjectCommandHandler(
            IProjectRepository projectRepository, 
            IGithubService githubService)
        {
            _projectRepository = projectRepository;
            _githubService = githubService;
        }

        public async Task<ErrorOr<Project>> Handle(
            CreateProjectCommand request, 
            CancellationToken cancellationToken)
        {
            var metadata = await _githubService.GetGithubRepository(request.RepositoryUrl);

            var project = Project.Create(
                metadata.Id,
                metadata.Name,
                metadata.Description,
                metadata.Language,
                metadata.Updated_At,
                metadata.Owner.Login,
                request.RepositoryUrl);

            await _projectRepository.AddAsync(project);

            return project;
        }
    }
}
