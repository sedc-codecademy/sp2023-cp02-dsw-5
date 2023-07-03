import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const itemContainer = document.getElementById("itemsContainer");
const shoppingCart = document.getElementById("shoppingCart");
const clearCartBtn = document.querySelector('.clear-cart');
const totalCartBtn = document.querySelector('.cart-total');
const deleteBtn = document.querySelector('#delete-btn');




let proceedToPayBtn = document.getElementById('proceedToPay');

function GetToCheckoutPage(){
  location.href = "checkout.html";
}
proceedToPayBtn.addEventListener("click", GetToCheckoutPage);

let cart = [{"id": 2,
"name": "Smart Plug",
"description": "Turn any device into a smart device with this easy-to-use smart plug.",
"price": 24.99,
"imageUrl": "#",
"category": "plug"},
{"id": 3,
"name": "Smart Plug",
"description": "Turn any device into a smart device with this easy-to-use smart plug.",
"price": 24.99,
"imageUrl": "#",
"category": "plug"}];

cart = cart.map(product => {
  return {
    ...product,
    numberOfUnits: 1
  };
})

function sumProductPrices(){
  let totalPrice = 0;
  
  cart.forEach(product => {
    totalPrice += product.price * product.numberOfUnits;
  })
  totalCartBtn.innerHTML = totalPrice.toFixed(2);
}

sumProductPrices(cart);

function changeNumberOfUnits(action, id){
  cart = cart.map((product) =>{
    if (product.id != id) {
      return product;
    }
    const {numberOfUnits} = product;
    const updatedNumberOfUnits = action === "plus"
    ?numberOfUnits + 1 
    : numberOfUnits -1;
     
    
    return {
      ...product,
      numberOfUnits : Math.max(1, updatedNumberOfUnits),
    };
    
  });
  renderProducts(cart);
  sumProductPrices(cart);
  
};
window.changeNumberOfUnits = changeNumberOfUnits;


function renderProducts(cart) {
  shoppingCart.innerHTML = "";
  cart.forEach((product) =>{
    shoppingCart.innerHTML += `
    <div class="cart-item">
      <div class="item-img>
        <img src="${product.imageUrl}" alt="${product.name}">
        <h3>${product.name}</h3>
      </div>
      <div class="delete-btn">Delete</div>
      <div class="unit-price">
        <h2><small>$${product.price}</small></h2>
      </div>
      <div class="d-flex justify-content-center units flex-container">
        <div class="btn minus" onclick="changeNumberOfUnits('minus', ${product.id})">-</div>
        <div class="number">${product.numberOfUnits}</div>
        <div class="btn plus" onclick="changeNumberOfUnits('plus', ${product.id})">+</div>
      </div>
    </div>
    `
  })
}


renderProducts(cart);

// deleteBtn.addEventListener('click', deleteById);
console.log("Hello!");