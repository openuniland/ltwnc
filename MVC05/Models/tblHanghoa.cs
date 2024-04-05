using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC05.Models;

public class tblHanghoa
{
    [Key]
    [Column(TypeName = "int")]
    public int PK_iHanghoaID { get; set; }

    [Column(TypeName = "nvarchar(300)")]
    public string? sTenHang { get; set; }

    [Column(TypeName = "float")]
    public float? fGianiemyet { get; set; }

    [Column(TypeName = "ntext")]
    public string? sDacdiem { get; set; }

    [Column(TypeName = "nvarchar(300)")]
    public string? sXuatxu { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? sAnhminhhoa { get; set; }

}
