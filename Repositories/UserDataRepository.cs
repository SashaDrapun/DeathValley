using DeathValley.Interfaces;
using DeathValley.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley.Repositories
{
    public class UserDataRepository : Repository<UserData>, IUserDataRepository
    {
        public UserDataRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
