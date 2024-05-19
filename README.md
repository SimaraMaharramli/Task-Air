# .NET Core 6 Mini Project

This is a simple .NET Core 6 project implementing basic functionalities for managing products, orders, and users. It includes features like user authentication (login/register), product management, and order creation.

## Features

- **Authentication:** Users can register and login to the system. Admin role is required for certain actions.
- **Product Management:**
  - Admins can create, update, and delete products.
  - All users can view all products and retrieve a specific product by its ID.
- **Order Management:**
  - Users can create orders, view their order history, and delete their orders.

## Endpoints

### Product Management

#### Create Product
- **URL:** `POST https://localhost:7259/api/Product/CreateProduct`
- **Request Body:**
  ```json
  {
    "name": "test2",
    "description": "test2",
    "price": 6.01,
    "stock": 50
  }
  Response: Product Created (Status Code: 200)

Update Product
- **URL:** `PUT https://localhost:7259/api/Product/Update`
Request Body:
- **Request Body:**
  ```json
{
  "id": 2,
  "name": "tt2",
  "description": "tt2",
  "price": 9.01,
  "stock": 80
}
Response: Product Updated (Status Code: 200)


Delete Product
- **URL:** ` DELETE https://localhost:7259/api/Product/DeleteProduct/{id} `
Response: Product Deleted (Status Code: 200)

Get All Products
- **URL:** ` GET https://localhost:7259/api/Product/GetAllProducts `
Response: List of all products (Status Code: 200)
Get Product by ID
- **URL:** ` GET https://localhost:7259/api/Product/GetById/{id} `
Response: Details of the product with the specified ID (Status Code: 200)


Order Management
Create Order
- **URL:** ` POST https://localhost:7259/api/Order/CreateOrder  `
Request Body:
- **Request Body:**
  ```json
{
  "description": "tt2",
  "location": "tt3",
  "products": [
    {
      "productId": 3
    }
  ]
}
Response: Order Created (Status Code: 200)

Get User Order History
- **URL:** ` GET https://localhost:7259/api/Order/GetUserOrderHistory  `
Response: List of orders made by the user (Status Code: 200)
Delete Order
URL: DELETE https://localhost:7259/api/Order/DeleteOrder/{id}
Response: Order Deleted (Status Code: 200)

Permissions
Admins: Can create, update, and delete products.
Users: Can view all products, retrieve product details, create orders, view their order history, and delete their orders.

