using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjetoPiloto.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Repository.ModelConfigBase.Mapping
{
    public class AuthorMapBase<T> : ClassMapping<T> where T : class, IAuthor
    {
        public AuthorMapBase()
        {


            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });

            Property(b => b.FirstName, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.LastName, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Alias, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.UpdateDateTime, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Generated(PropertyGeneration.Always);
                x.NotNullable(true);
            });

            Property(b => b.CreateDateTime, x =>
            {
                x.Update(false);
                x.Type(NHibernateUtil.DateTime);
                x.Generated(PropertyGeneration.Insert);
                x.Insert(true);
                x.NotNullable(true);
             
            });


            Table("Authors");


        }
    }
}
