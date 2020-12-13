# ASP.NET
Schedule ASP.NET CORE server

1.  Install SQL SERVER 2019
2.  And install corresponding mssql (2019 is preferable)
3.  Go to the server configuration management and enable all options
4.  On ASP.Net appsetting.cs : need to put this snippet 'Trusted_connection"
   Something like below
    
  "ConnectionStrings": {
    "conn": "Server=DESKTOP-A52VMR8;Database=western;User Id=guru;password=psh1998623;MultipleActiveResultSets=True;Trusted_Connection=true;"
    // "conn": "Server=.\\SQLExpress;Database=WesternSchedulerDb;User Id=sa;Password=Mechlin_123;MultipleActiveResultSets=True;"
    // "conn": "Server=.\\PROJECT;Database=western;User Id=sa;Password=Developer123;;MultipleActiveResultSets=True;"
    // "conn": "Server=L-SQL-01;Database=WesternScheduler;User Id=schedulerapp;Password=T3cxdjVU9zKSBShsKYG5fR=?u6;"
  }
  
5. In startup.cs
   Need to add this line onto the "ConfigureServices" function
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("Your ip address:8088")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });


6. Install google extension Meosif Cors. For handling the cors token error
7. Use ip address not localhost into the browser.
