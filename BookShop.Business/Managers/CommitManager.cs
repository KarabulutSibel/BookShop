using BookShop.Business.Dtos;
using BookShop.Business.Services;
using BookShop.Data.Entities;
using BookShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Managers
{
	public class CommitManager : ICommitService
	{
		private readonly IRepository<CommitEntity> _commitRepository;

		public CommitManager(IRepository<CommitEntity> commitRepository)
		{
			_commitRepository = commitRepository;
		}

		public void AddCommit(AddCommitDto addCommitDto)
		{
			var entity = new CommitEntity
			{
				UserId = addCommitDto.UserId,
				ProductId = addCommitDto.ProductId,
				Content = addCommitDto.Content,
			};

			_commitRepository.Add(entity);
		}

		public void DeleteCommit(int id)
		{
			_commitRepository.Delete(id);
		}

		public void EditCommit(EditCommitDto editCommitDto)
		{
			var entity = _commitRepository.GetById(editCommitDto.Id);

			entity.Content = editCommitDto.Content;

			_commitRepository.Update(entity);
		}

		public EditCommitDto GetCommitById(int id)
		{
			var entity = _commitRepository.GetById(id);

			var editCommitDto = new EditCommitDto()
			{
				Id = entity.Id,
				UserId = entity.UserId,
				ProductId = entity.ProductId,
				Content = entity.Content,
			};

			return editCommitDto;
		}

		public List<ListCommitDto> GetCommits()
		{
			var commitEntities = _commitRepository.GetAll().OrderByDescending(x => x.CreatedDate);

			var listCommitDto = commitEntities.Select(x => new ListCommitDto 
			{
				Id = x.Id,
				UserId = x.UserId,
				ProductId = x.ProductId,
				Content = x.Content,
				UserFirstName = x.User.FirstName,
				UserLastName = x.User.LastName,
				IsDeleted = x.IsDeleted,
			}).ToList();

			return listCommitDto;
		}
	}
}
