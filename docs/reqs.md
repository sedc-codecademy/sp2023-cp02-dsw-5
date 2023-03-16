# Drop Shipping Store 🎁

## Description

Drop Shipping is becoming very popular and it's a great way to start a small business without owning a product line, a brand, or a manufacturing facility. The internet made this concept very easy and affordable. All you need is a webshop, a third-party supplier, and a delivery method. There are a lot of suppliers online as well, so you can easily order stock, ship orders, and put new products for sale with a few clicks and taps on your keyboard. The shop we are looking for needs to have all the basic functionality of a webshop, including having an order system, listing products, a cart, and a form for the user to fill in their information so they could get their order. The orders should initially arrive at our email address. A payment system is not necessary, since the people will be paying when they get the delivery.

## Deliverable Criteria

### Phase 1

- UI
  - Home
    - Shows categories for products
    - Each category can be clicked and leads to a category page
  - Navigation
    - Home
    - Sale
    - Contact
    - Search
      - Opens a new page with results of the searched products
    - Go to Cart
  - Category Page
    - Lists all products from that category
  - Sale Page
    - Lists all products that have some discount on them
  - Contact Page
    - A form where users send messages to the company
  - Cart page
    - Lists all products in the cart
    - Lists the prices and a sum of them
    - Has a button to make an order
  - Make an order page
    - Form that requires name, street, phone number, email, and preferred day of delivery ( Monday to Saturday )
- Data
  - All products should be read from a static JSON file
  - All cart functionality should work with local storage

### Phase 2

- Back End
  - API with capabilities to manage data
    - add, remove, list, and get a filtered list
    - Category management
    - Orders management
    - Products management
    - Contact page data management
- An email should be sent to the user about their order
- Create a postman collection with all admin capabilities
  - Create product
  - Remove product
  - Update product
  - List products
  - Create Category
  - Remove Category
  - Create order
  - Remove order

## Stretch Goals

> Stretch Goals are extra goals and challenges that can be picked up during ANY phase

- Create users ( Customer and Admin )
  - Users' orders are saved in an archive
  - Their information is pre-filled in the forms of ordering and they can quick-order
- Create an admin panel for managing the products, categories, and orders
  - UI admin panel with all functionalities that the admin had with the postman collection
- New user type: A delivery person
  - They log in to the admin panel and see orders
  - They can click on an order to mark it as taken
  - They can click again on that order to mark it as delivered
  - These changes should reflect in the admin panel for the admin, so they can see which orders are taken and delivered

## Examples

- [Inspire Uplift](https://www.inspireuplift.com/)
