using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.DTOs.Category;

public class AddCategoryDTO
{
  public string? Name { get; set; } 
  public DateTime CreatedDateTime { get; set; }
}