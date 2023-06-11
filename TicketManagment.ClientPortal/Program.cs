using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;
using TicketManagment.Application;
using TicketManagment.Application.Helpers;
using TicketManagment.Infrastructure;
using TicketManagment.Infrastructure.DbContexts;
using TicketManagment.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

Log.Logger = logger;
try
{
    ConfigurationManager configuration = builder.Configuration;
    builder.Host.UseSerilog();
    // For Entity Framework
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    
    ConfigurationReader.SetConfigurationRoot(builder.Configuration);


    builder.Services.AddHttpClient();

    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddControllersWithViews();
    // Add services to the container.
    if (builder.Environment.IsDevelopment())
    {
        builder.Services.AddWebOptimizer(minifyJavaScript: false, minifyCss: false);
    }
    else
    {
        builder.Services.AddWebOptimizer();
    }
    ConfigurationReader.SetConfigurationRoot(builder.Configuration);
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    #region Localization
    //Localization
    builder.Services.AddSingleton<LocService>();
    builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
    builder.Services.AddMvc()
         .AddMvcLocalization(opt => { opt.ResourcesPath = "Resources"; })
         .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
         .AddDataAnnotationsLocalization()
         .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    builder.Services.Configure<RequestLocalizationOptions>(opt =>
    {
        var supportlang = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR")
                };

        opt.DefaultRequestCulture = new RequestCulture("fr-FR");
        opt.SupportedCultures = supportlang;
        opt.SupportedUICultures = supportlang;
    });
    #endregion
  
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder =>
        {
            builder.UseNetTopologySuite();
            builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            builder.EnableRetryOnFailure(3);
        });
    });
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = false;
            options.ExpireTimeSpan = TimeSpan.FromDays(1);
            options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
            options.SlidingExpiration = true;
            options.ReturnUrlParameter = "returnUrl";
            options.LoginPath = "/Account/Login";
        });
    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => false;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });
    builder.Services.AddRouting();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    builder.Services.AddInfrastructureModule();
    builder.Services.AddApplicationModule();

    builder.Services.AddControllersWithViews();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddSession(options => {
        options.IdleTimeout = TimeSpan.FromDays(1);
    });


    var app = builder.Build();
    app.UseRequestLocalization();
    #region Localization
    var supportedCultures = new[]
    {
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
            };
    app.UseRequestLocalization(new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture("fr-FR"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures
    });

    #endregion

    InitData.Initialize(app.Services);

    app.UseSerilogRequestLogging();
    InitData.Initialize(app.Services);

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseWebOptimizer();
    app.UseStaticFiles();
    app.UseRouting();
    var cookiePolicyOptions = new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Strict,
        HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.None,
    };
    app.UseCookiePolicy(cookiePolicyOptions);

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSession();
    app.UseMiddleware<RequestValidator>();
    app.MapDefaultControllerRoute();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboards}/{action=Dashboard}");
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, ex.Message);
}