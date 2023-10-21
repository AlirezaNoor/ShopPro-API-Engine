﻿namespace Core.Interface.IReposetory;

public interface IproductRepository
{
    /// <summary>
    /// this method get products with id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<product> GetBtIdAsync(int Id);

    /// <summary>
    /// this  method get all products
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<product>> GetProductsAsync();
}