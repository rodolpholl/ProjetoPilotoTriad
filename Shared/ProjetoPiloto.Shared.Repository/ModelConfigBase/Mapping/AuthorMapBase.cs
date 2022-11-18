using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjetoPiloto.Shared.Interfaces;

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
                x.NotNullable(true);
            });

            Property(b => b.CreateDateTime, x =>
            {
                x.Update(false);
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);

            });

            Table("Author");

        }
    }
}
