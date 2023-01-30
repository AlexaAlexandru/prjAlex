using System;

using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data
{
	public class CustomerContext: DbContext
	{
		public virtual DbSet<Customer> Customers { get; set; }
	}
}

