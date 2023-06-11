using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using TicketManagment.Domain.Entities;
using TicketManagment.Domain.ViewModels;

namespace TicketManagment.Application.Services.Ticket
{
    public class TicketService : BaseService, ITicketService
    {
        public ICurrentUser _currentUser { get; }
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser)
            : base(unitOfWork, mapper)
        {
            _currentUser = currentUser;
        }

        public async Task<PaginationResultVm<List<TicketListDto>>> GetTicketListAsAJson(TicketPaginationModel model)
        {
            try
            {
                model.pagination = _currentUser.SetPagination();
                var result = await GetAllTickets(model);
                if (result != null)
                {
                    return new PaginationResultVm<List<TicketListDto>>
                    {
                        data = result?.Tickets,
                        draw = Convert.ToInt32(result.Pagination?.Draw, CultureInfo.CurrentCulture),
                        recordsTotal = Convert.ToInt32(result.Pagination?.Count, CultureInfo.CurrentCulture),
                        recordsFiltered = Convert.ToInt32(result.Pagination?.Count, CultureInfo.CurrentCulture),
                    };
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        private async Task<TicketListQueryResult> GetAllTickets(TicketPaginationModel model)
        {
            var tickets = UnitOfWork.TicketRepository.AsQueryable().Where(obj => true);

            if (model.pagination == null)
            {
                model.pagination = new Pagination()
                {
                    PageNumber = 0,
                    PageSize = 10
                };
            }
            var count = tickets.Where(a => true).Count();
            model.pagination.Count = count;
            var query =await tickets.Include(obj => obj.Department)
                               .OrderByDescending(o => o.RequestedDate).ToListAsync();
            if (query != null)
            {
                List<TicketListDto> result = query.Select(obj =>
                {
                    var ticket = new TicketListDto(obj);
                    return ticket;
                }).ToList();
                if (result != null)
                {
                    if (!String.IsNullOrEmpty(model.pagination.SearchValue))
                    {
                        result = result.Where(obj => obj.Description.ToUpper().Contains(model.pagination.SearchValue.ToUpper()) ||
                                                     obj.ProjectName.ToUpper().Contains(model.pagination.SearchValue.ToUpper()) ||
                                                     obj.DepartmentName.ToUpper().Contains(model.pagination.SearchValue.ToUpper()))
                                                   .ToList();
                        model.pagination.Count = result.Count;
                    }
                    if (!String.IsNullOrEmpty(model.pagination.Order))
                    {
                        switch (model.pagination.Order)
                        {
                            case "1":
                                if (model.pagination.OrderDir == "asc")
                                    result = result.OrderBy(obj => obj.ProjectName).ToList();
                                else
                                    result = result.OrderByDescending(obj => obj.ProjectName).ToList();
                                break;

                            case "2":
                                if (model.pagination.OrderDir == "asc")
                                    result = result.OrderBy(obj => obj.DepartmentName).ToList();
                                else
                                    result = result.OrderByDescending(obj => obj.DepartmentName).ToList();
                                break;



                            case "3":
                                if (model.pagination.OrderDir == "asc")
                                    result = result.OrderBy(obj => obj.Description).ToList();
                                else
                                    result = result.OrderByDescending(obj => obj.Description).ToList();
                                break;



                            case "4":
                                if (model.pagination.OrderDir == "asc")
                                    result = result.OrderBy(obj => obj.RequestedDate).ToList();
                                else
                                    result = result.OrderByDescending(obj => obj.RequestedDate).ToList();
                                break;



                            default:
                                break;
                        }
                    }
                    var res = result.Skip(model.pagination.PageNumber).Take(model.pagination.PageSize).ToList();
                    TicketListQueryResult changedProvidersQueryResult = new TicketListQueryResult()
                    {
                        Tickets = res,
                        Pagination = model.pagination,
                    };
                    return changedProvidersQueryResult;
                }
            }



            return null;
        }

        public async Task<List<DepartmentLookup>> RetrieveDepartments()
        {
            List<DepartmentLookup> result=new List<DepartmentLookup>();
            var res =await UnitOfWork.DepartmentRepository.AsQueryable().Where(obj => true).ToListAsync();
            result= res.Select(obj => new DepartmentLookup()
            {
                Id = obj.ID,
                Name = obj.DepartmentName
            }).ToList();
            return result;
        }

        public async Task<List<EmployeeLookup>> RetrieveEmployessByDepartmentId(int departmentId)
        {
            List<EmployeeLookup> result = new List<EmployeeLookup>();
            var res = await UnitOfWork.EmployeeRepository.AsQueryable().Where(obj => obj.DepartmentId== departmentId).ToListAsync();
            result = res.Select(obj => new EmployeeLookup()
            {
                Id = obj.ID,
                Name = obj.EmployeeName
            }).ToList();
            return result;
        }

        public async Task<bool> AddNewTicket(CreateTicketVM model)
        {
            try
            {
                if (model != null)
                {

                    TicketManagment.Domain.Entities.Ticket ticket = new TicketManagment.Domain.Entities.Ticket()
                    {
                        DepartmentId = model.DepartmentId,
                        Description = model.Description,
                        RequestedDate= DateTime.UtcNow,
                        ProjectName= model.ProjectName,
                        EmployeeId= model.EmployeeId,
                        CreatedDateTime = DateTime.UtcNow,
                    };
                    await UnitOfWork.TicketRepository.AddAsync(ticket);
                    await UnitOfWork.CompleteAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
