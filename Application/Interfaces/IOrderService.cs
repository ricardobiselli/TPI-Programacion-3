using Domain.Models.Purchases;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        public Order PlaceAnOrderFromCartContent(int clientId);

        public List<Order> GetOrdersByClientId(int clientId);
        public List<Order> GetAll();
        public Order GetById(int id);
        public void Delete(int id);


    }
}
