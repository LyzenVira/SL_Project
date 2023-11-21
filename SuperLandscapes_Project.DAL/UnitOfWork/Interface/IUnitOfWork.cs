using SuperLandscapes_Project.DAL.Repositories.Interfaces;

namespace SuperLandscapes_Project.DAL.UnitOfWork.Interface
{
    public interface IUnitOfWork :IDisposable
    {
        void Save();

        ICountryRepository CountryRepository { get; }
        IPictureRepository PictureRepository { get; }
        IParagraphRepository ParagraphRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ITechnologyRepository TechnologyRepository { get; }
        IProjectTechnologyRepository ProjectTechnologyRepository { get; }
    }
}
