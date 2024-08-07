﻿using System.Text.Json.Serialization;
namespace WebAPI.Models;
public class Category // Objeto de categoria aonde a uma lista de produtos.
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
