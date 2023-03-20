using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.User;
using backend.DTOs.CartItem;

namespace backend.DTOs.Cart;

public class CartDTO
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public int UserId { get; set; }
    public GetUserDTO? User { get; set; }
    public List<CartItemDTO> CartItems { get; set; } = null!;
}