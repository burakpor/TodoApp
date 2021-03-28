﻿using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data.Entity;
using TodoApp.Helpers;
using TodoApp.Models.BusinessModels;

namespace TodoApp.Test.Helpers
{
    public static class TestHelper
    {
        public static SqliteConnection SqliteConnection;
        public static IMapper GetMapperInstance()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }

        public static DbContextOptions<AppcentTodoContext> GetMockDBOptions()
        {

            var connection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection = connection;
            connection.Open();
            var options = new DbContextOptionsBuilder<AppcentTodoContext>()
                   .UseSqlite(connection)
                   .Options;

            // Create the schema in the database
            using (var context = new AppcentTodoContext(options))
            {
                EnsureCreated(context);
            }
            return options;
        }

        public static IOptions<AppSettings> GetAppSettings()
        {
            AppSettings appSettings = new AppSettings() { Secret = "VeryVerySecretKey++++!!!!" };
            return Options.Create(appSettings);

        }

        public static void EnsureCreated(AppcentTodoContext context)
        {
            if (context.Database.EnsureCreated())
            {
                context.AcUsers.Add(new AcUser
                {

                    Email = "burak@outlook.com",
                    FirstName = "Burak",
                    LastName = "Portakal",
                    Password = "F8Xk9gxUyv81JZb/CsRS8h0j+yeDYigh+xNNwYWWNfc=",//testtest
                    UserName = "burak",
                    Salt= "tOoByYVHjUQ4Ue+SWZPmEQ==",
                    CreateDate = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}
