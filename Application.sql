
select p.Name as ProductName, c.Name as CategoryName
    from Products p 
        left join Product_Category_Links pc on p.Id = pc.ProductId -- таблица с ссылками  
        left join Category c on pc.CategoryId = c.Id