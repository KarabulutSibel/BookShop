using BookShop.Business.Dtos;
using BookShop.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(AddUserDto addUserDto);
        UserInfoDto LoginUser(LoginDto loginDto);
    }
}
