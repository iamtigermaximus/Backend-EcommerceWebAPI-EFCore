using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;


namespace backend.Models;

public class Category
{
  public int Id { get; set; }
  public string? Name { get; set; } 

  public DateTime CreatedDateTime { get; set; }
}