using Microsoft.Extensions.DependencyInjection;
using TicketManagment.Infrastructure.DbContexts;

namespace TicketManagment.Infrastructure.Seeders
{
    public static class InitData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await AddDepartments(context);
            await AddEmployees(context);
            await context.SaveChangesAsync();
        }

        public static async Task AddDepartments(ApplicationDbContext context)
        {
            if (!context.Departments.Any())
            {
                var departments = new List<Domain.Entities.Department>()
                {
                    new Domain.Entities.Department() {DepartmentName="Division of Telecommunications Extranet Development"},
                    new Domain.Entities.Department() {DepartmentName="Extranet Multimedia Connectivity and Security Division"},
                    new Domain.Entities.Department() {DepartmentName="Branch of Extranet Implementation"},
                    new Domain.Entities.Department() {DepartmentName="Branch of Intranet Computer Maintenance and E-Commerce PC Programming"},
                    new Domain.Entities.Department() {DepartmentName="Wireless Extranet Backup Team"},
                    new Domain.Entities.Department() {DepartmentName="Database Programming Branch"},
                    new Domain.Entities.Department() {DepartmentName="Hardware Backup Department"},
                    new Domain.Entities.Department() {DepartmentName="Multimedia Troubleshooting and Maintenance Team"},
                    new Domain.Entities.Department() {DepartmentName="Office of Statistical Data Connectivity"},
                    new Domain.Entities.Department() {DepartmentName="Division of Application Security"},
                    new Domain.Entities.Department() {DepartmentName="Network Maintenance and Multimedia Implementation Committee"},
                    new Domain.Entities.Department() {DepartmentName="Mainframe PC Development and Practical Source Code Acquisition Team"},
                    new Domain.Entities.Department() {DepartmentName="PC Maintenance Department"},
                    new Domain.Entities.Department() {DepartmentName="Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control"},
                    new Domain.Entities.Department() {DepartmentName="Software Technology and Networking Department"},
                };
                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }
        }


        public static async Task AddEmployees(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                var employees = new List<Domain.Entities.Employee>()
                {
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Telecommunications Extranet Development").FirstOrDefault().ID,EmployeeName="Roma Marcell"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Telecommunications Extranet Development").FirstOrDefault().ID,EmployeeName="Janelle Newberg"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Telecommunications Extranet Development").FirstOrDefault().ID,EmployeeName="Linh Leitzel"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Telecommunications Extranet Development").FirstOrDefault().ID,EmployeeName="Alissa Perlman"},

                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Extranet Multimedia Connectivity and Security Division").FirstOrDefault().ID,EmployeeName="Roma Marcell"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Extranet Multimedia Connectivity and Security Division").FirstOrDefault().ID,EmployeeName="Hugo Wess "},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Extranet Multimedia Connectivity and Security Division").FirstOrDefault().ID,EmployeeName="Leola Thornburg"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Extranet Multimedia Connectivity and Security Division").FirstOrDefault().ID,EmployeeName="Delorse Searle"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Extranet Multimedia Connectivity and Security Division").FirstOrDefault().ID,EmployeeName="Thresa Levins"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Extranet Implementation").FirstOrDefault().ID,EmployeeName="Roma Marcell"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Extranet Implementation").FirstOrDefault().ID,EmployeeName="Kelvin Lahr"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Extranet Implementation").FirstOrDefault().ID,EmployeeName="Idella Dallman"},



                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Intranet Computer Maintenance and E-Commerce PC Programming").FirstOrDefault().ID,EmployeeName="Mellie Lombard"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Intranet Computer Maintenance and E-Commerce PC Programming").FirstOrDefault().ID,EmployeeName="Shawna Hood"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Branch of Intranet Computer Maintenance and E-Commerce PC Programming").FirstOrDefault().ID,EmployeeName="Kenneth Bowie"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Wireless Extranet Backup Team").FirstOrDefault().ID,EmployeeName="Reita Abshire"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Wireless Extranet Backup Team").FirstOrDefault().ID,EmployeeName="Janice Skipper"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Wireless Extranet Backup Team").FirstOrDefault().ID,EmployeeName="Tawna Blackmore"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Database Programming Branch").FirstOrDefault().ID,EmployeeName="Dalila Vickrey"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Database Programming Branch").FirstOrDefault().ID,EmployeeName="Marcelo Paris"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Database Programming Branch").FirstOrDefault().ID,EmployeeName="Tomoko Gale"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Hardware Backup Department").FirstOrDefault().ID,EmployeeName="Dalila Vickrey"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Hardware Backup Department").FirstOrDefault().ID,EmployeeName="Marcelo Paris"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Hardware Backup Department").FirstOrDefault().ID,EmployeeName="Tomoko Gale"},



                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Multimedia Troubleshooting and Maintenance Team").FirstOrDefault().ID,EmployeeName="Ione Tomlin"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Multimedia Troubleshooting and Maintenance Team").FirstOrDefault().ID,EmployeeName="Hilario Masterson"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Multimedia Troubleshooting and Maintenance Team").FirstOrDefault().ID,EmployeeName="Sage Bow"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Multimedia Troubleshooting and Maintenance Team").FirstOrDefault().ID,EmployeeName="Kasie Barclay"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Office of Statistical Data Connectivity").FirstOrDefault().ID,EmployeeName="Keren Gillespi"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Office of Statistical Data Connectivity").FirstOrDefault().ID,EmployeeName="Alexandra Brendle"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Application Security").FirstOrDefault().ID,EmployeeName="Rosalia Ayoub"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Division of Application Security").FirstOrDefault().ID,EmployeeName="Olympia Vien"},

                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Network Maintenance and Multimedia Implementation Committee").FirstOrDefault().ID,EmployeeName="Wilfredo Stumpf"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Network Maintenance and Multimedia Implementation Committee").FirstOrDefault().ID,EmployeeName="Boyce Perales"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Network Maintenance and Multimedia Implementation Committee").FirstOrDefault().ID,EmployeeName="Latoyia Kremer"},
                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Network Maintenance and Multimedia Implementation Committee").FirstOrDefault().ID,EmployeeName="Katheryn Lepak"},

                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Mainframe PC Development and Practical Source Code Acquisition Team").FirstOrDefault().ID,EmployeeName="Luciano Riddell"},


                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="PC Maintenance Department").FirstOrDefault().ID,EmployeeName="Olene Pyron"},

                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control").FirstOrDefault().ID,EmployeeName="Greta Quigg"},

                    new Domain.Entities.Employee() {DepartmentId=context.Departments.Where(obj=>obj.DepartmentName=="Software Technology and Networking Department").FirstOrDefault().ID,EmployeeName="Diego Hasbrouck"},

                };
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }
        }

    }
}
