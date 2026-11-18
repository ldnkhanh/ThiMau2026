using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeDuyNgocKhanh.Models;
public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTL { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(50, 1000, ErrorMessage = "Giá phải là số trong khoảng 50 đến 1000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp|JPG|JPEG|PNG|WEBP)$",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    [ValidateNever]
    public virtual TheLoai MaTLNavigation { get; set; } = null!;

}
