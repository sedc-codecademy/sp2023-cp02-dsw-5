import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';
import productCard from '../../components/productCard.js';
import { addToCart } from '../../helpers/session_cart.js';

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const productsContainer = document.getElementById("products-container");

function getProducts() {
  return [
    {
      "id": 1,
      "name": "Smart Light Bulb",
      "description": "Control your lights from anywhere with this smart light bulb.",
      "price": 19.99,
      "imageUrl": "https://m.media-amazon.com/images/I/71YDobkreZL._AC_SX679_.jpg",
      "category": "light"
    },
    {
      "id": 5,
      "name": "Smart LED Strip",
      "description": "Add ambiance to any room with this versatile smart LED strip.",
      "price": 39.99,
      "imageUrl": "https://m.media-amazon.com/images/I/61F09kEGfaL._AC_SX569_.jpg",
      "category": "light"
    },
    {
      "id": 10,
      "name": "Smart Ceiling Light",
      "description": "Control the brightness and color of this smart ceiling light with your voice or phone.",
      "price": 79.99,
      "imageUrl": "https://m.media-amazon.com/images/I/71VQGctDrCL._AC_SX679_.jpg",
      "category": "light"
    },
    {
      "id": 15,
      "name": "Smart Desk Lamp",
      "description": "Adjust the brightness and color temperature of this smart desk lamp with your voice or phone.",
      "price": 49.99,
      "imageUrl": "https://m.media-amazon.com/images/I/617DcLygQzL._AC_SX569_.jpg",
      "category": "light"
    }
  ]
};

getProducts().forEach(product => {
  productsContainer.innerHTML += '';
  const newProduct = productCard(product);
  productsContainer.appendChild(newProduct);
});