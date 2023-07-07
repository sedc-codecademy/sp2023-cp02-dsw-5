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
      "id": 2,
      "name": "Smart Plug",
      "description": "Turn any device into a smart device with this easy-to-use smart plug.",
      "price": 24.99,
      "imageUrl": "https://m.media-amazon.com/images/I/61YF7Ft7RRL.__AC_SY445_SX342_QL70_ML2_.jpg",
      "category": "plug"
    },
    {
      "id": 6,
      "name": "Smart Power Strip",
      "description": "Control multiple devices with this smart power strip, which features individual outlets for each device.",
      "price": 49.99,
      "imageUrl": "https://m.media-amazon.com/images/I/418XTw0UpCL._AC_SY679_.jpg",
      "category": "plug"
    },
    {
      "id": 11,
      "name": "Smart Outlet",
      "description": "This smart outlet is easy to install and allows you to control any device with your voice or phone.",
      "price": 29.99,
      "imageUrl": "https://m.media-amazon.com/images/I/715i7LdfOYL._AC_SX522_.jpg",
      "category": "plug"
    },
    {
      "id": 16,
      "name": "Smart Switch",
      "description": "Replace your existing light switch with this smart switch and control your lights with your voice or phone.",
      "price": 39.99,
      "imageUrl": "https://m.media-amazon.com/images/I/616zJaDGlrL._AC_SX522_.jpg",
      "category": "plug"
    }
  ]
};

getProducts().forEach(product => {
  const newProduct = productCard(product).cloneNode(true);
  newProduct.querySelector(`.btnAddToCard${product.id}`).addEventListener('click', () => addToCart(product));
  productsContainer.appendChild(newProduct);
});