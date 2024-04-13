using BusinessObject;
using BusinessObject.Path;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace DataAccess.Context
{
	public class TaskContext : DbContext
	{
		public TaskContext(DbContextOptions<TaskContext> options) : base(options)
		{
		}
		public DbSet<MyTask> MyTasks { get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(SharedPath.DataAccess_Path))
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfiguration configuration = builder.Build();

			optionsBuilder.UseSqlServer(configuration.GetConnectionString("Todo"));
		}

		
	}
}
