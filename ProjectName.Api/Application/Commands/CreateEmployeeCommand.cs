using MediatR;

namespace ProjectName.Api.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public string FullName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
