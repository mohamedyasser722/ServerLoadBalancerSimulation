using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancerSimulation.Database.Entities;
public class CSETeamOS
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Group { get; set; }
    public required string CourseName { get; set; }
}

public class CSETeamOSConfiguration : IEntityTypeConfiguration<CSETeamOS>
{
    public void Configure(EntityTypeBuilder<CSETeamOS> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Group).IsRequired();
        builder.Property(x => x.CourseName).IsRequired();
    }
}