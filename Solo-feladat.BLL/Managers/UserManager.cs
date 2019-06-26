using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly SoloContext context;

        public UserManager(SoloContext context)
        {
            this.context = context;
        }

        //public async Task<List<AppUser>> GetUsersAsync()
        //{

        //}

        //public async Task<List<Flight>> GetFlightsByUserIdAsync(Guid UserId)
        //{

        //}
    }
}
