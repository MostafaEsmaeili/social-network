﻿using MediatR;
using SocialNetwork.Dto;
using SocialNetwork.EF.Repo;
using SocialNetwork.Util;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Nucleus.Comment
{
    public class Create
    {
        public class Command : IRequest<CommentDto>
        {
            public string Body { get; set; }

            [JsonIgnore]
            public string UserName { get; set; }

            public Guid ActivityId { get; set; }
        }

        public class Handler : IRequestHandler<Command, CommentDto>
        {
            #region Members
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapperHelper _mapperHelper;
            private readonly IPhotoAccessor _photoAccessor;
            #endregion


            #region Constuctor
            public Handler(IUnitOfWork unitOfWork, IMapperHelper mapperHelper, IPhotoAccessor photoAccessor)
            {
                _unitOfWork = unitOfWork;
                _mapperHelper = mapperHelper;
                _photoAccessor = photoAccessor;
            }
            #endregion


            #region Methods
            public async Task<CommentDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _unitOfWork.ActivityRepo.FindFirstAsync(request.ActivityId, cancellationToken);
                if (activity == null)
                    throw new CustomException(System.Net.HttpStatusCode.BadRequest, new { Activity = "Not Found" });

                var user = await _unitOfWork.IdentityUserRepo.FindFirstAsync(request.UserName, cancellationToken);
                if (user == null)
                    throw new CustomException(System.Net.HttpStatusCode.BadRequest, new { User = "Not Found" });

                DataModel.Comment comment = _mapperHelper.Map<Command, DataModel.Comment>(request);
                comment.AuthorId = user.AppUser.Id;

                _unitOfWork.CommentRepo.Add(comment);

                int insertCnt = await _unitOfWork.SaveAsync(cancellationToken);
                if (insertCnt > 0)
                {
                    comment.Activity = activity;
                    comment.Author = user.AppUser;

                    CommentDto commentDto = _mapperHelper.Map<DataModel.Comment, CommentDto>(comment);
                    commentDto.UserImage = _photoAccessor.PreparePhotoUrl(commentDto.MainPhotoCloudFileName);
                    return commentDto;
                }

                throw new Exception("Problem saving changes to database");
            }
            #endregion
        }
    }
}
