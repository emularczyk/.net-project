﻿using Microsoft.AspNetCore.Identity;
using Web_Forum.Models;

namespace Web_Forum.Areas.Identity
{
    public class RoleStore : IRoleStore<UserRole>
    {
        public void Dispose()
        {
        }

        public Task<IdentityResult> CreateAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetRoleNameAsync(UserRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(UserRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
