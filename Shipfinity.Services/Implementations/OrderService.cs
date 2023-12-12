using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.OrderDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Helpers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStringEncoder _stringEncoder;
        public OrderService(IOrderRepository orderRepository, IStringEncoder stringEncoder)
        {
            _orderRepository = orderRepository;
            _stringEncoder = stringEncoder;
        }

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto, int customerId)
        {
            var newOrder = new Order();
            newOrder.Customer = null;
            if (customerId != 0)
            {
                newOrder.CustomerId = customerId;
            }
            else
            {
                newOrder.CustomerId = null;
            }
            newOrder.Email = orderCreateDto.Email;
            newOrder.Status = OrderStatus.Pending;

            var today = DateTime.Now;
            DateTime cardExpireTime = new DateTime(orderCreateDto.PaymentInfo.ExpiryYear, orderCreateDto.PaymentInfo.ExpiryMonth, today.Day);
            if (today.Year > cardExpireTime.Year) throw new PaymentException("Card expired");
            if (today.Year == cardExpireTime.Year && today.Month > cardExpireTime.Month) throw new PaymentException("Card expired");

            PaymentInfo payment = new PaymentInfo
            {
                CardHolderName = _stringEncoder.Encode(orderCreateDto.PaymentInfo.CardHolderName),
                CardNumber = _stringEncoder.Encode(orderCreateDto.PaymentInfo.CardNumber),
                ExpirationDate = _stringEncoder.Encode(cardExpireTime.ToString())
            };

            var existingInfo = await _orderRepository.GetMatching(payment.CardNumber, payment.ExpirationDate);
            if (existingInfo != null)
            {
                newOrder.PaymentInfoId = existingInfo.Id;
            }
            else
            {
                newOrder.PaymentInfo = payment;
                newOrder.PaymentInfo.CustomerId = null;
                newOrder.PaymentInfo.Customer = null;
            }

            newOrder.OrderDate = DateTime.Now;
            newOrder.ProductOrders = new List<ProductOrder>();
            newOrder.ProductOrders.AddRange(orderCreateDto.OrderDetails.Select(x => new ProductOrder { Order = newOrder, ProductId = x.ProductId, Quantity = x.Quantity }));

            if (orderCreateDto.Address.Id.HasValue && orderCreateDto.Address.Id.Value > 0)
            {
                newOrder.AddressId = orderCreateDto.Address.Id.Value;
            }
            else
            {
                newOrder.Address = new Address
                {
                    AddressLine = orderCreateDto.Address.AddressLine,
                    City = orderCreateDto.Address.City,
                    Country = orderCreateDto.Address.Country,
                    ZipCode = orderCreateDto.Address.ZipCode
                };
            }
            
            int orderId = await _orderRepository.CreateAsync(newOrder);
            Order insertedOrder = await _orderRepository.GetByIdAsync(orderId);
            insertedOrder.TotalPrice = insertedOrder.ProductOrders.Sum(p => p.Product.DiscountPercentage <= 0? p.Product.Price * p.Quantity : (p.Product.Price * p.Product.DiscountPercentage / 100) * p.Quantity);
            await _orderRepository.UpdateAsync(insertedOrder);
            await ProcessPayment(insertedOrder);
            return OrderMappers.MapToReadDto(insertedOrder);
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null) throw new OrderNotFoundException(id);

            await _orderRepository.DeleteByIdAsync(id);
        }

        public async Task<string> DeliverOrder(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new OrderNotFoundException(orderId);

            order.Status = OrderStatus.Delivered;
            await _orderRepository.UpdateAsync(order);
            return order.Email;
        }

        public async Task<List<OrderReadDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task<List<OrderSellerListDto>> GetBySellerIdAsync(int sellerId)
        {
            var orders = await _orderRepository.GetAllBySellerAsync(sellerId);
            return orders.Select(x => x.ToSellerOrderList()).ToList();
        }

        public async Task<OrderReadDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null) throw new OrderNotFoundException(id);

            return OrderMappers.MapToReadDto(order);
        }

        public async Task<List<OrderReadDto>> GetOrderByProductIdAsync(int productId)
        {
            var orders = await _orderRepository.GetAllByProductIdAsync(productId);

            if (!orders.Any()) throw new OrderNotFoundException(productId);

            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task<List<OrderReadDto>> GetOrderByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetAllByUserIdAsync(userId);

            if (!orders.Any()) throw new OrderNotFoundException(userId);

            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task<OrderDetailsDto> GetOrderDetailsAsync(int orderId)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new OrderNotFoundException(orderId);
            return order.ToOrderDetails();
        }

        public async Task<string> ShipOrderAsync(int orderId)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);
            if(order == null) throw new OrderNotFoundException(orderId);

            order.Status = OrderStatus.Shipped;
            await _orderRepository.UpdateAsync(order);
            return order.Email;
        }

        public async Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (existingOrder == null) throw new OrderNotFoundException(id);

            OrderMappers.ApplyUpdateFromDto(existingOrder, orderUpdateDto);
            await _orderRepository.UpdateAsync(existingOrder);
        }

        private async Task<bool> ProcessPayment(Order order)
        {
            // Process payment
            Thread.Sleep(2000);
            order.Status = OrderStatus.Recived;
            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
