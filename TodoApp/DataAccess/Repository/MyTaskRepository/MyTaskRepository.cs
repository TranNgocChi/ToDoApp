using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;	
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.MyTaskRepository
{
	public class MyTaskRepository : IMyTaskRepository
	{
		private readonly TaskDAO taskDAO;

		public MyTaskRepository(TaskDAO _taskDAO)
		{
			taskDAO = _taskDAO ?? throw new ArgumentNullException(nameof(_taskDAO));
		}

		public void Create(MyTask task) => taskDAO.Create(task);	
		public void Delete(string id) => taskDAO.Delete(id);
		public void DeleteAll() => taskDAO.DeleteAll();	

		public List<MyTask> GetAll() => taskDAO.GetAll();

		public MyTask GetById(string id) => taskDAO.GetById(id);

		public void Update(MyTask task, string id) => taskDAO.Update(task, id);	
	}
}
