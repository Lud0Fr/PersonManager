using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManager.Domain.Persons;
using System.Collections.Generic;

namespace PersonManager.Infrastructure.EntityConfiguration
{
    public class PersonConfiguration : EntityTypeConfigurationBase<Person>
    {
        protected override void ConfigureMore(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            builder.HasData(DefaultPersons());
        }

        private IEnumerable<Person> DefaultPersons()
        {
            yield return Person.New("John Lewis", 1).WithId(1);
            yield return Person.New("Peter Johns", 1).WithId(2);
            yield return Person.New("Boris Johnson", 1).WithId(3);
            yield return Person.New("Elisabeth II", 2).WithId(4);
            yield return Person.New("Theresa May", 2).WithId(5);
        }
    }
}
