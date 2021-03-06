﻿using ClassModel.model.bsc;
using ClassModel.model.organization;
using ClassModel.model.realIncrease;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModel.connnection.sql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<I8MobileAcceptance> I8MobileAcceptance { get; set; }
        public DbSet<I8MobileApp> I8MobileApp { get; set; }
        public DbSet<ListDirectory> ListDirectory { get; set; }
        public DbSet<DataReal> SL_THUCTANG { get; set; }
        public DbSet<DetailFiberMyTV> DetailFiberMyTV { get; set; }
        public DbSet<DetailDataReal> Sl_ThuTang_Detail { get; set; }
        public DbSet<Organization> Organization { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Organization>().HasKey(i => new { i.donvi_id, i.ten_dv });
        }
    }
}
