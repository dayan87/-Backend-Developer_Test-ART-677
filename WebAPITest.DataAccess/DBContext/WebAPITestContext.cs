using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPITest.Models;

namespace WebAPITest.DataAccess.DBContext
{
    public partial class WebAPITestContext : DbContext
    {
        public WebAPITestContext()
        {
        }

        public WebAPITestContext(DbContextOptions<WebAPITestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actuals> Actuals { get; set; }
        public virtual DbSet<Estimates> Estimates { get; set; }

    }
}