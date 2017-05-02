using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using JunSpaWebApi.Controllers;
using JunSpaWebApi.Data;
using JunSpaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace JunSpaWebApi.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory() + "\\..\\..\\..\\..")
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .Build();

            var options = new DbContextOptionsBuilder<JunSpaContext>()
                            .UseSqlServer("Server=tcp:junspadbserver.database.windows.net,1433;Initial Catalog=JunSpaDb;Persist Security Info=False;User ID=jun;Password=Qwer1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                            .Options;


            using (var context = new JunSpaContext(options))
            {
                var vc = new BoardsController(context);
                var okObjResult = (OkObjectResult)await vc.List();
                var boards = (List<Board>)okObjResult.Value;
                Assert.Equal(boards.Count, 3);
            }

        }
    }
}
