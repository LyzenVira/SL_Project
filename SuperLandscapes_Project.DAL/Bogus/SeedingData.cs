using AutoBogus;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.DAL.Bogus
{
    public static class SeedingData
    {
        private static List<Country> Countries { get; set; } = new();
        private static List<Paragraph> Paragraphs { get; set; } = new();
        private static List<Picture> Pictures { get; set; } = new();
        private static List<Project> Projects { get; set; } = new();
        private static List<ProjectTechnology> ProjectTechnologies { get; set; } = new();
        private static List<Technology> Technologies { get; set; } = new();

        public static List<Country> SeedCountries()
        {
            Countries = new AutoFaker<Country>()
                .RuleFor(fake => fake.Name, fake => fake.Address.Country())
                .Generate(15);

            return Countries;
        }

        public static List<Paragraph> SeedParagraphs( )
        {
            Paragraphs = new AutoFaker<Paragraph>()
                .RuleFor(fake => fake.Title, fake => fake.Lorem.Sentence())
                .RuleFor(fake => fake.Description, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.ProjectId, fake => fake.Random.Guid())
                .Generate(15);

            return Paragraphs;
        }

        public static List<Picture> SeedPictures( )
        {
            Pictures = new AutoFaker<Picture>()
                .RuleFor(fake => fake.Url, fake => fake.Image.PicsumUrl())
                .RuleFor(fake => fake.ProjectId, fake => fake.Random.Guid())
                .Generate(15);

            return Pictures;
        }

        public static List<Project> SeedProjects(List<Country> countries)
        {
            Projects = new AutoFaker<Project>()
                .RuleFor(fake => fake.Title, fake => fake.Lorem.Word())
                .RuleFor(fake => fake.Description, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.Period, fake => fake.Date.Recent().ToString())
                .RuleFor(fake => fake.DateYear, fake => fake.Date.Recent().Year)
                .RuleFor(fake => fake.CountryId, fake => fake.PickRandom(countries).Id)
                .RuleFor(fake => fake.RequestDescription, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.RequestList, fake => fake.Lorem.Lines(3))
                .RuleFor(fake => fake.SolutionDescription, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.ResultFirstParagraph, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.ResultSecondParagraph, fake => fake.Lorem.Paragraph())
                .RuleFor(fake => fake.ResultThirdParagraph, fake => fake.Lorem.Paragraph())
                .Generate(15);

            return Projects;
        }

        public static List<ProjectTechnology> SeedProjectTechnologies(List<Project> projects, List<Technology> technologies)
        {
            ProjectTechnologies = new AutoFaker<ProjectTechnology>()
                .RuleFor(fake => fake.TechnologyId, fake => fake.PickRandom(technologies).Id)
                .RuleFor(fake => fake.ProjectId, fake => fake.PickRandom(projects).Id)
                .Generate(15);

            return ProjectTechnologies;
        }

        public static List<Technology> SeedTechnologies()
        {
            Technologies = new AutoFaker<Technology>()
                .RuleFor(fake => fake.Name, fake => fake.Lorem.Word())
                .Generate(15);

            return Technologies;
        }
    }
}
