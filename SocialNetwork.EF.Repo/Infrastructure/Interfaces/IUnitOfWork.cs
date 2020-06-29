﻿using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.EF.Repo
{
    public interface IUnitOfWork
    {
        IActivityRepo ActivityRepo { get; }
        IValueRepo ValueRepo { get; }
        IIdentityUserRepo IdentityUserRepo { get; }
        IAppUserRepo AppUserRepo { get; }
        IUserActivityRepo UserActivityRepo { get; }
        IPhotoRepo PhotoRepo { get; }
        ICommentRepo CommentRepo { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
