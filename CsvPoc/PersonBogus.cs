// See https://aka.ms/new-console-template for more information
using Bogus;

public class PersonBogus
{
    public static Faker<Person> Faker => new Faker<Person>()
        .RuleFor(x => x.Attribute1, f => (int)f.Finance.Amount())
        .RuleFor(x => x.Attribute2, f => f.Address.StreetName())
        .RuleFor(x => x.Attribute3, f => f.Finance.Amount())
        .RuleFor(x => x.Attribute4, f => (int)f.Finance.Amount())
        .RuleFor(x => x.Attribute5, f => f.Address.StreetName())
        .RuleFor(x => x.Attribute6, f => f.Finance.Amount())
        .RuleFor(x => x.Attribute7, f => (int)f.Finance.Amount())
        .RuleFor(x => x.Attribute8, f => f.Address.StreetName())
        .RuleFor(x => x.Attribute9, f => f.Finance.Amount())
        .RuleFor(x => x.Attribute10, f => (int)f.Finance.Amount())
        .RuleFor(x => x.Attribute11, f => f.Address.StreetName())
        .RuleFor(x => x.Attribute12, f => f.Finance.Amount())
        .RuleFor(x => x.Attribute13, f => (int)f.Finance.Amount())
        .RuleFor(x => x.Attribute14, f => f.Address.StreetName())
        .RuleFor(x => x.Attribute15, f => f.Finance.Amount());
}