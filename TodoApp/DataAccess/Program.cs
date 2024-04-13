using BusinessObject;
using DataAccess.Context;
using DataAccess.DAO;
using DataAccess.Repository.MyTaskRepository;

class Program
{
	static void Main()
	{
		IMyTaskRepository repo = new MyTaskRepository(new TaskDAO(new TaskContext(new Microsoft.EntityFrameworkCore.DbContextOptions<TaskContext>())));
		//repo.Create(new MyTask { task = "Hoc Toan", isCompleted = false, time=new DateTime() });
		//tsk.Update(new MyTask { task = "Soan Bai", isCompleted = false, time = new DateTime() }, "7682af2f-205d-4ce2-8997-ab97b8c8569b");
		repo.GetAll().ForEach(  t => Console.WriteLine(t.ShowTask()));
	}
}