using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piranha;
using Piranha.AspNetCore.Identity.SQLServer;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.SQLServer;
using Piranha.Manager.Editor;
using StortfordArchers.Models;

namespace StortfordArchers
{
    public class Startup
    {
        //private readonly IConfiguration _config;
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="configuration">The current configuration</param>
        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Service setup
            services.AddPiranha(options =>
            {
                /**
                 * This will enable automatic reload of .cshtml
                 * without restarting the application. However since
                 * this adds a slight overhead it should not be
                 * enabled in production.
                 */
                options.AddRazorRuntimeCompilation = true;
                options.UseCms();
                options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
                options.UseImageSharp();
                options.UseManager();
                options.UseTinyMCE();
                options.UseMemoryCache();
                options.UseEF<SQLServerDb>(db =>
                    db.UseSqlServer(Configuration.GetConnectionString("piranha")));
                options.UseIdentityWithSeed<IdentitySQLServerDb>(db =>
                    db.UseSqlServer(Configuration.GetConnectionString("piranha")));
               

                //configure db
               /*  string databasePath = Path.Combine("..", "StortfordArchers.db");
                services.AddDbContext<Packt.Shared.StortfordArchers>(options =>
                            options.UseSqlite($"Data Source={databasePath}"));
 */
               /*  *
                 * Here you can configure the different permissions
                 * that you want to use for securing content in the
                 * application.
                options.UseSecurity(o =>
                {
                    o.UsePermission("WebUser", "Web User");
                }); */
                

                /**
                 * Here you can specify the login url for the front end
                 * application. This does not affect the login url of
                 * the manager interface.
                options.LoginUrl = "login";
                 */
            });
            services.Configure<MailSettingsOptions>(Configuration.GetSection("MailSettings"));
          //  services.AddPiranhaFileStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Initialize Piranha
            App.Init(api);
            App.Blocks.Register<StortfordArchers.Blocks.CardBlock>();
            App.Blocks.Register<StortfordArchers.Blocks.TextWithImageBlock>();
            App.Blocks.Register<StortfordArchers.Blocks.ExcelBlock>();
            App.Modules.Manager().Scripts.Add("~/js/custom-blocks.js");
            App.Modules.Manager().Styles.Add("~/assets/css/custom-blocks.css");
            App.MediaTypes.Documents.Add(".xlsx", "application/vnd.ms-excel");

            // Build content types
            new ContentTypeBuilder(api)
                .AddAssembly(typeof(Startup).Assembly)
                .Build()
                .DeleteOrphans();

            // Configure Tiny MCE
            EditorConfig.FromFile("editorconfig.json");
           
            // Middleware setup
            app.UsePiranha(options =>
            {
                options.UseManager();
                options.UseTinyMCE();
                options.UseIdentity();
            });

            //App.Permissions["Manager"].Add(new Piranha.Security.PermissionItem
            //{
            //    Category = "My Manager Feature",
            //    Name = "EditStuff",
            //    Title = "Edit Stuff",
            //    IsInternal = true
            //});
            //App.Permissions["Manager"].Add(new Piranha.Security.PermissionItem
            //{
            //    Category = "My Manager Feature",
            //    Name = "DeleteStuff",
            //    Title = "Delete Stuff",
            //    IsInternal = true
            //});
        }
    }
}
