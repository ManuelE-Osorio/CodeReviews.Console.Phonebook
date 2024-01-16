using Microsoft.EntityFrameworkCore;

namespace PhoneBookProgram;
public class PhoneBookContext : DbContext
{
    public static readonly int ContactNameLenght = 150;
    public static readonly int ContactCategoryLenght = 150;
    public static readonly int EmailLocalNameLenght = 64;
    public static readonly int EmailDomainNameLenght = 254;
    public static readonly int PhoneNumberCountryCodeLenght = 3;
    public static readonly int PhoneNumberLocalNumberLenght = 15;
    public static string? PhoneBookConnectionString {get; set;}
    public DbSet<Contact> Contacts {get; set;}
    public DbSet<Email> Emails {get; set;}
    public DbSet<PhoneNumber> PhoneNumbers {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .UseSqlServer(PhoneBookConnectionString,
        sqlServerOptions => sqlServerOptions.CommandTimeout(5));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .Property(p => p.ContactName)
            .HasMaxLength(ContactNameLenght)
            .IsRequired()
            .IsUnicode(true);

        modelBuilder.Entity<Contact>()
            .HasIndex(p => p.ContactName)
            .IsUnique(true);

        modelBuilder.Entity<Contact>()
            .Property(p => p.Category)
            .HasMaxLength(ContactCategoryLenght)
            .IsUnicode(true);

        modelBuilder.Entity<Contact>()
            .OwnsMany(p => p.Emails)
            .Property(p => p.LocalName)
            .HasMaxLength(EmailLocalNameLenght)
            .IsUnicode(true)
            .IsRequired(true);

        modelBuilder.Entity<Contact>()
            .OwnsMany(p => p.Emails)
            .Property(p => p.DomainName)
            .HasMaxLength(EmailDomainNameLenght)
            .IsUnicode(true)
            .IsRequired(true);

        modelBuilder.Entity<Contact>()
            .OwnsMany(p => p.PhoneNumbers)
            .Property(p => p.CountryCode)
            .HasMaxLength(PhoneNumberCountryCodeLenght)
            .IsUnicode(false)
            .IsRequired(true);

        modelBuilder.Entity<Contact>()
            .OwnsMany(p => p.PhoneNumbers)
            .Property(p => p.LocalNumber)
            .HasMaxLength(PhoneNumberLocalNumberLenght)
            .IsUnicode(false)
            .IsRequired(true);

        modelBuilder.Entity<Contact>()
            .Navigation(p => p.Emails)
            .AutoInclude(false);
        
        modelBuilder.Entity<Contact>()
            .Navigation(p => p.PhoneNumbers)
            .AutoInclude(false);
    }
}