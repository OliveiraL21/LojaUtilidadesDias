using Data.Context;
using Data.Implementation;
using Data.Repositorios;
using Domain.Interfaces.Services.Produtos;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplication
{
    static class Program
    {
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            
            using(var service = Application.Get)
            Application.Run(new Form_Principal());
        }

        public static void ConfigureServices(ServiceCollection service)
        {
            service.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;DataBase=Loja_DiasDb;Uid=root;Pwd=lucas123",
                new MySqlServerVersion(new Version(8,0,26))
                ));
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IProdutoRepository, ProdutoImplementation>();
        }
    }
}
