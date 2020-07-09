﻿using SocialNetwork.Dto;

namespace SocialNetwork.Nucleus
{
    internal class CommentMapper : BaseMapper
    {
        #region Constructor
        public CommentMapper()
        {
            Map<DataModel.Comment, CommentDto>()
            .ForMember(dest => dest.UserDisplayName, opt => opt.MapFrom(src => src.Author.DisplayName))
            .ForMember(dest => dest.MainPhotoCloudFileName, opt => opt.MapFrom(src => src.Author.MainPhoto.CloudFileName))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Author.Id));
        } 
        #endregion
    }
}