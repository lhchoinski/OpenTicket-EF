using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OpenTicket.Domain.Handlers
{
    public class EmployeeHandler
    {
        private readonly AppDataContext _context;

        public EmployeeHandler(AppDataContext context)
        {
            _context = context;
        }

        public async Task<ICommandResult> SaveEmployeeAsync(SaveEmployeeCommand command)
        {
            var employee = new Employee(
                command.Name,
                command.Email,
                command.Department,
                command.EmployeeType
            );

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return new EmployeeCommandResult(true, "Funcionário inserido com sucesso");
        }

        public async Task<ICommandResult> UpdateEmployeeAsync(UpdateEmployeeCommand command)
        {
            var employee = await _context.Employees.FindAsync(command.Id);
            if (employee == null)
            {
                return new EmployeeCommandResult(false, "Funcionário não encontrado");
            }

            employee.Name = command.Name;
            employee.Email = command.Email;
            employee.Department = command.Department;
            employee.EmployeeType = command.EmployeeType;

            await _context.SaveChangesAsync();

            return new EmployeeCommandResult(true, "Funcionário atualizado com sucesso");
        }

        public async Task<ICommandResult> DeleteEmployeeAsync(DeleteEmployeeCommand command)
        {
            var employee = await _context.Employees.FindAsync(command.Id);
            if (employee == null)
            {
                return new EmployeeCommandResult(false, "Funcionário não encontrado");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return new EmployeeCommandResult(true, "Funcionário deletado com sucesso");
        }

        public async Task<ICommandResult> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return new EmployeeCommandResult(true, "Lista de funcionários recuperada com sucesso", employees);
        }

        public async Task<ICommandResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return new EmployeeCommandResult(false, "Funcionário não encontrado");
            }

            return new EmployeeCommandResult(true, "Funcionário encontrado com sucesso", employee);
        }

    }
}
