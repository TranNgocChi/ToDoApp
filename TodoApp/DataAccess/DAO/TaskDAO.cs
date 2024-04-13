using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
	public class TaskDAO
	{
		private readonly TaskContext context;

		public TaskDAO(TaskContext _context)
		{
			context = _context ?? throw new ArgumentNullException(nameof(context));
		}

		public void Create(MyTask tsk) {
			try
			{
				context.MyTasks.Add(tsk);
				context.SaveChanges();
				Console.WriteLine("Add thanh cong!");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public MyTask? GetById(string id)
		{
			try
			{
				var findTask = context.MyTasks.FirstOrDefault(ct => ct.id == id);
				if (findTask != null)
				{
					return findTask;
				}
				Console.WriteLine("Task ko ton tai");
				return null;
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);	
			}
		}
		public void Update(MyTask newTsk, string id) { 
			var findTask = GetById(id);
			if (findTask != null)
			{
				findTask.task = newTsk.task;
				findTask.time = newTsk.time;
				findTask.isCompleted = newTsk.isCompleted;
				context.MyTasks.Update(findTask);
				Console.WriteLine("Update thanh cong!");
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("Id ko ton tai!");
			}
		}
		public void Delete(string id) {
			var findTask = GetById(id);
			if (findTask != null)
			{
				context.MyTasks.Remove(findTask);
				context.SaveChanges();
				Console.WriteLine("Xoa thanh cong!");
			}
			Console.WriteLine("ID ko ton tai!");
		}
		public List<MyTask> GetAll()
		{
			try
			{
				return context.MyTasks.OrderByDescending(task => task.time).ToList();
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void DeleteAll()
		{
			try
			{
				var allTasks = context.MyTasks.ToList();
				context.MyTasks.RemoveRange(allTasks);
				context.SaveChanges() ;
				Console.WriteLine("Remove thanh cong");
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}
