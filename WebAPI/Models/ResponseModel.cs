namespace WebAPI.Models;
public class ResponseModel<T> // Responsavel pela minha resposta.
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Status { get; set; }
 }
