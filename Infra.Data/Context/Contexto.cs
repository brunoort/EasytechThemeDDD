using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using Domain.Entidades;

namespace Infra.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto(string connectionString)
            : base(connectionString)
        {
            _usuarios = Usuarios;
        }


        private IDbSet<UsuarioAD> _usuarios;
        public IDbSet<UsuarioAD> Usuarios
        {
            get { return _usuarios ?? (_usuarios = DbSet<UsuarioAD>()); }
        }

       
        /// <summary>
        /// Returns a DbSet for the specified type, this allows CRUD operations to be performed for 
        /// the given entity in the context.  
        /// </summary>
        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database. 
        /// </summary>
        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            //Inicializar dados da base
            //Database.SetInitializer(new Initialiser());

            //Mapeamento das chaves estrangeiras (One to Many)
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        internal class Initialiser : DropCreateDatabaseAlways<Contexto>
        {
            protected override void Seed(Contexto context)
            {
                //context.Usuarios.AddOrUpdate(i => i.Login,
                //        new Usuario { Login = "bruno", Senha = "teste", GrupoId = 2 }
                //    );

                //context.SaveChanges();

            }
        }
    }
}