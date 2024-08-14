SELECT p.Name, c.Name
FROM my_product p
LEFT JOIN product_category pc ON p.Id = pc.product_id
LEFT JOIN my_category c ON c.Id = pc.category_id