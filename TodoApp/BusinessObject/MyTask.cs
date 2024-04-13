using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
	public class MyTask
	{
		[Key]
		public string? id { get; set; } = Guid.NewGuid().ToString();

		[Required]
		[StringLength(50)]
		public string? task { get; set; }
		public DateTime time { get; set; }
		public bool isCompleted {  get; set; }

		public string ShowTask() => $"ID: {id} - Task: {task} - Time: {time} - IsCompleted: {isCompleted}";
	}
}
