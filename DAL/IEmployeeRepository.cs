using Entities;

namespace ArtSofteASPMVC_net6_.DAL
{
    public interface IEmployeeRepository
    {
        int Delete(int id);
        List<Employee> GetAll();
        Employee GetByID(int id);
        Employee InsertData(Employee objemp);
        Employee UpdateData(Employee objemp);
    }
}