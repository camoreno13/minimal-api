using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectef.Models;

public class Categoria{
    
    // [Key] evitar usar data annotation usando fluent api
    public Guid CategoriaId {get; set; }
    // [Required]
    // [MaxLength(150)]
    public string Nombre {get; set; }
    public string Descripcion {get; set;}
    public int Peso {get;set;}
    [JsonIgnore] // usado para ignorar esta coleccion 
    public virtual ICollection<Tarea> Tareas { get; set;}
}