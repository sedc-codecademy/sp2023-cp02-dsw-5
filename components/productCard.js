import { addToCart } from "../helpers/session_cart.js"; 
const cardComponent = document.createElement("div");

function Add(Product) {
  return function() {
    console.log("added");
    addToCart(Product);
  }
}

function productCard(Product) {
  function showDetails(Id) {
    window.location.href = `/product-details.html?id=${Id}`;
  }

  function handleAddToCart(event) {
    if (event.target.classList.contains(`btnAddToCard${Product.id}`)) {
      console.log("added");
      addToCart(Product);
    }
  }

  cardComponent.innerHTML = `<div class="card" style="width: 18rem; margin-left: 20px;">
    <img src="${Product.imageUrl}" class="card-img-top" alt="...">
    <div class="card-body card-body-productInfo">
      <h5 class="card-title">${Product.name}</h5>
    </div>
    <ul class="list-group list-group-flush">
      <li class="list-group-item">Price : ${Product.price}$</li>
    </ul>
    <div class="card-footer">
    <a href="/product-details.html?id=${Product.id}" class="btn btn-primary btnDetails">Details</a>
    <button class="btn btn-primary btnAddToCard${Product.id}">Add To Card</button>
    </div>
    </div>`;
    // cardComponent.addEventListener('click', handleAddToCart);
  cardComponent.querySelector(`.btnAddToCard${Product.id}`).addEventListener('click', Add(Product));
  return cardComponent;
}

export default productCard;