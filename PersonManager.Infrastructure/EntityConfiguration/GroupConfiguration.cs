using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManager.Domain.Persons;

namespace PersonManager.Infrastructure.EntityConfiguration
{
    public class GroupConfiguration : EntityTypeConfigurationBase<Group>
    {
        protected override void ConfigureMore(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder
                .HasMany(g => g.Persons)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.GroupId);

            builder.HasData(DefaultGroupsPerson());
        }

        private IEnumerable<Group> DefaultGroupsPerson()
        {
            yield return Group.New("Group 1").WithId(1);
            yield return Group.New("Group 2").WithId(2);
        }
    }
}
