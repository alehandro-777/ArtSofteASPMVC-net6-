using Entities;

namespace ArtSofteASPMVC_net6_.DAL
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
    }
}