using System;
using System.ComponentModel.DataAnnotations;

public class TransactionRequest
{
    [Required]
    public string AccountNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; }
    public string Channel { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
