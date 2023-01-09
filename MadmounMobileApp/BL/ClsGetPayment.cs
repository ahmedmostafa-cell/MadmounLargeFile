﻿using BL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BL
{
    public interface IGetChat
    {
        IEnumerable<GetPayment> GetAll(DateTime DateOne, DateTime DateTwo);

    }
    public class ClsGetPayment : IGetChat
    {
        private string connectionString;
        MadmounDbContext ctx;
        public ClsGetPayment(MadmounDbContext contex)
        {
            ctx = contex;
            //connectionString = @"Server=DESKTOP-262OT74;Database=MadmounDb;Trusted_Connection=True;";
            connectionString = @"Server=SQL5070.site4now.net;Database=db_a788b5_newmadmon;User Id=db_a788b5_newmadmon_admin;Password=2812008a1A#;";
            //connectionString = @"Server=157.90.215.53;Database=MostafaEibtek_mad;User Id=mad;Password=2812008a1A#;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetPayment> GetAll(DateTime DateOne, DateTime DateTwo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

               
                var SQL = string.Format("EXECUTE dbo.SpGetPayment @DateOne=[{0}] , @DateTwo=[{1}]" , DateOne, DateTwo);
                IEnumerable<GetPayment> GetAll = dbConnection.Query<GetPayment>(SQL);
                return GetAll;
            }
        }
    }
}
