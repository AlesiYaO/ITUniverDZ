using System;
using FluentNHibernate.Mapping;
using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
namespace WebApplication2Library
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Группа, к которой относится пользователь
        /// </summary>
        public virtual string Group { get; set; }
    }

    public class Document
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public virtual char TypeDocument { get; set; }

        /// <summary>
        /// Дата создания документа
        /// </summary>
        public virtual DateTime DateCreature { get; set; }

        /// <summary>
        /// Автор документа
        /// </summary>
        public virtual string Author { get; set; }
    }

    public class PravoDostupaKPapke
    {
        /// <summary>
        /// Ссылка на Папку
        /// </summary>
        public virtual int Papka { get; set; }

        /// <summary>
        /// Уровень доступа к данной папке
        /// </summary>
        public virtual string UrovenDostupa { get; set; }

        /// <summary>
        /// Ссылка на Группу пользователей 
        /// </summary>
        public virtual int GroupUsers { get; set; }

        /// <summary>
        /// Ссылка на Пользователя
        /// </summary>
        public virtual int User { get; set; }
    }

    public class Papka
    {
        /// <summary>
        /// Идентификатор папки
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Имя папки(название)
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Тип папки
        /// </summary>
        public virtual Papka TypePapka { get; set; }

    }

    public class VersionDocument
    {
        /// <summary>
        /// Идентификатор версии документа
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public virtual string File { get; set; }

        /// <summary>
        /// Автор версии
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public virtual DateTime DateCreature { get; set; }

        /// <summary>
        /// Ссылка на документ
        /// </summary>
        public virtual int Document { get; set; }
    }

    public class GroupUsers
    {
        /// <summary>
        /// Идентификатор группы пользователей
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        public virtual string Name { get; set; }
    }


    //--------------------------Маппинг------------------------------------------------------
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Login).Length(100);
            Map(u => u.Password).Length(100);
            Map(u => u.Group).Length(100);

        }
      
    }

    public class DocumentMap:ClassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.TypeDocument).Length(100);
            Map(u => u.DateCreature).Length(100);
            Map(u => u.Author).Length(100);
        }
    }

    public class PravoDostupaKPapkeMap:ClassMap<PravoDostupaKPapke>
    {
        public PravoDostupaKPapkeMap()
        {
            Id(u => u.Papka).GeneratedBy.HiLo("100");
            Map(u => u.UrovenDostupa).Length(100);
            Map(u => u.GroupUsers).Length(100);
            Map(u => u.User).Length(100);
        }
    }
    public class PapkaMap:ClassMap<Papka>
    {
        public PapkaMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Name).Length(100);
            Map(u => u.TypePapka).Length(100);
            
        }
    }

    public class VersionDocumentMap:ClassMap<VersionDocument>
    {
        public VersionDocumentMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.File).Length(100);
            Map(u => u.Author).Length(100);
            Map(u => u.DateCreature).Length(100);
            Map(u => u.Document).Length(100);
        }


    }

    public class GroupUsersMap: ClassMap<GroupUsers>
    {
        public GroupUsersMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Name).Length(100);
         
        }
    }


    class Program
    {


        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(x =>
            {
                var cfg = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=DESKTOP-T0ANP28\\SQLEXPRESS;Initial Catalog=ITUniver;Integrated Security=SSPI;") //Integrated Security - проверка подлинности
                    .Dialect<MsSql2012Dialect>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Document>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PravoDostupaKPapke>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Papka>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<VersionDocument>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GroupUsers>());



                var conf = cfg.BuildConfiguration();
                var schemeExport = new SchemaUpdate(conf);
                schemeExport.Execute(true, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>();

            var container = containerBuilder.Build();

            var user = new User { Login = "ABCD", Password = "ABCD", Group = "Master"};
            var document = new Document { TypeDocument = '1', DateCreature = DateTime.Now, Author = "ABCD" };
            var pravoDostupaKPapke = new PravoDostupaKPapke { GroupUsers = 1, Papka = 1, UrovenDostupa = "Verh", User = 1 };
            var papka = new Papka { Name = "Сила"};
            var versionDocument = new VersionDocument { Author = "ABCD", DateCreature = DateTime.Now, Document = 1, File = "txt"};
            var groupUsers = new GroupUsers {  Name = "1"};



            var session = container.Resolve<ISession>();
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(user);
                    session.Save(document);
                    session.Save(pravoDostupaKPapke);
                    session.Save(papka);
                    session.Save(versionDocument);
                    session.Save(groupUsers);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                }
            }

        }
    }
    }
