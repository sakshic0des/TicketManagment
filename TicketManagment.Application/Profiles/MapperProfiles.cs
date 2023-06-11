using AutoMapper;

namespace TicketManagment.Application.Profiles
{
    public class MapperProfiles
    {
        public static IEnumerable<Profile> GetAssemblyProfiles()
        {
            return new Profile[]
            {
                new DefaultAutoMapperProfile(),
                new EmployeeAutoMapperProfile(),
            };
        }
    }
}
