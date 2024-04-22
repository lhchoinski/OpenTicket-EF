using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Commands.Contracts.Employee
{
    public class UpdateEmployeeCommandContract : Contract<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandContract(UpdateEmployeeCommand command)
        {
            //Validacao do nome
            if (command.Name != null)
            {
                Requires().IsLowerOrEqualsThan(command.Name, 50, "O Nome deve conter no máximo 50 caracteres.");
            }
            else
            {
                Requires().IsNotNull(command.Name, "O campo Nome é obrigatório");
            }

            //Validacao do email
            if (command.Email != null)
            {
                Requires().IsLowerOrEqualsThan(command.Email, 50, "O Email deve conter no máximo 50 caracteres.");
            }
            else
            {
                Requires().IsNotNull(command.Email, "O campo Email é obrigatório");
            }

            //Validacao do departamento
            if (command.Department == null)
            {
                Requires().IsNotNull(command.Department, "Departamento", " O Departamento é obrigatório");
            }

            //Validacao do tipo do funcionario
            if (command.EmployeeType != null)
            {
                Requires().IsNotNull(command.EmployeeType, "EmployeeType", "O Tipo do funcionário é obrigatório");
            }

        }
    }
}
