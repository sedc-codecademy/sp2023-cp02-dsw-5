import headerContainer from "../../components/header.js";
import footerContainer from "../../components/footer.js";
import { GetById } from "../services/product_service.js";
import { addToCart } from "../helpers/session_cart.js";

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const productDetails = document.getElementById("product-details");

// Get product id from URL
const params = new URLSearchParams(window.location.search);
const id = params.get("id");

// Fetch product details
let Product = GetById(parseInt(id));
if (Product) {
  productDetails.innerHTML = `
  <div class="container">
  <img class="card-img-bottom details-img" src="${Product.imageUrl}" alt="${Product.name}">
    <div class="card-header">
      <h2>${Product.name}</h2>
    </div>
    <div class="card-body">
      <p class="card-text">$${Product.price}</p>
      <p class="card-text">${Product.description}</p>
    </div>
    <div class="card-footer">
      <button class="btn btn-primary" id="buyNowBtn">Buy now</button>
    </div>
  </div>
      `;
} else {
  productDetails.innerHTML = "<p>Product not found.</p>";
}

const addItem = () => {
  addToCart(Product)
}

document.querySelector("#buyNowBtn").addEventListener('click', addItem);
