using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.MyTaskRepository
{
	public interface IMyTaskRepository
	{
		public void Create(MyTask task);
		public MyTask GetById(string id);
		public void Update(MyTask task, string id);
		public void Delete(string id);
		public List<MyTask> GetAll();
		public void DeleteAll();

	}
}
