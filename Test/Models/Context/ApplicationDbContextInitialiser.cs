using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Context;

namespace Test.Models.Context
{
    public class ApplicationDbContextInitialiser
    {        
        private readonly dbTestSqlServerContext _context;
        private readonly dbTestMySqlContext _mySqlcontext;

        public ApplicationDbContextInitialiser(dbTestSqlServerContext context, dbTestMySqlContext mySqlcontext)
        {
            _context = context;
            _mySqlcontext = mySqlcontext;
        }

        public void InitialiseAsync()
        {
            
            if (_context.Database.IsSqlServer())
            {
                 _context.Database.MigrateAsync();
            }

            if (_context.Database.IsMySql())
            {
                 _mySqlcontext.Database.MigrateAsync();
            }

        }
        
    }
}
