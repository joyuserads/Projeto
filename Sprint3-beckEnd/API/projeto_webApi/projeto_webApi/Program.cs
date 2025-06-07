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
// O namespace 'System' j� faz parte do .NET e n�o � instalado via pacote NuGet.
// O correto � garantir que o 'using System;' esteja presente no topo do arquivo, como j� est� no seu c�digo.
// N�o � necess�rio instalar nenhum pacote adicional para usar 'System' em projetos .NET.



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