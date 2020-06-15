﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int QuantityInCart { get; set; }

        public string DisplayText
        {
            get
            {
                if (QuantityInCart > 1)
                {
                    return $"{Product.ProductName} ({QuantityInCart})";
                }
                else
                {
                    return $"{Product.ProductName}";
                }
            }
        }
    }
}