using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Commands.Contracts.Employee
{
    public class DeleteEmployeeCommandContract : Contract<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandContract(DeleteEmployeeCommand command)
        {
            if (command.Id == null)
            {
                Console.WriteLine("O Funcionario com o ID:" + command.Id + "não exixte");
            }

        }
    }
}
