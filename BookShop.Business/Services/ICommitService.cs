using BookShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Services
{
	public interface ICommitService
	{
		void AddCommit(AddCommitDto addCommitDto);
		List<ListCommitDto> GetCommits();
		EditCommitDto GetCommitById(int id);
		void EditCommit(EditCommitDto editCommitDto);
		void DeleteCommit(int id);
	}
}
