//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Scriptum.Data;

//namespace Scriptum.Data
//{
//    public class ScriptumContextFactory : IDesignTimeDbContextFactory<ScriptumContext>
//    {
//        public ScriptumContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ScriptumContext>();

//            // Reemplaza con tu cadena de conexión real de Neon.tech
//            // Asegúrate de tener instalado el paquete Npgsql.EntityFrameworkCore.PostgreSQL
//            optionsBuilder.UseNpgsql("\"DefaultConnection\": \"Host=ep-fragrant-credit-abivcf3e-pooler.eu-west-2.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Ya0wrcy1MFen;SSL Mode=Require;Trust Server Certificate=true\"");

//            return new ScriptumContext(optionsBuilder.Options);
//        }
//    }
//}
