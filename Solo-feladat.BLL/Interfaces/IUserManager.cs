using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<List<AppUser>> GetUsersAsync();
    }
}
