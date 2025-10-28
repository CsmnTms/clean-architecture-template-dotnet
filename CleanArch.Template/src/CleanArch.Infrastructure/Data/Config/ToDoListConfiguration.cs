using CleanArch.Core.ToDoListAggregate;

namespace CleanArch.Infrastructure.Data.Config;

// TODO_research: how / when is this run?
public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
{
    public void Configure(EntityTypeBuilder<ToDoList> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.OwnsMany(builder => builder.Items);
    }
}
