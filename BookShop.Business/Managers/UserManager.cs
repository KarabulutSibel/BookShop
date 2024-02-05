using BookShop.Business.Dtos;
using BookShop.Business.Services;
using BookShop.Business.Types;
using BookShop.Data.Entities;
using BookShop.Data.Enums;
using BookShop.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Managers
{
	public class UserManager : IUserService
	{
		private readonly IRepository<UserEntity> _userRepository;
		private readonly IDataProtector _dataProtector;
		public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
		{
			_userRepository = userRepository;
			_dataProtector = dataProtectionProvider.CreateProtector("security");
		}

		public ServiceMessage AddUser(AddUserDto addUserDto)
		{
			var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == addUserDto.Email.ToLower()).ToList();

			if (hasMail.Any())
			{
				return new ServiceMessage
				{
					IsSucceed = false,
					Message = "Bu E-posta adresli bir kulllanıcı zaten mevcut."
				};
			}

			var entity = new UserEntity
			{
				Email = addUserDto.Email,
				FirstName = addUserDto.FirstName,
				LastName = addUserDto.LastName,
				Password = _dataProtector.Protect(addUserDto.Password),
				UserType = UserTypeEnum.User
			};

			_userRepository.Add(entity);

			return new ServiceMessage
			{
				IsSucceed = true
			};
		}

		public UserInfoDto LoginUser(LoginDto loginDto)
		{
			var userEntity = _userRepository.Get(x => x.Email == loginDto.Email);

			if (userEntity is null)
			{
				return null;
			}

			var rawPassword = _dataProtector.Unprotect(userEntity.Password);

			if (rawPassword == loginDto.Password)
			{
				return new UserInfoDto
				{
					Id = userEntity.Id,
					Email = userEntity.Email,
					FirstName = userEntity.FirstName,
					LastName = userEntity.LastName,
					UserType = userEntity.UserType,
				};
			}
			else 
			{
				return null;
			}
		}
	}
}
