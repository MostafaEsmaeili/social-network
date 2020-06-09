﻿using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.EF.Repo
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Private Members
        private IActivityRepo _activityRepository { get; set; }
        private IValueRepo _valueRepository { get; set; }
        private IIdentityUserRepo _identityUserRepo { get; set; }

        private ApplicationContext _context { get; }
        #endregion


        #region Public Members
        //This way the private property is used when not null, or is initialized to the assigned value. 
        //When the statement after the null-coalescing operator ?? is executed, the assigned value to IActivityRepo is actually returned by the propery.
        public IActivityRepo ActivityRepo => _activityRepository ?? (_activityRepository = new ActivityRepo(_context));
        public IValueRepo ValueRepo => _valueRepository ?? (_valueRepository = new ValueRepo(_context));
        public IIdentityUserRepo IdentityUserRepo => _identityUserRepo ?? (_identityUserRepo = new IdentityUserRepo(_context));
        #endregion


        #region Constructors
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        #endregion


        #region Public Methods        
        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}