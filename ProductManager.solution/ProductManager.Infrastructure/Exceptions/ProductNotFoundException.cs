using System;
using System.Collections.Generic;
using System;

namespace ProductManager.Infrastructure.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId)
            : base($"El producto con ID {productId} no fue encontrado.")
        {
        }
    }
}
