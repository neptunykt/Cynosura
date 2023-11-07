﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Cynosura.Core.Data;
using Cynosura.Studio.Core.Entities;
using Cynosura.Studio.Core.Infrastructure;

namespace Cynosura.Studio.Core.Requests.FileGroups
{
    public class CreateFileGroupHandler : IRequestHandler<CreateFileGroup, CreatedEntity<int>>
    {
        private readonly IEntityRepository<FileGroup> _fileGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFileGroupHandler(IEntityRepository<FileGroup> fileGroupRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _fileGroupRepository = fileGroupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreatedEntity<int>> Handle(CreateFileGroup request, CancellationToken cancellationToken)
        {
            var fileGroup = _mapper.Map<CreateFileGroup, FileGroup>(request);
            _fileGroupRepository.Add(fileGroup);
            await _unitOfWork.CommitAsync();
            return new CreatedEntity<int>() { Id = fileGroup.Id };
        }

    }
}
