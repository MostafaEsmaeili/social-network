﻿using Microsoft.AspNetCore.Http;
using SocialNetwork.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Nucleus
{
    public interface IPhotoAccessor
    {
        Task<PhotoDto> AddPhotoAsync(IFormFile formFile, CancellationToken cancellationToken);
       
        Task DeletePhotoAsync(string publicId, CancellationToken cancellationToken);

        IEnumerable<string> PreparePhotosUrl(IEnumerable<string> photosCloudName);
        string PreparePhotoUrl(string cloudFileName);
    }   
}
