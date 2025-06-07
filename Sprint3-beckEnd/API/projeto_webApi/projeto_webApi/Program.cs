using Cqrs.Hosts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// O namespace 'System' já faz parte do .NET e não é instalado via pacote NuGet.
// O correto é garantir que o 'using System;' esteja presente no topo do arquivo, como já está no seu código.
// Não é necessário instalar nenhum pacote adicional para usar 'System' em projetos .NET.



namespace projeto_webApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartUp>();
                });
    }
}