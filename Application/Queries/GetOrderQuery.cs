using MediatR;

namespace Application.Queries
{
    public class GetOrderQuery : IRequest<Response>
    {
        public  GetOrderQuery(int id){
            Id = id;
        }
        public long Id { get; set; }
    }
}
