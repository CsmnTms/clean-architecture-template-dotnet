using CleanArch.Core.Cow;

namespace CleanArch.Infrastructure.Data.Config;

// TODO_research: how / when is this run?
public class CowConfiguration : IEntityTypeConfiguration<Cow>
{
    public void Configure(EntityTypeBuilder<Cow> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        //builder.OwnsMany(builder => builder.Items);
    }
}
